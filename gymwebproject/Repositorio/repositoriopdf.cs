using gymwebproject.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace gymwebproject.Repositorio
{
    
        public interface Irepositoriopdf
        {
            List<RegistrarseModel> Invetariopdf(RegistrarseModel pdflclientes);
            List<gestionmodel> suscripcionespdf(gestionmodel pdfgestion);
            List<compraPmodel> registroC(compraPmodel pagopdf);
        }
        public class repositoriopdf : Irepositoriopdf
        {
            private readonly IConfiguration configuration;
            private readonly string cnx;
            public repositoriopdf(IConfiguration configuration)
            {

                cnx = configuration.GetConnectionString("DefaultConnection");
            }
            public List<RegistrarseModel> Invetariopdf(RegistrarseModel pdfclientes)
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT * FROM registro";
                using var gernerarpdf = new SqlConnection(connectionString);
                var pdf = connection.Query<RegistrarseModel>(query).ToList();
                return pdf;
            }

        public List<gestionmodel> suscripcionespdf(gestionmodel pdfgestion)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(cnx);
            var query = "SELECT * FROM suscripciones";
            using var gernerarpdf = new SqlConnection(connectionString);
            var repdf = connection.Query<gestionmodel>(query).ToList();
            return repdf;
        }

        public List<compraPmodel> registroC(compraPmodel pagopdf)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(cnx);
            var query = "SELECT * FROM registroC";
            using var gernerarpdf = new SqlConnection(connectionString);
            var pdf1 = connection.Query<compraPmodel>(query).ToList();
            return pdf1;
        }








    }
}
