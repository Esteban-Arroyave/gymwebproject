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

        Task<List<compraPmodel>> ListarComprasPorCorreo(string correo);


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

        //nuevo
        public async Task<List<compraPmodel>> ListarComprasPorCorreo(string correo)
        {
            var compras = new List<compraPmodel>();

            using (var connection = new SqlConnection(cnx))
            {
                string sql = @"SELECT Id, nombre, correo, suscripcion, precio, metodo, numero, tarjeta, estado, FechaCompra 
                       FROM registroC 
                       WHERE correo = @correo";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            compras.Add(new compraPmodel
                            {
                                Id = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                correo = reader.GetString(2),
                                suscripcion = reader.GetString(3),

                                // 👇 conversión segura para precio
                                precio = decimal.TryParse(reader["precio"].ToString(), out var precioDecimal)
                                         ? precioDecimal
                                         : 0,

                                metodo = reader.GetString(5),

                                // 👇 si "numero" también es texto en tu BD (varchar), cambia esto a string
                                numero = decimal.TryParse(reader["numero"].ToString(), out var numeroDecimal)
                                         ? numeroDecimal
                                         : 0,

                                tarjeta = reader.GetString(7),
                                estado = reader.GetString(8),
                                FechaCompra = reader.GetDateTime(9)
                            });
                        }

                    }
                }
            }
            return compras;
        }


    }
}
