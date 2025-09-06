using System;
using System.Text;

public class BinaryHelper
{
    /// <summary>
    /// Codifica un texto a una cadena binaria (ej: "Hola" → "01001000011011110110110001100001").
    /// </summary>
    public static string EncodeToBinary(string text)
    {
        StringBuilder binaryBuilder = new StringBuilder();

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        foreach (byte b in bytes)
        {
            binaryBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }

        return binaryBuilder.ToString();
    }

    /// <summary>
    /// Decodifica una cadena binaria a texto (ej: "01001000..." → "Hola").
    /// </summary>
    public static string DecodeFromBinary(string binary)
    {
        if (binary.Length % 8 != 0)
        {
            throw new ArgumentException("La cadena binaria debe tener una longitud múltiplo de 8.");
        }

        int numBytes = binary.Length / 8;
        byte[] bytes = new byte[numBytes];

        for (int i = 0; i < numBytes; i++)
        {
            string byteString = binary.Substring(i * 8, 8);
            bytes[i] = Convert.ToByte(byteString, 2);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
