using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalango
{
    /// <summary>
    /// <c>User</c> é a classe do usuário, que conterá
    /// todas as informações úteis ao sistema
    /// no tempo de execução.
    /// </summary>

    static class User
    {
        private static string nome = "Usuário";

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public static string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private static string sobrenome = "Qualquer";

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>
        public static string Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        private static string username;

        /// <summary>
        /// Login do usuário
        /// </summary>
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static byte nivelAcesso;

        /// <summary>
        /// Nível de acesso do usuário. Indica a posição do usuário
        /// na hierarquia de acesso às funções do sistema.
        /// </summary>
        public static byte NivelAcesso
        {
            get { return nivelAcesso; }
            set
            {
                if (value < 1 || value > 3)
                    throw new Exception("Falha na definição de nível do usuário.");
                else
                    nivelAcesso = value;
            }
        }

        /// <summary>
        /// Primeiro caractere do <c>Nome</c> + primeiro caractere do
        /// <c>Sobrenome</c> do usuário
        /// </summary>
        public static string Initials
        {
            get
            {
                return nome.ElementAt(0).ToString() + sobrenome.ElementAt(0).ToString();
            }
        }
    }
}
