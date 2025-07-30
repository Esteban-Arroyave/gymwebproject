using Dapper;
using Microsoft.Data.SqlClient;
using gymwebproject.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using gymwebproject.Controllers;

namespace gymwebproject.Repositorio
{
    public interface IRepogestion
    {
        Task<bool> gestion(gestionmodel gestion);
        Task<bool> ActualizarPrecios( gestionmodel precio);
    }


    public class Repogestion:IRepogestion
    {
        private readonly IRepogestion _repo;
        private readonly string cnx;
        public Repogestion(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<bool> gestion(gestionmodel gestion)
        {
            bool IsInserted = false;
            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync(
                    @"INSERT INTO suscripciones (oro,plata,bronce)
                        VALUES (@oro,@plata,@bronce)", gestion) > 0;



            }
            catch (Exception ex) { }
            return IsInserted;



        }




        public async Task<bool> ActualizarPrecios( gestionmodel  precio)
        {
            bool isUpdated = false;
            try
            {
                var connection = new SqlConnection(cnx);
                var query = @"
                UPDATE suscripciones
                SET oro = @oro,plata = @plata,bronce = @bronce
                 "; 

                var parametros = new { precio };
                var result = await connection.ExecuteAsync(query, precio);

                
            }
            catch (Exception)
            {
              
            }

            return isUpdated;
        }
    }




}

