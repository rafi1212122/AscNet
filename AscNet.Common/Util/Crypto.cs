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
    }
}
