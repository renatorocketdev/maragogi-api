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
    public class APICategoriasMaragogiController : ApiController
    {
        private AppMaragogiDB db = new AppMaragogiDB();

        // GET: api/APICategoriasMaragogi
        public IEnumerable<CategoriasMaragogi> Get(string categoria = "Outros")
        {
            var sql = $"SELECT * FROM CategoriasMaragogi WHERE Categoria = '{categoria}'";

            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                return _context.Query<CategoriasMaragogi>(sql);
            }
        }
    }
}