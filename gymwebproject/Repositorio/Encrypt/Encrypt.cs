using System.Security.Cryptography;
using System.Text;

namespace gymwebproject.Repositorio.Encrypt
{
   

    public class Encriptar
    {
        public string Encrypt(string Mens)
        {
            string hash = " codigo con c";
            byte[] data = UTF8Encoding.UTF8.GetBytes(Mens);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        


    }


}
