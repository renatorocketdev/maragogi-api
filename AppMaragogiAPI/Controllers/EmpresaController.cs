using AppMaragogiAPI.Utils;
using Dapper;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMaragogiAPI.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly string TokenSeguranca = "Tr@2020";

        private AppMaragogiDB db = new AppMaragogiDB();

        // GET: Empresa
        public ActionResult Index(Empresa empresa)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                ViewBag.MainCategoria = _context.Query<string>("SELECT DISTINCT MainCategoria FROM Categorias");
                ViewBag.SubCategoria = _context.Query<string>("SELECT SubCategoria FROM Categorias");
            }

            try
            {
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    var sql = "SELECT * FROM Empresa";

                    if (empresa.NomeEmpresa != null)
                    {
                        sql = $"SELECT * FROM Empresa WHERE NomeEmpresa LIKE CONCAT ('%', @NomeEmpresa, '%')";
                    }
                    else if(empresa.SubCategoria != null)
                    {
                        sql = $"SELECT * FROM Empresa WHERE SubCategoria LIKE CONCAT ('%', @SubCategoria, '%')";
                    }
                    else if (empresa.NomeEmpresa != null && empresa.SubCategoria != null)
                    {
                        sql = $"SELECT * FROM Empresa WHERE NomeEmpresa LIKE CONCAT ('%', @NomeEmpresa, '%') AND SubCategoria LIKE CONCAT ('%', @SubCategoria, '%')";
                    }

                    ViewBag.Empresas = _context.Query<Empresa>(sql, empresa);
                }

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Panel", "Home");
            }
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Add(Empresa empresa)
        {
            if (empresa.Token != TokenSeguranca)
                throw new Exception("Token Invalido");

            try
            {
                //Define a pasta das imagens
                var EmpresaPath = Path.Combine(Server.MapPath("~/Uploads/Empresas/"), empresa.SubCategoria.Trim(), empresa.NomeEmpresa.Trim());
                EmpresaPath = Normalization.RemoverAcentuacao(EmpresaPath);
                //Cria a pasta da Empresa
                if (!Directory.Exists(EmpresaPath))
                    Directory.CreateDirectory(EmpresaPath);

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/InsertEmpresa.sql"));
                    _context.Query<Empresa>(cmd, empresa);
                }

                return RedirectToAction("Index", "Empresa");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: Empresa/Create
        public ActionResult Add()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                ViewBag.MainCategoria = _context.Query<Categorias>("SELECT DISTINCT MainCategoria FROM Categorias");
                ViewBag.SubCategoria = _context.Query<Categorias>("SELECT SubCategoria FROM Categorias");
            }

            return View();
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit(Empresa empresa)
        {
            //Verifica Token
            if (empresa.Token != TokenSeguranca)
                throw new Exception("Token Invalido");

            try
            {
                //Verificar se houve mudança na categoria
                if (empresa.SubCategoria != empresa.OldSubCategoria || empresa.NomeEmpresa != empresa.OldName)
                {
                    //Caminho com categoria
                    var Arquivos = Path.Combine(Server.MapPath("~/Uploads/Empresas/"), empresa.OldSubCategoria.Trim(), empresa.OldName.Trim());
                    Arquivos = Normalization.RemoverAcentuacao(Arquivos);

                    //Novo caminho categoria
                    var NovoCaminho = Path.Combine(Server.MapPath("~/Uploads/Empresas/"), empresa.SubCategoria.Trim(), empresa.NomeEmpresa.Trim());
                    NovoCaminho = Normalization.RemoverAcentuacao(NovoCaminho);

                    if (!Directory.Exists(Arquivos))
                        Directory.CreateDirectory(Arquivos);

                    if (!Directory.Exists(NovoCaminho))
                        Directory.CreateDirectory(NovoCaminho);

                    //Pega os arquivos
                    var files = Directory.GetFiles(NovoCaminho);

                    if (files == null)
                    {
                        //Move arquivos para novo caminho
                        foreach (string item in files)
                        {
                            var path = Normalization.RemoverAcentuacao(Path.GetFileName(item));
                            System.IO.File.Copy(item, path, true);
                        }
                    }
                }

                //Apenas Update de informações
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/UpdateEmpresa.sql"));
                    _context.Query<Empresa>(cmd, empresa);

                    string cmdUpdateGaleriaUsuarios = $"UPDATE FotoComentario SET Empresa='{empresa.NomeEmpresa.Trim()}' WHERE Empresa='{empresa.OldName.Trim()}'";
                    _context.Query<FotoComentario>(cmdUpdateGaleriaUsuarios);
                }

                return RedirectToAction("Index", "Empresa");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message + ". (Contate o Administrador)" });
            }
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                ViewBag.MainCategoria = _context.Query<Categorias>("SELECT DISTINCT MainCategoria FROM Categorias");
                ViewBag.SubCategoria = _context.Query<Categorias>("SELECT SubCategoria FROM Categorias");

                return View(_context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa = {id}").FirstOrDefault());
            }
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        public ActionResult Delete(Empresa empresa)
        {
            try
            {
                if (empresa.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    _context.Query<Empresa>($"DELETE FROM Empresa WHERE IdEmpresa={empresa.IdEmpresa}");
                }

                return RedirectToAction("Index", "Empresa");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa = {id}").FirstOrDefault());
        }

        public ActionResult EditIcon(int id, string Token, HttpPostedFileBase file)
        {
            if (file == null)
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa = {id}").FirstOrDefault());
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                        throw new Exception("Token Invalido");

                    BinaryReader reader = new BinaryReader(file.InputStream);
                    byte[] attachmentBinary = reader.ReadBytes((int)file.ContentLength);

                    string cmd = $"UPDATE Empresa SET Icone=@Icone WHERE IdEmpresa={id}";

                    using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    {
                        _context.Query<Empresa>(cmd, new { Icone = attachmentBinary });
                    }

                    return RedirectToAction("Index", "Empresa");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }

        public ActionResult EditImages(int id, string Token, HttpPostedFileBase file)
        {
            //Se nenhum arquivo foi enviado, vai abri a View
            if (file == null)
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa = {id}").FirstOrDefault());
            else
            {
                if (Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                try
                {
                    var _context = new SqlConnection(db.Database.Connection.ConnectionString);
                    var empresa = _context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa = {id}").FirstOrDefault();

                    var CaminhoBase = Path.Combine(Server.MapPath("~\\Uploads\\Empresas\\"), empresa.SubCategoria.Trim(), empresa.NomeEmpresa.Trim());
                    CaminhoBase = Normalization.RemoverAcentuacao(CaminhoBase);

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

                    return RedirectToAction("Index", "Empresa");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }
    }
}