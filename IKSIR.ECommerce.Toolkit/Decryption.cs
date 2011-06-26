using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace IKSIR.ECommerce.Toolkit
{
    /// <summary>
    /// Provides static decryption routines
    /// </summary>
    public class Decryption
    {
        private Encoding _Encoding = Encoding.UTF8;

        public Encoding Endcoding
        {
            get
            {
                return _Encoding;
            }

            set
            {
                _Encoding = value;
            }
        }

        public Decryption()
        {
            _Encoding = Encoding.UTF8;
        }

        public Decryption(Encoding endcoding)
        {
            _Encoding = endcoding;
        }

        public string Base64(string input)
        {

            return _Encoding.GetString(Convert.FromBase64String(input));
        }

        public byte[] Base64(byte[] input)
        {
            return Convert.FromBase64String(_Encoding.GetString(input));
        }
    }
}