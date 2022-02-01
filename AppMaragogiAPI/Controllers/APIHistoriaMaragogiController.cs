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
    public class APIHistoriaMaragogiController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();
        // GET: api/APIHistoriaMaragogi
        public IEnumerable<HistoriaMaragogi> Get()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<HistoriaMaragogi>("SELECT * FROM HistoriaMaragogi");
        }
    }
}
