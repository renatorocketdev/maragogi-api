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
    public class APIPraiasController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();
        // GET: api/APILugaresMaragogi
        public IEnumerable<Praias> Get()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Praias>("SELECT * FROM Praias");
        }
    }
}
