using AppMaragogiAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIAvaliacaoController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();

        [HttpPost]
        public string Post([FromBody] AvaliacaoEmpresa avaliacao)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using (var _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    var cmdEmpresa = $"SELECT * FROM Empresa WHERE IdEmpresa = ${avaliacao.id}";
                    var empresa = _context.Query<Empresa>(cmdEmpresa).FirstOrDefault();

                    var nota = Convert.ToDouble(empresa.Nota) + avaliacao.Nota;
                    var media = nota / (empresa.QtdVotos + 1);
                    var votos = empresa.QtdVotos + 1;

                    var sql = $"UPDATE Empresa SET QtdVotos = ${votos}, Nota = ${nota} WHERE IdEmpresa = ${empresa.IdEmpresa}; ";

                    _context.Execute(sql);
                }

                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
