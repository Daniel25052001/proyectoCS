using System;
using System.Text;

public class Base32
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

    // Función para codificar en Base32
    public string Encrypt(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        StringBuilder result = new StringBuilder();
        int bitBuffer = 0;
        int bitCount = 0;

        foreach (byte b in bytes)
        {
            bitBuffer = (bitBuffer << 8) | b;
            bitCount += 8;

            while (bitCount >= 5)
            {
                int index = (bitBuffer >> (bitCount - 5)) & 31;
                result.Append(Alphabet[index]);
                bitCount -= 5;
            }
        }

        if (bitCount > 0)
        {
            int index = (bitBuffer << (5 - bitCount)) & 31;
            result.Append(Alphabet[index]);
        }

        return result.ToString();
    }

    // Función para decodificar desde Base32
    public string Decode(string base32)
    {
        int bitBuffer = 0;
        int bitCount = 0;
        MemoryStream stream = new MemoryStream();

        foreach (char c in base32.ToUpper())
        {
            if (!Alphabet.Contains(c)) continue;

            int value = Alphabet.IndexOf(c);
            bitBuffer = (bitBuffer << 5) | value;
            bitCount += 5;

            if (bitCount >= 8)
            {
                byte b = (byte)((bitBuffer >> (bitCount - 8)) & 255);
                stream.WriteByte(b);
                bitCount -= 8;
            }
        }

        return Encoding.UTF8.GetString(stream.ToArray());
    }
}
