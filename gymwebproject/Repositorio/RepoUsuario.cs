using Dapper;
using Microsoft.Data.SqlClient;
using gymwebproject.Models;



namespace gymwebproject.Repositorio
{
    public interface IRepoUsuario
    {
        Task<bool> RegistroUsuario(RegistrarseModel usuario);

        Task<bool> ValidarUsuario(login usuario);

        Task<RegistrarseModel> ObtenerUsuarioPorCorreo(string correo);


    }

    public class RepoUsuario : IRepoUsuario
    {
        private readonly string cnx;
        public RepoUsuario(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<RegistrarseModel> ObtenerUsuarioPorCorreo(string correo)
        {
            using var connection = new SqlConnection(cnx);

            string query = @"SELECT * FROM registro WHERE correo = @correo";

            return await connection.QueryFirstOrDefaultAsync<RegistrarseModel>(query, new { correo });
        }


        public async Task<bool> RegistroUsuario(RegistrarseModel usuario)
        {
            bool IsInserted = false;
            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync(
                    @"INSERT INTO registro (nombre, apellido,correo,contraseña,Tiposexo, rol)
                        VALUES (@nombre, @apellido,@correo,@contraseña, @Tiposexo, @rol)", usuario) > 0;
            
                    

            }
            catch (Exception ex) { }
            return IsInserted;



        }

        public async Task<bool> ValidarUsuario(login informacion)
        {
            using var connection = new SqlConnection(cnx);
            string query = @"SELECT COUNT(1) FROM Registro WHERE  correo = @correo AND contraseña = @contraseña";
            bool usuarioExitente = await connection.ExecuteScalarAsync<int>(query, new { informacion.correo, informacion.contraseña }) > 0;
            return usuarioExitente;
        }

    }
}
