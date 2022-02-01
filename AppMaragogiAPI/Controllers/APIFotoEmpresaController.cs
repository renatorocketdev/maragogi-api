using AppMaragogiAPI.Models;
using AppMaragogiAPI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoEmpresaController : ApiController
    {
        private ObservableCollection<FotosEstabelecimentos> ObservableCollection;

        private string RootEmpresas = HttpContext.Current.Server.MapPath(@"/Uploads/Empresas");
        public ObservableCollection<FotosEstabelecimentos> Get(string NomeEmpresa, string SubCategoria)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootEmpresas, SubCategoria, NomeEmpresa));

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
