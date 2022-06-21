using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pds_Escola_AprendeMaisSoft.Interfaces;
using Pds_Escola_AprendeMaisSoft.Database;
using MySql.Data.MySqlClient;
using Pds_Escola_AprendeMaisSoft.Helpers;


namespace Pds_Escola_AprendeMaisSoft.Models
{
    internal class EscolaDAO: IDAO<Escola>
    {
        private static Conexao conn;
        public EscolaDAO()
        {
            conn = new Conexao();
        }

        public void Insert(Escola t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Escola values " +
                    "(null, @NomeFantasia, @RazaoSocial, @Cnpj, @InscricaoEstadual, @Tipo, @DataCri," +
                    "@Responsavel, @TelResponsavel, @Telefone, @Email, @Rua, @Numero, @Bairro," +
                    "@Complemento, @Cep, @Cidade, @Estado)";

                
                query.Parameters.AddWithValue("@NomeFantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@RazaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@Cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@InscricaoEstadual", t.InscEstadual);
                query.Parameters.AddWithValue("@Tipo", t.Tipo);
                query.Parameters.AddWithValue("@DataCri", t.DataCriacao?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@Responsavel", t.Responsavel);
                query.Parameters.AddWithValue("@TelResponsavel", t.ResponsavelTelefone);
                query.Parameters.AddWithValue("@Telefone", t.Telefone);
                query.Parameters.AddWithValue("@Email", t.Email);
                query.Parameters.AddWithValue("@Rua", t.Rua);
                query.Parameters.AddWithValue("@Numero", t.Numero);
                query.Parameters.AddWithValue("@Bairro", t.Bairro);
                query.Parameters.AddWithValue("@Complemento", t.Complemento);
                query.Parameters.AddWithValue("@Cep", t.Cep);
                query.Parameters.AddWithValue("@Cidade", t.Cidade);
                query.Parameters.AddWithValue("@Estado", t.Estado);

                var result = query.ExecuteNonQuery();

                if(result == 0)
                    throw new Exception("Erro em inserir o Registro");


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Escola> List()
        {
            try
            {
                List<Escola> list = new List<Escola>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Escola";

                MySqlDataReader reader = query.ExecuteReader();


                while(reader.Read())
                {
                    var escola = new Escola();
                    escola.Id = reader.GetInt32("id_esc");
                    escola.NomeFantasia = DAOHelpers.GetString(reader, "nome_fantasia_esc");
                    escola.RazaoSocial = DAOHelpers.GetString(reader, "razao_social_esc");
                    escola.Cnpj = DAOHelpers.GetString(reader, "cnpj_esc");
                    escola.InscEstadual = DAOHelpers.GetString(reader, "insc_estadual_esc");
                    escola.Tipo = DAOHelpers.GetString(reader, "tipo_esc");
                    escola.DataCriacao = DAOHelpers.GetDateTime(reader, "data_criacao_esc");
                    escola.Responsavel = DAOHelpers.GetString(reader, "responsavel_esc");
                    escola.ResponsavelTelefone = DAOHelpers.GetString(reader, "responsavel_telefone_esc");
                    escola.Telefone = DAOHelpers.GetString(reader, "telefone_esc");
                    escola.Email = DAOHelpers.GetString(reader, "email_esc");
                    escola.Rua = DAOHelpers.GetString(reader, "rua_esc");
                    escola.Numero = DAOHelpers.GetString(reader, "numero_esc");
                    escola.Bairro = DAOHelpers.GetString(reader, "bairro_esc");
                    escola.Complemento = DAOHelpers.GetString(reader, "complemento_esc");
                    escola.Cep = DAOHelpers.GetString(reader, "cep_esc");
                    escola.Cidade = DAOHelpers.GetString(reader, "cidade_esc");
                    escola.Estado = DAOHelpers.GetString(reader, "estado_esc");

                    list.Add(escola);
                }
                reader.Close();
                

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }

            
        }
        public void Delete(Escola escola)
        {
            try
            {
                var comando = conn.Query();
                comando.CommandText = "DELETE FROM escola WHERE id_esc = @id";
                comando.Parameters.AddWithValue("@id", escola.Id);
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

        public Escola GetById(int id)
        {
            throw new NotImplementedException();
        }
      

        public void Update(Escola t)
        {
            try
            {
                var comando = conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                    "nome_fantasia_esc = @nome, razao_social_esc = @razao, cnpj_esc = @cnpj, insc_estadual_esc = @Inscricao, " +
                    "tipo_esc = @tipo, data_criacao_esc = @dataCri," +
                    " responsavel_esc = @responsavel, responsavel_telefone_esc = @respTel, email_esc = @email," +
                    " telefone_esc = @telefone, rua_esc = @rua, numero_esc = @numero, bairro_esc = @bairro, complemento_esc = @complemento,cep_esc = @cep, " +
                    "cidade_esc = @cidade, estado_esc = @estado " + "WHERE id_esc = @id";

                

                
                comando.Parameters.AddWithValue("@nome", t.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", t.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", t.Cnpj);
                comando.Parameters.AddWithValue("@Inscricao", t.InscEstadual);
                comando.Parameters.AddWithValue("@tipo", t.Tipo);
                comando.Parameters.AddWithValue("@dataCri", t.DataCriacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@responsavel", t.Responsavel);
                comando.Parameters.AddWithValue("@respTel", t.ResponsavelTelefone);
                comando.Parameters.AddWithValue("@email", t.Email);
                comando.Parameters.AddWithValue("@telefone", t.Telefone);
                comando.Parameters.AddWithValue("@rua", t.Rua);
                comando.Parameters.AddWithValue("@numero", t.Numero);
                comando.Parameters.AddWithValue("@bairro", t.Bairro);
                comando.Parameters.AddWithValue("@complemento", t.Complemento);
                comando.Parameters.AddWithValue("@cep", t.Cep);
                comando.Parameters.AddWithValue("@cidade", t.Cidade);
                comando.Parameters.AddWithValue("@estado", t.Estado);
                comando.Parameters.AddWithValue("@id", t.Id);

                var resultado = comando.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao atualizar as informações");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
