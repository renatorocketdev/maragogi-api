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
    public class APICategoriasController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();

        // GET: api/APIEmpresa
        public IEnumerable<Categorias> Get()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Categorias>("SELECT * FROM Categorias");
        }

        public IEnumerable<Categorias> GetBySubCategoria(string SubCategoria)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Categorias>($"SELECT * FROM Categorias WHERE SubCategoria LIKE '%{SubCategoria}%'");
        }

        public IEnumerable<Categorias> GetByMainCategoria(string MainCategoria)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Categorias>($"SELECT * FROM Categorias WHERE MainCategoria LIKE '%{MainCategoria}%'");
        }
    }
}
