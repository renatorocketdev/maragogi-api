using AppMaragogiAPI.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMaragogiAPI.Controllers
{
    public class FundoCategoriasMaragogiController : Controller
    {
        private readonly string TokenSeguranca = "Tr@2020";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditFundoMaragogi(string Token, HttpPostedFileBase file)
        {
            string CaminhoBase = Normalization.RemoverAcentuacao(Server.MapPath("~/Uploads/FundoMaragogi/"));

            if (file == null)
            {
                return View();
            }
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                    {
                        throw new Exception("Token Invalido");
                    }

                    if (!Directory.Exists(CaminhoBase))
                    {
                        Directory.CreateDirectory(CaminhoBase);
                    }

                    var directory = new DirectoryInfo(CaminhoBase);
                    foreach (FileInfo files in directory.GetFiles())
                    {
                        files.Delete();
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = Normalization.RemoverAcentuacao($"{CaminhoBase}/{Request.Files[i].FileName}");
                        Request.Files[i].SaveAs(path);
                    }

                    return RedirectToAction("Panel", "Home");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }

        public ActionResult EditFundoPontoTuristico(string Token, HttpPostedFileBase file)
        {
            string CaminhoBase = Normalization.RemoverAcentuacao(Server.MapPath("~/Uploads/FundoPontoTuristico/"));

            if (file == null)
            {
                return View();
            }
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                    {
                        throw new Exception("Token Invalido");
                    }

                    if (!Directory.Exists(CaminhoBase))
                    {
                        Directory.CreateDirectory(CaminhoBase);
                    }

                    var directory = new DirectoryInfo(CaminhoBase);
                    foreach (FileInfo files in directory.GetFiles())
                    {
                        files.Delete();
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = Normalization.RemoverAcentuacao($"{CaminhoBase}/{Request.Files[i].FileName}");
                        Request.Files[i].SaveAs(path);
                    }

                    return RedirectToAction("Panel", "Home");
                }
                catch (Exception ex)
                {
                    return Json(new { status = "Erro", message = ex.Message });
                }
            }
        }

        public ActionResult EditFundoPraias(string Token, HttpPostedFileBase file)
        {
            string CaminhoBase = Normalization.RemoverAcentuacao(Server.MapPath("~/Uploads/FundoPraias/"));

            if (file == null)
            {
                return View();
            }
            else
            {
                try
                {
                    if (Token != TokenSeguranca)
                    {
                        throw new Exception("Token Invalido");
                    }

                    if (!Directory.Exists(CaminhoBase))
                    {
                        Directory.CreateDirectory(CaminhoBase);
                    }

                    var directory = new DirectoryInfo(CaminhoBase);
                    foreach (FileInfo files in directory.GetFiles())
                    {
                        files.Delete();
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        string path = Normalization.RemoverAcentuacao($"{CaminhoBase}/{Request.Files[i].FileName}");
                        Request.Files[i].SaveAs(path);
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