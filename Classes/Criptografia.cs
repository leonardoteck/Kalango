using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kalango
{

    /// <summary>
    /// Esta é a classe de criptografia, que contém
    /// os métodos necessários para criptografia no
    /// cadastro e login de usuários e armazenamento
    /// de informações importantes no Banco de Dados
    /// </summary>

    public enum CryptoProcess // métodos disponíveis de criptografia
    {
        Crypt,
        Decrypt,
        GenerateHash
    }

    class CryptoServiceProvider
    {
        private CryptoProcess metodo;

        public string DoWork(string texto) // faz o que o objeto foi construído pra ser fazer
        {
            if (metodo == CryptoProcess.Crypt || metodo == CryptoProcess.Decrypt)
            {
                byte[] aesKey = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz123456");
                // ta gerando um vetor de bytes pra usar como chave de criptografia ^
                byte[] aesIV = Encoding.ASCII.GetBytes("0123456789abcdef");
                // e um vetor de inicialização ^

                if (metodo == CryptoProcess.Crypt)
                    return Encipher(texto, aesKey, aesIV); // chama o método de crifrar
                if (metodo == CryptoProcess.Decrypt)
                    return Decipher(texto, aesKey, aesIV); // chama o método de decrifrar
            }
            else
            { // se não cifra nem decifra, é geração de hash

                byte[] bTexto = Encoding.Unicode.GetBytes(texto); // pega os bytes do texto

                MD5Cng md5 = new MD5Cng(); // MD5 Cryptography Next Generation
                SHA512Cng sha512 = new SHA512Cng(); // SHA512 Cryp....
                byte[] resultado = md5.ComputeHash(sha512.ComputeHash(bTexto)); // gera hash MD5 do hash SHA gerado

                return Encoding.Unicode.GetString(resultado); // converte o hash de volta pra texto e retorna
            }

            throw new Exception("Houve um erro no processo de criptografia."); // deu bosta x_x
        }

        public string DoWorkAsync(string texto)
        {
            throw new NotImplementedException();
        }

        private string Encipher(String texto, byte[] Key, byte[] IV)
        { // método para criptografar com chave simétrica
            byte[] cifrado; // onde serão salvos os bytes criptografados
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            { // se tem que cifrar ou decifrar, vai usar criptografia simétrica AES
                aesAlg.Key = Key; // chave de criptografia
                aesAlg.IV = IV;   // vetor de inicialização

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV); // criptografador

                using (MemoryStream msEncrypt = new MemoryStream())
                { // vide linha 64
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    { // vide linha 66
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        { // uso de vários Streams para encapsulamento da criptografia
                            swEncrypt.Write(texto); // escreve o texto no stream
                        }
                        cifrado = msEncrypt.ToArray(); // pega o texto do stream
                    }
                }
            }

            return Encoding.Unicode.GetString(cifrado); // converte pra string e retorna
        }

        private string Decipher(String texto, byte[] Key, byte[] IV)
        { // é a mesma coisa do Encipher(), mas decifra
            byte[] bTexto = Encoding.Unicode.GetBytes(texto);
            string decifrado;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(bTexto))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decifrado = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decifrado;
        }

        public CryptoServiceProvider(CryptoProcess _metodo) // construtor da classe
        {
            metodo = _metodo; // diz o que o objeto fará
        }
    }
}