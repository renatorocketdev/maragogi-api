using AppMaragogiAPI.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoHistoriaMaragogiController : ApiController
    {
        private string RootFundoHistoria = HttpContext.Current.Server.MapPath(@"/Uploads/FundoHistoria");
        private ObservableCollection<FotosEstabelecimentos> ObservableCollection;

        public ObservableCollection<FotosEstabelecimentos> GetFundoPraia()
        {
            ObservableCollection = new ObservableCollection<FotosEstabelecimentos>();

            string[] Files = Directory.GetFiles(RootFundoHistoria);

            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i].Replace(@"F:\vhosts\", @"https://www.").Replace(@"\httpdocs", "").Replace("\\", "/").Replace("/appmaragogi/", "/");

                ObservableCollection.Add(new FotosEstabelecimentos { Foto = Files[i] });
            }

            return ObservableCollection;
        }
    }
}