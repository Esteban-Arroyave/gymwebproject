using Dapper;
using gymwebproject.Models;
using System.Data.SqlClient;

namespace gymwebproject.Repositorio
{

  public interface IRepopasarela
{
    Task<bool> compraP(compraPmodel pasarela);
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
                        @"INSERT INTO registroC (nombre, correo, suscripcion, precio, Metodo, numero, tarjeta)
                      VALUES (@nombre, @correo, @suscripcion, @precio, @Metodo, @numero, @tarjeta)",
                        pasarela) > 0;
                }
            }
            catch (Exception ex)
            {
                
            }

            return IsSuccess;
        }

      
}





    }





















