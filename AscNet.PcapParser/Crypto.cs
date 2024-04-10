using System;
using System.Security.Cryptography;

namespace AscNet.Common.Util
{
    public static class Crypto
    {
        public static byte[] XORCrypt(byte[] data, byte[] key)
        {
            byte[] encryptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
                encryptedData[i] = (byte)(data[i] ^ key[i % key.Length]);

            return encryptedData;
        }

        public static class HaruCrypt
        {
            private static readonly byte[] key = new byte[] { 103, 40, 227, 236, 173, 175, 148, 243, 66, 252, 58, 22, 68, 192, 159, 15, 187, 15, 15, 29, 209, 209, 212, 66, 104, 16, 252, 194, 227, 14, 116, 112, 196, 221, 5, 1, 4, 173, 165, 69, 45, 193, 95, 10, 67, 38, 167, 239, 96, 184, 133, 75, 152, 196, 36, 121, 251, 7, 73, 82, 219, 25, 118, 70, 153, 232, 120, 120, 147, 10, 88, 106, 214, 187, 216, 49, 224, 57, 1, 233, 110, 40, 65, 85, 246, 197, 4, 20, 56, 74, 245, 41, 63, 169, 188, 104, 89, 49, 115, 254, 100, 77, 79, 11, 148, 242, 95, 88, 241, 111, 48, 130, 169, 200, 224, 135, 121, 161, 72, 84, 5, 100, 135, 70, 141, 94, 244, 114, 58, 28, 87, 181, 205, 221, 154, 184, 197, 98, 210, 202, 252, 124, 144, 9, 112, 163, 24, 254, 119, 188, 5, 230, 40, 79, 171, 17, 156, 212, 134, 41, 79, 134, 26, 251, 123, 219, 191, 136, 21, 84, 192, 91, 24, 33, 68, 101, 85, 61, 186, 215, 191, 37, 45, 51, 117, 227, 14, 145, 56, 43, 32, 67, 48, 98, 192, 41, 136, 223, 50, 163, 97, 251, 174, 59, 59, 147, 237, 177, 31, 159, 52, 243, 245, 247, 148, 139, 21, 92, 139, 80, 47, 4, 105, 59, 227, 220, 180, 231, 176, 187, 205, 203, 148, 121, 98, 90, 87, 131, 245, 3, 63, 239, 57, 117, 102, 134, 40, 172, 60, 128, 108, 102, 216, 247, 133, 102 };
            private static readonly RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            private static readonly byte[] signature = new byte[128];
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            private static readonly SHA1 sha = new SHA1CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            private const string PUBLIC_KEY = "<RSAKeyValue><Modulus>kZE/f0ifi0DH3uP3KCWOPqTyQ3MsQKHf9X4Z65S36s226RkdkZL2kHTz20n+IlOvGChi3ByDMFLawlyB0MCW94WDnc1Mc/PtVKo6D8gBEcSvdjDbhC4Ly0f2hMHS/SNdGPMAMkEWGNvIvfuT1TEaWTPsxRLZbfASp2KPG7Wjdck=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            static HaruCrypt()
            {
                rsa.FromXmlString(PUBLIC_KEY);
            }

            public static void Encrypt(byte[] content)
            {
                Encrypt(content, 0, content.Length);
            }

            public static void Encrypt(byte[] content, int offset, int count)
            {
                int num = count % key.Length;
                for (int i = 0; i < count; i++)
                {
                    int num2 = i + offset;
                    int num3 = (int)content[num2];
                    num3 ^= (int)key[num];
                    if (i > 0)
                    {
                        num3 ^= (int)content[num2 - 1];
                    }
                    num3 ^= (int)key[i % key.Length];
                    int num4 = ((int)((i + 1 < count) ? content[num2 + 1] : 0) + count) % 8;
                    num3 = (num3 << 8 - num4 | num3 >> num4);
                    content[num2] = (byte)num3;
                }
            }

            public static void Decrypt(byte[] content)
            {
                Decrypt(content, 0, content.Length);
            }

            private static void Decrypt(byte[] bytes, int offset, int count)
            {
                int num = count % key.Length;
                for (int i = count - 1; i >= 0; i--)
                {
                    int num2 = i + offset;
                    int num3 = (int)bytes[num2];
                    int num4 = ((int)((i + 1 < count) ? bytes[num2 + 1] : 0) + count) % 8;
                    num3 = (num3 >> 8 - num4 | num3 << num4);
                    num3 ^= (int)key[i % key.Length];
                    if (num2 > offset)
                    {
                        num3 ^= (int)bytes[num2 - 1];
                    }
                    num3 ^= (int)key[num];
                    bytes[num2] = (byte)num3;
                }
            }

            private static bool Verify(byte[] content, ref int offset, ref int count)
            {
                Buffer.BlockCopy(content, offset, signature, 0, signature.Length);
                offset += signature.Length;
                count -= signature.Length;
                byte[] hash = sha.ComputeHash(content, offset, count);
                return rsa.VerifyHash(hash, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
        }
    }
}
