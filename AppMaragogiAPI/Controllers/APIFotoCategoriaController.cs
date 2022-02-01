using AppMaragogiAPI.Models;
using AppMaragogiAPI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoCategoriaController : ApiController
    {
        private string RootCategoria = HttpContext.Current.Server.MapPath(@"/Uploads/Categorias");
        private string RootFundo = HttpContext.Current.Server.MapPath(@"/Uploads/FundoCategorias/");
        private ObservableCollection<FotosEstabelecimentos> ObservableCollection;

        public ObservableCollection<FotosEstabelecimentos> GetFundoCategoria(string FundoCategoria)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();
            var path = Normalization.RemoverAcentuacao(Path.Combine(RootFundo, FundoCategoria));

            string[] Files = Directory.GetFiles(path);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }

        public ObservableCollection<FotosEstabelecimentos> GetSubCategoria(string SubCategoria)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategoria, SubCategoria));

            string[] Files = Directory.GetFiles(pathString);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }
    }
}
