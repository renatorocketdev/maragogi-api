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
    public class CategoriasMaragogiController : Controller
    {
        private readonly string TokenSeguranca = "Tr@2020";
        private AppMaragogiDB db = new AppMaragogiDB();

        // GET: CategoriasMaragogi
        public ActionResult Index(CategoriasMaragogi categoriasMaragogi)
        {
            try
            {
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    ViewBag.Categorias = _context.Query<CategoriasMaragogi>("SELECT * FROM CategoriasMaragogi", categoriasMaragogi);
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Panel", "Home");
            }
        }

        // POST: CategoriasMaragogi/Create
        [HttpPost]
        public ActionResult Add(CategoriasMaragogi categoriasMaragogi, HttpPostedFileBase file = null)
        {
            string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/InsertCategoriasMaragogi.sql"));

            if (file == null)
            {
                return Json(new { status = "Erro", message = "Adicione um icone" });
            }
            else
            {
                BinaryReader reader = new BinaryReader(file.InputStream);
                categoriasMaragogi.Icone = reader.ReadBytes((int)file.ContentLength);
            }

            try
            {
                if (categoriasMaragogi.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    _context.Query<CategoriasMaragogi>(cmd, categoriasMaragogi);
                }

                return RedirectToAction("Index", "CategoriasMaragogi");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: CategoriasMaragogi/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CategoriasMaragogi/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoriasMaragogi categoriasMaragogi, HttpPostedFileBase file = null)
        {
            string CaminhoBase = Server.MapPath("~/Uploads/CategoriasMaragogi/");

            string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/UpdateCategoriasMaragogi.sql"));

            if (file != null)
            {
                BinaryReader reader = new BinaryReader(file.InputStream);
                categoriasMaragogi.Icone = reader.ReadBytes((int)file.ContentLength);
            }

            try
            {
                if (categoriasMaragogi.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                if (categoriasMaragogi.Nome != categoriasMaragogi.OldName)
                {
                    var Arquivos = Normalization.RemoverAcentuacao(Path.Combine(CaminhoBase, categoriasMaragogi.OldName.Trim()));
                    var NovoCaminho = Normalization.RemoverAcentuacao(Path.Combine(CaminhoBase, categoriasMaragogi.Nome.Trim()));

                    if (!Directory.Exists(Arquivos))
                        Directory.CreateDirectory(Arquivos);

                    if (!Directory.Exists(NovoCaminho))
                        Directory.CreateDirectory(NovoCaminho);

                    var files = Directory.GetFiles(Arquivos);

                    foreach (string s in files)
                    {
                        string fileName = Path.GetFileName(s);
                        fileName.Replace(categoriasMaragogi.Nome.Trim(), categoriasMaragogi.OldName.Trim());

                        string path = NovoCaminho + "/" + fileName;

                        System.IO.File.Copy(s, Normalization.RemoverAcentuacao(path), true);
                    }
                }

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    _context.Query<CategoriasMaragogi>(cmd, categoriasMaragogi);

                return RedirectToAction("Index", "CategoriasMaragogi");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: CategoriasMaragogi/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                ViewBag.Categorias = _context.Query<CategoriasMaragogi>("SELECT Categoria FROM CategoriasMaragogi WHERE Icone IS NULL AND Categoria != 'História'");
            }

            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<CategoriasMaragogi>($"SELECT * FROM CategoriasMaragogi WHERE CategoriaMaragogiId = {id}").FirstOrDefault());
        }

        // POST: CategoriasMaragogi/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoriasMaragogi categoriasMaragogi)
        {
            try
            {
                if (categoriasMaragogi.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    _context.Query<CategoriasMaragogi>($"DELETE FROM CategoriasMaragogi WHERE CategoriaMaragogiId={categoriasMaragogi.CategoriaMaragogiId}");

                return RedirectToAction("Index", "CategoriasMaragogi");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: CategoriasMaragogi/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<CategoriasMaragogi>($"SELECT * FROM CategoriasMaragogi WHERE CategoriaMaragogiId = {id}").FirstOrDefault());
        }

        public ActionResult EditImages(int id, string Token, HttpPostedFileBase file)
        {
            if (file == null)
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<CategoriasMaragogi>($"SELECT * FROM CategoriasMaragogi WHERE CategoriaMaragogiId = {id}").FirstOrDefault());
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                        throw new Exception("Token Invalido");

                    var _context = new SqlConnection(db.Database.Connection.ConnectionString);

                    var CategoriasMaragogi = _context.Query<CategoriasMaragogi>($"SELECT * FROM CategoriasMaragogi WHERE CategoriaMaragogiId = {id}").FirstOrDefault();

                    string CaminhoBase = Server.MapPath("~/Uploads/CategoriasMaragogi/");
                    CaminhoBase = Normalization.RemoverAcentuacao(Path.Combine(CaminhoBase, CategoriasMaragogi.Nome));

                    if (!Directory.Exists(CaminhoBase))
                        Directory.CreateDirectory(CaminhoBase);

                    var folderInfo = new DirectoryInfo(CaminhoBase);

                    foreach (FileInfo files in folderInfo.GetFiles())
                    {
                        files.Delete();
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = $"{CaminhoBase}/{Request.Files[i].FileName}";
                        Request.Files[i].SaveAs(Normalization.RemoverAcentuacao(path));
                    }

                    return RedirectToAction("Index", "CategoriasMaragogi");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }
    }
}