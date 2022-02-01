using AppMaragogiAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class FotoController : ApiController
    {
        #region Fields

        private string RootCategorias = HttpContext.Current.Server.MapPath(@"/Uploads/Categorias");
        private string RootCategoriasMaragogi = HttpContext.Current.Server.MapPath(@"/Uploads/CategoriasMaragogi");
        private string RootEmpresa = HttpContext.Current.Server.MapPath(@"/Uploads/Empresas");

        private string RootFundoMainCategorias = HttpContext.Current.Server.MapPath(@"/Uploads/FundoCategorias");
        private string RootHistoriaMaragogi = HttpContext.Current.Server.MapPath(@"/Uploads/FundoHistoria");

        #endregion Fields

        #region Methods

        public string[] GetPathFundoMaragogi()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoMaragogi")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        public int GetQtdFotoFundoMaragogi()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoMaragogi")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public string[] GetPathPontoTurisco()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoPontoTuristico")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        public int GetQtdFotoFundoPontoTuristico()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoPontoTuristico")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public string[] GetPathPraias()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoPraias")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        public int GetQtdFotoPraias()
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(HttpContext.Current.Server.MapPath($"/Uploads/FundoPraias")));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }


        // GET: api/FotosEstabelecimentos
        public string[] GetPathEmpresaImages(string Empresa, string SubCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootEmpresa, SubCategoria, Empresa)); 

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        // GET: api/FotosEstabelecimentos
        public string[] GetPathHistoriaImages()
        {
            return Directory.GetFiles(RootHistoriaMaragogi);
        }

        // GET: api/FotosEstabelecimentos
        public string[] GetPathImagesCategorias(string SubCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategorias, SubCategoria));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        // GET: api/FotosEstabelecimentos
        public string[] GetPathMaragogiImages(string CategoriaMaragogi)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategoriasMaragogi, CategoriaMaragogi.Trim()));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        // GET: api/FotosEstabelecimentos
        public int GetQtdEmpresaImages(string NomeEmpresa, string SubCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootEmpresa, SubCategoria, NomeEmpresa));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public int GetQtdFotoCategorias(string SubCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategorias, SubCategoria));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public int GetQtdHistoriaImages()
        {
            if (!Directory.Exists(RootHistoriaMaragogi))
                Directory.CreateDirectory(RootHistoriaMaragogi);

            return Directory.GetFiles(RootHistoriaMaragogi).Length;
        }

        public int GetQtdMaragogiImages(string CategoriaMaragogi)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootCategoriasMaragogi, CategoriaMaragogi.Trim()));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public int GetQtdMainCategoriaImages(string MainCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootFundoMainCategorias, MainCategoria));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString).Length;
        }

        public string[] GetPathMainCategoriaImages(string MainCategoria)
        {
            string pathString = Normalization.RemoverAcentuacao(Path.Combine(RootFundoMainCategorias, MainCategoria));

            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);

            return Directory.GetFiles(pathString);
        }

        #endregion Methods
    }
}