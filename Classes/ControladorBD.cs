using System;
using System.Data.SqlClient;
using System.Data;

namespace Kalango
{
    /// <summary>
    /// ESTA CLASSE ESTÁ EM CONSTRUÇÃO!
    /// Ultima att 02/12/2015
    /// </summary>

    public class ControladorBD
    {
        /// <summary>
        /// String estática de conexão. Deve ser definida ao iniciar o programa.
        /// </summary>
        private static string stringConexao;
        /// <summary>
        /// String estática de conexão. Deve ser definida ao iniciar o programa.
        /// </summary>
        public static string StringConexao
        {
            get { return stringConexao; }
            set { stringConexao = value; }
        }

        /// <summary>
        /// Objeto de conexão usado pela classe
        /// </summary>
        private SqlConnection con;

        /// <summary>
        /// Faz a leitura de dados Sql,
        /// abre e fecha a conexão,
        /// não usa SqlTransaction
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <returns>Retorna um DataTable com os resultados</returns>
        public DataTable Ler(string stringSQL)
        {
            DataTable result = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(stringSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader); 
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Faz a leitura de um dado Sql,
        /// abre e fecha a conexão,
        /// não usa SqlTransaction
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <param name="parametros">Conjunto de parâmetros da query</param>
        /// <returns>Retorna um DataTable com os resultados</returns>
        public DataTable Ler(string stringSQL, SqlParameter[] parametros)
        {
            DataTable result = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(stringSQL, con);
                cmd.Parameters.AddRange(parametros);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Faz a leitura de um dado Sql,
        /// abre e fecha a conexão,
        /// faz BeginTransaction e commit.
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <returns>Retorna um DataTable com os resultados</returns>
        public DataTable LerEAlterar(string stringSQL)
        {
            DataTable result = new DataTable();
            try
            {
                con.Open();
                SqlTransaction transa = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand(stringSQL, con, transa);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
                transa.Commit();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Faz a leitura de um dado Sql,
        /// abre e fecha a conexão,
        /// faz BeginTransaction e commit.
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <param name="parametros">Conjunto de parâmetros da query</param>
        /// <returns>Retorna um DataTable com os resultados</returns>
        public DataTable LerEAlterar(string stringSQL, SqlParameter[] parametros)
        {
            DataTable result = new DataTable();
            try
            {
                con.Open();
                SqlTransaction transa = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand(stringSQL, con, transa);
                cmd.Parameters.AddRange(parametros);
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
                transa.Commit();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Faz uma alteração no banco de dados (INSERT, DELETE, UPDATE, etc),
        /// abre e fecha a conexão,
        /// faz BeginTransaction e commit
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <returns>Retorna o número de linhas afetadas</returns>
        public int Alterar(string stringSQL)
        {
            int result;
            try
            {
                con.Open();
                SqlTransaction transa = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand(stringSQL, con, transa);
                result = cmd.ExecuteNonQuery();
                transa.Commit();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Faz uma alteração no banco de dados (INSERT, DELETE, UPDATE, etc),
        /// abre e fecha a conexão,
        /// faz BeginTransaction e commit
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <param name="parametros">Conjunto de parâmetros da query</param>
        /// <returns>Retorna o número de linhas afetadas</returns>
        public int Alterar(string stringSQL, SqlParameter[] parametros)
        {
            int result;
            try
            {
                con.Open();
                SqlTransaction transa = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand(stringSQL, con, transa);
                cmd.Parameters.AddRange(parametros);
                result = cmd.ExecuteNonQuery();
                transa.Commit();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Executa uma função SQL (COUNT, MAX, etc)
        /// ou uma query,
        /// abre e fecha a conexão,
        /// não usa SqlTransaction
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <returns>Retorna o número de linhas afetadas</returns>
        public T Contar<T>(string stringSQL)
        {
            T resultado;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(stringSQL, con);
                resultado = (T)cmd.ExecuteScalar();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Executa uma função SQL (COUNT, MAX, etc)
        /// ou uma query,
        /// abre e fecha a conexão,
        /// não usa SqlTransaction
        /// </summary>
        /// <param name="stringSQL">Query a ser executada</param>
        /// <param name="parametros">Conjunto de parâmetros da query</param>
        /// <returns>Retorna o número de linhas afetadas</returns>
        public T Contar<T>(string stringSQL, SqlParameter[] parametros)
        {
            T resultado;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(stringSQL, con);
                cmd.Parameters.AddRange(parametros);
                resultado = (T)cmd.ExecuteScalar();
            }
            finally
            {
                if (con.State != ConnectionState.Closed && con.State != ConnectionState.Broken)
                    con.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Declara o controlador de banco de dados para fazer transações
        /// </summary>
        public ControladorBD()
        {
            con = new SqlConnection(stringConexao);
        }

        /// <summary>
        /// Testa a conexão com o banco de dados.
        /// Uso recomendado no início do programa
        /// </summary>
        /// <returns>
        /// Retorna um erro caso não seja possível conectar e
        /// retorna nulo caso consiga
        /// </returns>
        public Exception TestarConexao()
        {
            try
            {
                con.Open();
                con.Close();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}