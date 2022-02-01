using AppMaragogiAPI.Models;
using AppMaragogiAPI.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoPraiasController : ApiController
    {
        private string RootFundoPraias = HttpContext.Current.Server.MapPath(@"/Uploads/FundoPraias");
        private string RootPraias = HttpContext.Current.Server.MapPath(@"/Uploads/Praias");
        private ObservableCollection<FotosEstabelecimentos> ObservableCollection;

        public ObservableCollection<FotosEstabelecimentos> GetImagePraia(string Praia)
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootPraias, Praia));

            string[] Files = Directory.GetFiles(pathString);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }

        public ObservableCollection<FotosEstabelecimentos> GetFundoPraia()
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string[] Files = Directory.GetFiles(RootFundoPraias);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }
    }
}