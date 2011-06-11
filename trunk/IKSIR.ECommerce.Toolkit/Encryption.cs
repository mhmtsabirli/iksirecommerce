using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace IKSIR.ECommerce.Toolkit
{
    /// <summary>
    /// Provides encryption and hashing routines
    /// </summary>
    public class Encryption
    {
        public enum OutputFormat
        {
            Hex,
            Base64
        }

        public enum EncryptionType
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512
        }

        private delegate byte[] ComputeHash(byte[] input);

        private string _getHash(byte[] input, ComputeHash method, OutputFormat format)
        {
            string output = "";
            
            byte[] hash = method(input);

            switch (format)
            {
                case OutputFormat.Hex:
                    output = Hex(hash);
                    break;
                case OutputFormat.Base64:
                    output = Base64(hash);
                    break;
            }            

            return output;            
        }

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

        public Encryption()
        {
            _Encoding = Encoding.UTF8;
        }
        public Encryption(Encoding endcoding)
        {
            _Encoding = endcoding;
        }

        public string Base64(byte[] input)
        {
            return Convert.ToBase64String(input);
        }
        public string Base64(string input)
        {
            return Base64(_Encoding.GetBytes(input));
        }

        public string Hex(byte[] input)
        {
            string output = "";
            foreach (byte a in input)
            {
                output += a.ToString("x2");
            }

            return output;
        }

        public string MD5(byte[] input)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                return _getHash(input, md5.ComputeHash, OutputFormat.Hex);
            }
        }
        public string MD5(string input)
        {
            return MD5(_Encoding.GetBytes(input));
        }
        public string MD5(byte[] input, OutputFormat format)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                return _getHash(input, md5.ComputeHash, format);
            }
        }
        public string MD5(string input, OutputFormat format)
        {
            return MD5(_Encoding.GetBytes(input), format);
        }

        public string SHA1(byte[] input)
        {
            using (SHA1Managed sha = new SHA1Managed())
            {
                return _getHash(input, sha.ComputeHash, OutputFormat.Hex);
            }
        }
        public string SHA1(string input)
        {
            return SHA1(_Encoding.GetBytes(input));
        }
        public string SHA1(byte[] input, OutputFormat format)
        {
            using (SHA1Managed sha = new SHA1Managed())
            {
                return _getHash(input, sha.ComputeHash, format);
            }
        }
        public string SHA1(string input, OutputFormat format)
        {
            return SHA1(_Encoding.GetBytes(input), format);
        }

        public string SHA256(byte[] input)
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                return _getHash(input, sha.ComputeHash, OutputFormat.Hex);
            }
        }
        public string SHA256(string input)
        {
            return SHA256(_Encoding.GetBytes(input));
        }
        public string SHA256(byte[] input, OutputFormat format)
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                return _getHash(input, sha.ComputeHash, format);
            }
        }
        public string SHA256(string input, OutputFormat format)
        {
            return SHA256(_Encoding.GetBytes(input), format);
        }

        public string SHA384(byte[] input)
        {
            using (SHA384Managed sha = new SHA384Managed())
            {
                return _getHash(input, sha.ComputeHash, OutputFormat.Hex);
            }
        }
        public string SHA384(string input)
        {
            return SHA384(_Encoding.GetBytes(input));
        }
        public string SHA384(byte[] input, OutputFormat format)
        {
            using (SHA384Managed sha = new SHA384Managed())
            {
                return _getHash(input, sha.ComputeHash, format);
            }
        }
        public string SHA384(string input, OutputFormat format)
        {
            return SHA384(_Encoding.GetBytes(input), format);
        }

        public string SHA512(byte[] input)
        {
            using (SHA512Managed sha = new SHA512Managed())
            {
                return _getHash(input, sha.ComputeHash, OutputFormat.Hex);
            }
        }
        public string SHA512(string input)
        {
            return SHA512(_Encoding.GetBytes(input));
        }
        public string SHA512(byte[] input, OutputFormat format)
        {
            using (SHA512Managed sha = new SHA512Managed())
            {
                return _getHash(input, sha.ComputeHash, format);
            }
        }
        public string SHA512(string input, OutputFormat format)
        {
            return SHA512(_Encoding.GetBytes(input), format);
        }

        public string GetHash(byte[] input, EncryptionType type, OutputFormat format)
        {
            switch (type)
            {
                case EncryptionType.MD5:
                    return MD5(input, format);
                case EncryptionType.SHA1:
                    return SHA1(input, format);
                case EncryptionType.SHA256:
                    return SHA256(input, format);
                case EncryptionType.SHA384:
                    return SHA384(input, format);
                case EncryptionType.SHA512:
                    return SHA512(input, format);
                default:
                    return "";
            }
        }
        public string GetHash(string input, EncryptionType type, OutputFormat format)
        {
            return GetHash(_Encoding.GetBytes(input), type, format);
        }

        public static string HTMLEntities(string input)
        {
            StringBuilder entifiedXhtml = new StringBuilder(input.Length * 2);
            foreach (char c in input.ToCharArray())
            {
                if (c > 126)
                {
                    entifiedXhtml.Append("&#");
                    entifiedXhtml.Append((int)c);
                    entifiedXhtml.Append(";");
                }
                else
                {
                    entifiedXhtml.Append(c);
                }
            }

            return entifiedXhtml.ToString();
        }
    }
}