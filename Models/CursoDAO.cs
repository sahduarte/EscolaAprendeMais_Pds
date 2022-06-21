using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pds_Escola_AprendeMaisSoft.Database;
using MySql.Data.MySqlClient;
using Pds_Escola_AprendeMaisSoft.Helpers;

namespace Pds_Escola_AprendeMaisSoft.Models
{
    internal class CursoDAO 
    {
        private static Conexao _conn = new Conexao();
        
        public void InserirDados(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Curso value " +
                    "(null, @nome, @descricao, @carga, @turno)";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@carga", curso.Carga);
                comando.Parameters.AddWithValue("@turno", curso.Turno);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao inserir o registro.");
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<Curso> List()
        {
            try
            {
                List<Curso> list = new List<Curso>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Curso";

                MySqlDataReader reader = query.ExecuteReader();


                while (reader.Read())
                {
                    var curso = new Curso();
                    curso.Id = reader.GetInt32("id_cur");
                    curso.Nome = DAOHelpers.GetString(reader, "nome_cur");
                    curso.Descricao = DAOHelpers.GetString(reader, "descricao_cur");
                    curso.Carga = DAOHelpers.GetString(reader, "carga_horaria_cur");
                    curso.Turno = DAOHelpers.GetString(reader, "turno_cur");
                   

                    list.Add(curso);
                }
                reader.Close();


                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(Curso curso)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Curso WHERE id_cur = @id";
                comando.Parameters.AddWithValue("@id", curso.Id);
                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Não foi possível apagar o registro.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Curso u)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Curso SET " +
                    "nome_cur = @nome, descricao_cur = @descricao" +
                    "carga_horaria_cur = @carga, turno_cur = @turno" + "WHERE id_esc = @id";
               

                comando.Parameters.AddWithValue("@nome", u.Nome);
                comando.Parameters.AddWithValue("@descricao", u.Descricao);
                comando.Parameters.AddWithValue("@carga", u.Carga);
                comando.Parameters.AddWithValue("@Inscricao", u.Turno);
                comando.Parameters.AddWithValue("@id", u.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            

        }

    }

