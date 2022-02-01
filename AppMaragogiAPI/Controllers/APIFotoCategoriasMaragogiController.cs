using AppMaragogiAPI.Models;
using AppMaragogiAPI.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoCategoriasMaragogiController : ApiController
    {
        private string RootFundoCategoriasMaragogi = HttpContext.Current.Server.MapPath(@"/Uploads/");
        private string RootCategoriasMaragogi = HttpContext.Current.Server.MapPath(@"/Uploads/CategoriasMaragogi");

        private ObservableCollection<FotosEstabelecimentos> ObservableCollection;

        public ObservableCollection<FotosEstabelecimentos> GetImageCategoriasMaragogi(string CategoriasMaragogi)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategoriasMaragogi, CategoriasMaragogi.Trim()));

            string[] Files = Directory.GetFiles(pathString);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }

        public ObservableCollection<FotosEstabelecimentos> GetFundo(string tipo)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootFundoCategoriasMaragogi, tipo));

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