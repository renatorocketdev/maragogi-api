using AppMaragogiAPI.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMaragogiAPI.Controllers
{
    public class MainCategoriasController : Controller
    {
        private readonly string TokenSeguranca = "Tr@2020";

        private AppMaragogiDB db = new AppMaragogiDB();

        // GET: MainCategorias
        public ActionResult Index()
        {
            var _context = new SqlConnection(db.Database.Connection.ConnectionString);

            return View(_context.Query<Categorias>($"SELECT DISTINCT MainCategoria FROM Categorias"));
        }

        public ActionResult EditImages(Categorias categorias, HttpPostedFileBase file)
        {
            //Se nenhum arquivo foi enviado, abre a View
            if (file == null)
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<Categorias>($"SELECT * FROM Categorias WHERE MainCategoria = '{categorias.MainCategoria}'").FirstOrDefault());
            else
            {
                if (categorias.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                try
                {
                    var _context = new SqlConnection(db.Database.Connection.ConnectionString);
                    var categoria = _context.Query<Categorias>($"SELECT * FROM Categorias WHERE MainCategoria = '{categorias.MainCategoria}'").FirstOrDefault();

                    var CaminhoBase = Path.Combine(Server.MapPath("~\\Uploads\\FundoCategorias\\"), categorias.MainCategoria);
                    CaminhoBase = Normalization.RemoverAcentuacao(CaminhoBase);

                    if (!Directory.Exists(CaminhoBase))
                        Directory.CreateDirectory(CaminhoBase);

                    var folderInfo = new DirectoryInfo(CaminhoBase);

                    foreach (FileInfo files in folderInfo.GetFiles())
                    {
                        files.Delete();
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = Normalization.RemoverAcentuacao($"{CaminhoBase}/{Request.Files[i].FileName}");
                        Request.Files[i].SaveAs(path);
                    }

                    return RedirectToAction("Index", "MainCategorias");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }
    }
}