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
    public class APIEmpresaController : ApiController
    {
        AppMaragogiDB db = new AppMaragogiDB();

        // GET: api/APIEmpresa
        public IEnumerable<Empresa> Get()
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Empresa>("SELECT * FROM Empresa");
        }

        // GET: api/APIEmpresa/5
        public IEnumerable<Empresa> Get(int IdEmpresa)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Empresa>($"SELECT * FROM Empresa WHERE IdEmpresa={IdEmpresa}");
        }

        public IEnumerable<Empresa> Get(string NomeEmpresa)
        {
            try
            {
                using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                    return _context.Query<Empresa>($"SELECT * FROM Empresa WHERE NomeEmpresa LIKE '%{NomeEmpresa}%'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Empresa> GetBySubCategoria(string SubCategoria)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Empresa>($"SELECT * FROM Empresa WHERE SubCategoria LIKE '%{SubCategoria}%'");
        }

        public IEnumerable<Empresa> GetByMainCategoria(string MainCategoria)
        {
            using (SqlConnection _context = new SqlConnection(db.Database.Connection.ConnectionString))
                return _context.Query<Empresa>($"SELECT * FROM Empresa WHERE MainCategoria LIKE '%{MainCategoria}%'");
        }
    }
}
