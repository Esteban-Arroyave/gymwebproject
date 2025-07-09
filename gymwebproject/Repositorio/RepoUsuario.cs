using Dapper;
using Microsoft.Data.SqlClient;
using gymwebproject.Models;



namespace gymwebproject.Repositorio
{
    public interface IRepoUsuario
    {
        Task<bool> RegistroUsuario(RegistrarseModel usuario);



    }



    public class RepoUsuario : IRepoUsuario
    {
        private readonly string cnx;
        public RepoUsuario(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<bool> RegistroUsuario(RegistrarseModel usuario)
        {
            bool IsInserted = false;
            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync(
                    @"INSERT INTO registro (nombre,correo,contraseña)
                        VALUES (@nombre,@correo,@contraseña)", usuario) > 0;
            
                    

            }
            catch (Exception ex) { }
            return IsInserted;



        }

    }
}
