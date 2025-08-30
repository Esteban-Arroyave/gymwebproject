using Dapper;
using gymwebproject.Models;
using System.Data.SqlClient;
using System.Data;

namespace gymwebproject.Repositorio
{

    public interface IRepopasarela
    {
        Task<bool> compraP(compraPmodel pasarela);

        IEnumerable<compraPmodel> ListarCompra();

        compraPmodel BuscarPorId(int id);

        Task<bool> Actualizar(int id, string estado);
    }

    public class Repopasarela : IRepopasarela
    {
        private readonly string cnx;

        public Repopasarela(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> compraP(compraPmodel pasarela)
        {
            bool IsSuccess = false;
            try
            {
                using (var connection = new SqlConnection(cnx))
                {
                    IsSuccess = await connection.ExecuteAsync(
                        @"INSERT INTO registroC (nombre, correo, suscripcion, precio, Metodo, tarjeta, estado, FechaCompra)
                      VALUES (@nombre, @correo, @suscripcion, @precio, @Metodo, @tarjeta, @estado, @FechaCompra)",
                        pasarela) > 0;
                }
            }
            catch (Exception ex)
            {

            }

            return IsSuccess;
        }


        //enlistar compra

        public IEnumerable<compraPmodel> ListarCompra()
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = @"
            SELECT * 
            FROM registroC
            WHERE nombre IS NOT NULL
              AND correo IS NOT NULL
              AND suscripcion IS NOT NULL
              AND metodo IS NOT NULL
              AND tarjeta IS NOT NULL
              AND estado IS NOT NULL
              AND FechaCompra IS NOT NULL";

                return db.Query<compraPmodel>(sqlQuery).ToList();
            }
        }

        public compraPmodel BuscarPorId(int id)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sql = "SELECT * FROM registroC WHERE id = @Id";
                return db.QueryFirstOrDefault<compraPmodel>(sql, new { Id = id });
            }
        }

        // 👇 NUEVO: actualizar datos de la compra
        public async Task<bool> Actualizar(int id, string estado)
{
    using (var connection = new SqlConnection(cnx))
    {
        string sql = @"
        UPDATE registroC
        SET estado = @estado
        WHERE Id = @id";

        return await connection.ExecuteAsync(sql, new { id, estado }) > 0;
    }
}




    }

}





















