using DesafioBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DesafioBackend.Controllers
{
    [Route("api/[Controller]/")]
    public class HomeController : ControllerBase
    {

        //Configuraçao
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration config)
        {
            _configuration = config;
        }

        //
        //String de Conexao Local 
        //
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DesafioBackend\BD\DataBase.mdf;Integrated Security=True;Connect Timeout=30";


        // Lista de Empresas p/ Retornos
        List<Empresas> listEmpresa = new List<Empresas>();

        //lista a ser inserida dento de (Lista Empresas)
        List<Empresas> empresa = new List<Empresas>();

        //Lista de Tarefas para Retornos
        List<Tarefas> listTarefas = new List<Tarefas>();

        //Lista a ser inserida dentro de (Lista Tarefas)
        List<Tarefas> tarefas = new List<Tarefas>();


        //GET: api/Home/Empresas
        [Route("Empresas")]
        [HttpGet]
        public IActionResult GetAllEmpresas()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @" Select IdEmpresa, Nome, Senha, Email, Cnpj from Empresas ";
                            SqlDataReader reader = comm.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Empresas empresa = new Empresas()
                                    {
                                        IdEmpresa = reader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmpresa"].ToString()),
                                        Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString(),
                                        Senha = reader["Senha"] == DBNull.Value ? string.Empty : reader["Senha"].ToString(),
                                        Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                                        Cnpj = reader["Cnpj"] == DBNull.Value ? string.Empty : reader["Cnpj"].ToString()
                                    };

                                    listEmpresa.Add(empresa);
                                }
                            }

                            con.Close();
                        }

                    }
                    return Ok(listEmpresa.ToArray());
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        //GET : api/Home/Empresas/{id}
        [HttpGet]
        [Route("Empresas/{id:int}")]
        public IActionResult GetEmpresasById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @" Select IdEmpresa, Nome, Senha, Email, Cnpj from Empresas where IdEmpresa = @id ";
                            comm.Parameters.AddWithValue("id", id);
                            SqlDataReader reader = comm.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Empresas empresa = new Empresas()
                                    {
                                        IdEmpresa = reader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmpresa"].ToString()),
                                        Nome = reader["Nome"] == DBNull.Value ? string.Empty : reader["Nome"].ToString(),
                                        Senha = reader["Senha"] == DBNull.Value ? string.Empty : reader["Senha"].ToString(),
                                        Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                                        Cnpj = reader["Cnpj"] == DBNull.Value ? string.Empty : reader["Cnpj"].ToString()
                                    };


                                    listEmpresa.Add(empresa);
                                }

                            }
                            else return BadRequest("O Dado Inserido Não Existe (ou) Não foi Encontrado \nPor Favor Tente Novamente...");


                        }
                    }
                    con.Close();
                }
                return Ok(listEmpresa.ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        //POST : api/Home/Empresas/Add 
        [HttpPost]
        [Route("Empresas/Add")]
        public IActionResult Add(Empresas emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @"Insert into Empresas( Nome, Senha, Email, Cnpj) values(@nome, @senha, @email, @cnpj)";
                            comm.Parameters.AddWithValue("nome", emp.Nome);
                            comm.Parameters.AddWithValue("senha", emp.Senha);
                            comm.Parameters.AddWithValue("email", emp.Email);
                            comm.Parameters.AddWithValue("cnpj", emp.Cnpj);

                            comm.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }
                return Ok("Empresa Inserida com Sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }

        }


        //PUT : api/Home/Empresas/Alterar
        [HttpPost]
        [Route("Empresas/Alterar")]
        public IActionResult Alterar(Empresas emp)
        {
            try
            {
                if (emp == null) throw new ArgumentNullException("cliente");
                if (emp.IdEmpresa == 0) throw new ArgumentNullException("id");

                int registrosAfetados;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @"update Empresas set Nome = @nome, Senha = @senha, Email = @email, Cnpj = @cnpj where IdEmpresa = @id ";
                            comm.Parameters.AddWithValue("id", emp.IdEmpresa);
                            comm.Parameters.AddWithValue("nome", emp.Nome);
                            comm.Parameters.AddWithValue("senha", emp.Senha);
                            comm.Parameters.AddWithValue("email", emp.Email);
                            comm.Parameters.AddWithValue("cnpj", emp.Cnpj);

                            registrosAfetados = comm.ExecuteNonQuery();
                            con.Close();
                            if (registrosAfetados <= 0) return BadRequest($"Nao é Possivel alterar este Dado...");

                        }

                    }
                }
                return Ok($"Dado Alterado Com Sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        //Delete : api/Home/Empresas/Delete/id
        [HttpDelete]
        [Route("Empresas/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int registrosExcluidos;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = "Delete from Empresas where IdEmpresa = @id ";
                            comm.Parameters.AddWithValue("@id", id);

                            registrosExcluidos = comm.ExecuteNonQuery();
                            con.Close();
                            if (registrosExcluidos <= 0) return BadRequest($"Nao é Possivel alterar este Dado...");

                        }
                    }
                    con.Close();
                }
                return Ok("Empresa Deletada com Sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        //Get: api/Home/Tarefas
        [Route("Tarefas")]
        [HttpGet]
        public IActionResult GetAllTArefas()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @" Select Tar.IdTarefa, Tar.Descricao, emp.IdEmpresa, emp.Nome, Tar.Local, Tar.Data, StatusTarefa 
                                                from Tarefas as Tar 
                                                inner join Empresas as emp on emp.IdEmpresa = Tar.IdEmpresa  ";

                            SqlDataReader reader = comm.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Tarefas tarefa = new Tarefas()
                                    {
                                        IdTarefa = Convert.ToInt32(reader["IdTarefa"]),
                                        Descricao = reader["Descricao"].ToString(),
                                        IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                                        NomeEmpresa = reader["Nome"].ToString(),
                                        Local = reader["Local"].ToString(),
                                        Data = Convert.ToDateTime(reader["Data"]).ToString("dd/MM/yyyy : HH:mm"),
                                        StatusTarefa = (reader["StatusTarefa"] as int? == 0) ? true : false
                                    };


                                    listTarefas.Add(tarefa);
                                }

                            }
                            else { return Ok("Sem Tarefas Cadastradas..."); }
                        }
                    }
                    return Ok(listTarefas.ToArray());
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        //Get: api/Home/Tarefas/id
        [Route("Tarefas/{id:int}")]
        [HttpGet]
        public IActionResult GetTarefasById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = con;
                            comm.CommandText = @" Select Tar.IdTarefa, Tar.Descricao, emp.IdEmpresa, emp.Nome, Tar.Local, Tar.Data, StatusTarefa 
                                                from Tarefas as Tar 
                                                inner join Empresas as emp on emp.IdEmpresa = Tar.IdEmpresa  
                                                Where IdTarefa = @id";
                            comm.Parameters.AddWithValue("id", id);
                            SqlDataReader reader = comm.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Tarefas tarefa = new Tarefas()
                                    {
                                        IdTarefa = Convert.ToInt32(reader["IdTarefa"]),
                                        Descricao = reader["Descricao"].ToString(),
                                        IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                                        NomeEmpresa = reader["Nome"].ToString(),
                                        Local = reader["Local"].ToString(),
                                        Data = Convert.ToDateTime(reader["Data"]).ToString("dd/MM/yyyy : HH:mm"),
                                        StatusTarefa = (reader["StatusTarefa"] as int? == 0) ? true : false
                                    };


                                    listTarefas.Add(tarefa);
                                }

                            }
                            else { return Ok("Sem Tarefas Cadastradas..."); }

                        }
                    }
                }
                return Ok(listTarefas.ToArray());
            }
            catch (Exception ex) { return BadRequest($"Ocorreu um Erro: {ex}"); }
        }

    }
}
