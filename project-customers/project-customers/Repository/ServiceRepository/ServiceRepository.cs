using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using project_customers.Models;
using Dapper;
using MySqlConnector;

namespace project_customers.Repository.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ClientesModel> CreateCliente(ClientesModel cliente)
        {
            using (var con = new MySqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Cliente 
                            (RazaoSocial, Email, Telefone, DataCadastro, StatusCliente, Pessoa, CpfCnpj, InscricaoEstadual, Insento, Genero, DataNascimento, Senha, SenhaConfirmar) 
                            VALUES 
                            (@RazaoSocial, @Email, @Telefone, @DataCadastro, @StatusCliente, @Pessoa, @CpfCnpj, @InscricaoEstadual, @Insento, @Genero, @DataNascimento, @Senha, @SenhaConfirmar);
                            SELECT LAST_INSERT_ID();";

                var insertedId = await con.ExecuteScalarAsync<int>(sql, cliente);

                var insertedCliente = await con.QuerySingleOrDefaultAsync<ClientesModel>("SELECT * FROM Cliente WHERE Id = @Id", new { Id = insertedId });

                return insertedCliente;
            }
        }

        public async Task<List<ClientesModel>> GetClientes()
        {
            using (var con = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Cliente";
                var returno = await con.QueryAsync<ClientesModel>(sql);
                return returno.AsList();
            }
        }

        public async Task<List<ClientesModel>> GetClienteByFilter(ClientesModel cliente)
        {
            string sql = "SELECT * FROM Cliente WHERE 1 = 1";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(cliente.RazaoSocial))
            {
                sql += " AND RazaoSocial = @RazaoSocial";
                parameters.Add("@RazaoSocial", cliente.RazaoSocial);
            }

            if (!string.IsNullOrEmpty(cliente.Email))
            {
                sql += " AND Email = @Email";
                parameters.Add("@Email", cliente.Email);
            }

            if (!string.IsNullOrEmpty(cliente.Telefone))
            {
                sql += " AND Telefone = @Telefone";
                parameters.Add("@Telefone", cliente.Telefone);
            }

            if (cliente.DataCadastro != DateTime.MinValue)
            {
                sql += " AND DataCadastro = @DataCadastro";
                parameters.Add("@DataCadastro", cliente.DataCadastro);
            }

            if (cliente.StatusCliente != null)
            {
                sql += " AND StatusCliente = @StatusCliente";
                parameters.Add("@StatusCliente", cliente.StatusCliente);
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                var clientes = await connection.QueryAsync<ClientesModel>(sql, parameters);
                return clientes.ToList();
            }
        }

        public Task<ClientesModel> UpdateCliente(ClientesModel cliente)
        {
            throw new NotImplementedException();
        }
        public async Task<ClientesModel> ValidateCreateCliente(ClientesModel cliente)
        {
            string sql = "SELECT * FROM Cliente WHERE 1 = 1";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(cliente.CpfCnpj))
            {
                sql += " AND CpfCnpj = @CpfCnpj";
                parameters.Add("@CpfCnpj", cliente.CpfCnpj);
            }

            if (!string.IsNullOrEmpty(cliente.Email))
            {
                sql += " AND Email = @Email";
                parameters.Add("@Email", cliente.Email);
            }
            if (!string.IsNullOrEmpty(cliente.InscricaoEstadual.ToString()))
            {
                sql += " AND InscricaoEstadual = @InscricaoEstadual";
                parameters.Add("@InscricaoEstadual", cliente.InscricaoEstadual);
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                var clientes = await connection.QueryAsync<ClientesModel>(sql, parameters);
                return clientes.FirstOrDefault();
            }
        }

        public async Task<ClientesModel> GetClienteByID(int clienteid)
        {
            using (var con = new MySqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM Cliente where id = @Id";
                var returno = await con.QueryAsync<ClientesModel>(sql, clienteid);
                return returno.FirstOrDefault();
            }
        }
    }
}
