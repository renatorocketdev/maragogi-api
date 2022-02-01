using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;

namespace AppMaragogiAPI.Controllers
{
    public class APIFotoComentarioController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();
        // GET: api/FotoComentario
        public IEnumerable<FotoComentario> Get(string NomeEmpresa)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<FotoComentario>($"SELECT * FROM FotoComentario WHERE Empresa = '{NomeEmpresa}'");
        }

        [HttpPost]
        public string Post([FromBody] FotoComentario fotoComentario)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                string sql = "INSERT INTO FotoComentario (Comentario, DataComentario, Empresa, Foto, Usuario, Email)" +
                    "VALUES (@Comentario, @DataComentario, @Empresa, @Foto, @Usuario, @Email)";

                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    _context.Execute(sql, fotoComentario);
                }

                return "OK";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
