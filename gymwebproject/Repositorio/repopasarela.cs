using Dapper;
using gymwebproject.Models;
using System.Data.SqlClient;

namespace gymwebproject.Repositorio
{

   public interface IRepopasarela
    {

        Task<bool>compraP(compraPmodel pasarela);


    }


    public class repopasarela : IRepopasarela
    {


        private readonly string cnx;
        public repopasarela(IConfiguration configuration)
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
                    @"INSERT INTO registro (nombre, apellido,correo,contraseña,Tiposexo, rol, tipocc, cedula, telefono)
                        VALUES (@nombre, @apellido,@correo,@contraseña, @Tiposexo, @rol,  @tipocc, @cedula, @telefono)", usuario) > 0;



            }
            catch (Exception ex) { }
            return IsInserted;



        }





    }





















}