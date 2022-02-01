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
    public class HistoriaMaragogiController : Controller
    {
        #region Fields

        private readonly string TokenSeguranca = "Tr@2020";
        private AppMaragogiDB db = new AppMaragogiDB();

        #endregion Fields

        #region Methods

        // POST: HistoriaMaragogi/Edit/5
        [HttpPost]
        public ActionResult Edit(HistoriaMaragogi historiaMaragogi)
        {
            string cmd = System.IO.File.ReadAllText(Server.MapPath("~/SQL/UpdateHistoria.sql"));

            try
            {
                if (historiaMaragogi.Token != TokenSeguranca)
                    throw new Exception("Token Invalido");

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    _context.Query<HistoriaMaragogi>(cmd, historiaMaragogi);

                return RedirectToAction("Panel", "Home");
            }
            catch (Exception ex)
            {
                return Json(new { status = "Erro", message = ex.Message });
            }
        }

        // GET: HistoriaMaragogi/Edit/5
        public ActionResult Edit()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return View(_context.Query<HistoriaMaragogi>($"SELECT * FROM HistoriaMaragogi").FirstOrDefault());
        }

        public ActionResult EditImages(string Token, HttpPostedFileBase file)
        {
            if (file == null)
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return View(_context.Query<HistoriaMaragogi>($"SELECT * FROM HistoriaMaragogi").FirstOrDefault());
            else
            {
                try
                {
                    //Verifica o Token e retorna erro caso invalido impedindo a execução do resto do código
                    if (Token != TokenSeguranca)
                        throw new Exception("Token Invalido");

                    //Uma instância de HistoriaMaragogi para preencher
                    HistoriaMaragogi HistoriaMaragogi = new HistoriaMaragogi();

                    //Consulta no banco para trazer infomações sobre HistoriaMaragogi
                    using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    {
                        HistoriaMaragogi = _context.Query<HistoriaMaragogi>($"SELECT * FROM HistoriaMaragogi").FirstOrDefault();
                    }

                    //Setando o caminho das imagens
                    string CaminhoBase = Server.MapPath("~/Uploads/FundoHistoria/");

                    //Pegando informações sobre a pasta
                    DirectoryInfo folderInfo = new DirectoryInfo(CaminhoBase);

                    //Deletando os arquivos existentes
                    foreach (FileInfo files in folderInfo.GetFiles())
                    {
                        files.Delete();
                    }

                    //Salvando os arquivos baseadi na quantidade de arquivos enviados
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = Normalization.RemoverAcentuacao($"{CaminhoBase}/{Request.Files[i].FileName}");
                        Request.Files[i].SaveAs(path);
                    }

                    //Refireciona para Home/Panel
                    return RedirectToAction("Panel", "Home");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }

        #endregion Methods
    }
}