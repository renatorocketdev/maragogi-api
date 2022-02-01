using AppMaragogiAPI.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace AppMaragogiAPI.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly string TokenSeguranca = "Tr@2020";
        private AppMaragogiDB db = new AppMaragogiDB();

        // GET: Categorias
        public ActionResult Index(Categorias categorias)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                ViewBag.MainCategoria = _context.Query<string>("SELECT DISTINCT MainCategoria FROM Categorias");

            try
            {
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    var sql = "SELECT * FROM Categorias WHERE MainCategoria LIKE CONCAT ('%', @MainCategoria, '%') AND SubCategoria LIKE CONCAT ('%', @SubCategoria, '%')";
                    ViewBag.Categorias = _context.Query<Categorias>(sql, categorias);
                }

                return View();
            }
            catch
            {
                return RedirectToAction("Panel", "Home");
            }
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Add(Categorias categorias)
        {
            string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/InsertCategoria.sql"));

            try
            {
                if (categorias.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    _context.Query<Categorias>(cmd, categorias);

                return RedirectToAction("Index", "Empresa");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: Categorias/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(Categorias categorias)
        {
            string CaminhoBase = Server.MapPath("~/Uploads/Categorias/");

            string cmdEmpresa = $"UPDATE Empresa SET SubCategoria = @SubCategoria WHERE SubCategoria = @OldName";
            string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/UpdateCategoria.sql"));

            try
            {
                if (categorias.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                if (categorias.SubCategoria != categorias.OldName)
                {
                    var Arquivos = Normalization.RemoverAcentuacao(Path.Combine(CaminhoBase, categorias.OldName.Trim()));
                    var NovoCaminho = Normalization.RemoverAcentuacao(Path.Combine(CaminhoBase, categorias.SubCategoria.Trim()));

                    if (!Directory.Exists(Arquivos))
                        Directory.CreateDirectory(Arquivos);

                    if (!Directory.Exists(NovoCaminho))
                        Directory.CreateDirectory(NovoCaminho);

                    var files = Directory.GetFiles(Arquivos);

                    foreach (string s in files)
                    {
                        string fileName = Path.GetFileName(s);
                        fileName.Replace(categorias.SubCategoria.Trim(), categorias.OldName.Trim());

                        string path = NovoCaminho + "/" + fileName;

                        System.IO.File.Copy(s, Normalization.RemoverAcentuacao(path), true);
                    }
                }

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    _context.Query<Empresa>(cmdEmpresa, categorias);
                    _context.Query<Categorias>(cmd, categorias);
                }

                return RedirectToAction("Index", "Categorias");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<Categorias>($"SELECT * FROM Categorias WHERE CategoriaId = {id}").FirstOrDefault());
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(Categorias categorias)
        {
            try
            {
                if (categorias.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    _context.Query<Categorias>($"DELETE FROM Categorias WHERE CategoriaId={categorias.CategoriaId}");

                return RedirectToAction("Index", "Empresa");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<Categorias>($"SELECT * FROM Categorias WHERE CategoriaId = {id}").FirstOrDefault());
        }

        public ActionResult EditIcon(int id, string Token, HttpPostedFileBase file)
        {
            if (file == null || string.IsNullOrEmpty(Token))
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<Categorias>($"SELECT * FROM Categorias WHERE CategoriaId = {id}").FirstOrDefault());
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                        throw new Exception("Token Invalido");

                    BinaryReader reader = new BinaryReader(file.InputStream);
                    byte[] attachmentBinary = reader.ReadBytes((int)file.ContentLength);

                    string cmd = $"UPDATE Categorias SET Icone=@Icone WHERE CategoriaId={id}";

                    using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                        _context.Query<Categorias>(cmd, new { Icone = attachmentBinary });

                    return RedirectToAction("Panel", "Home");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }

        public ActionResult EditImages(int id, string Token, HttpPostedFileBase file)
        {
            if (file == null || string.IsNullOrEmpty(Token))
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<Categorias>($"SELECT * FROM Categorias WHERE CategoriaId = {id}").FirstOrDefault());
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                        throw new Exception("Token Invalido");

                    SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString);

                    Categorias categorias = _context.Query<Categorias>($"SELECT * FROM Categorias WHERE CategoriaId = @id", new { id }).FirstOrDefault();

                    string CaminhoBase = Server.MapPath("~/Uploads/Categorias/");
                    CaminhoBase = Path.Combine(CaminhoBase, categorias.SubCategoria.Trim());

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

                    return RedirectToAction("Panel", "Home");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }
    }
}