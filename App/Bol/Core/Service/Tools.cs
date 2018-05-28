using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Bol.Core.Service
{
    public class Tools
    {
        public byte[] Clave = Encoding.ASCII.GetBytes("Tu Clave");
        public byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES"); private const string SECRETKEY = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

        //Modo de cifrado.
        private const CipherMode CYPHMODE = CipherMode.ECB;

        public string Encripta(string textoEncriptar)
        {
            try
            {
                TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
                //Agrega la cadena en una matriz.
                byte[] InputbyteArray = Encoding.UTF8.GetBytes(textoEncriptar);

                //Crea el objeto de cifrado con la SECRETKEY.
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SECRETKEY));
                Des.Mode = CYPHMODE;

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, Des.CreateEncryptor(), CryptoStreamMode.Write);

                //Escribe la matriz de bytes en la secuencia de cifrado.
                cs.Write(InputbyteArray, 0, InputbyteArray.Length);
                cs.FlushFinalBlock();

                //Obtiene los datos de nuevo a partir de la secuencia de memoria, y en una cadena.
                StringBuilder textRetorno = new StringBuilder();
                byte[] b = ms.ToArray();
                ms.Close();

                for (int i = 0; i <= b.GetUpperBound(0); i++)
                {
                    //Formato del hex.
                    textRetorno.AppendFormat("{0:X2}", b[i]);
                }
                return textRetorno.ToString();
            }//EndTry
            catch (Exception)
            {
                return string.Empty;
            }
        }



        public string Desencripta(string textoDesencriptar)
        {

            if (String.IsNullOrEmpty(textoDesencriptar))
                return String.Empty;
            else
            {
                StringBuilder textoRetorno = new StringBuilder();
                byte[] InputbyteArray = new byte[Convert.ToInt32(textoDesencriptar.Length) / 2];
                TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

                try
                {
                    Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SECRETKEY));
                    Des.Mode = CYPHMODE;

                    for (int X = 0; X <= InputbyteArray.Length - 1; X++)
                    {
                        Int32 IJ = (Convert.ToInt32(textoDesencriptar.Substring(X * 2, 2), 16));
                        ByteConverter BT = new ByteConverter();
                        InputbyteArray[X] = new byte();
                        InputbyteArray[X] = Convert.ToByte(BT.ConvertTo(IJ, typeof(byte)));
                    }

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write);

                    //Escribe la matriz de bytes en la secuencia de descifrado.
                    cs.Write(InputbyteArray, 0, InputbyteArray.Length);
                    cs.FlushFinalBlock();

                    //Obtiene los datos de nuevo a partir de la secuencia de memoria, y en una cadena.
                    byte[] B = ms.ToArray();
                    ms.Close();

                    for (int i = 0; i <= B.GetUpperBound(0); i++)
                    {
                        textoRetorno.Append(Convert.ToChar(B[i]));
                    }
                }
                catch (Exception)
                {
                    return String.Empty;
                }
                //Retorno éxito
                return textoRetorno.ToString();
            }//EndElse
        }

        /// <summary>
        /// Metodo que recibe una cadena de caracteres e indica si se trata de un numero o no.
        /// </summary>
        /// <param name="pal">String a verificar.</param>
        /// <returns>False si hay algun caracter que no sea numero. / True caso contrario.</returns>
        public static bool IsNumber(string pal)
        {
            return pal.All(char.IsNumber);
        }

        /// <summary>
        /// Metodo que recibe una cadena de caracteres e indica si se trata de un double o no.
        /// </summary>
        /// <param name="pal">String a verificar.</param>
        /// <returns>true si es un double, false si no es double.</returns>
        public static bool IsDouble(string pal)
        {
            double num;
            return double.TryParse(pal, out num);
        }

        /// <summary>
        /// Metodo que recibe una cadena de caracteres e indica si esta compuesta solo por letras .
        /// </summary>
        /// <param name="pal">String a verificar.</param>
        /// <returns>False si algun caracter no es letra / True en caso contrario.</returns>
        public static bool IsLetter(string pal)
        {
            return pal.Count(caracter => !char.IsLetter(caracter)) == 0;
        }
    }
}
