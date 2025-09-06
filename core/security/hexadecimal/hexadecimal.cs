using System;
using System.Text;

public class HexHelper
{
    /// <summary>
    /// Codifica un texto a una cadena hexadecimal (ej: "Hola" → "48 6F 6C 61").
    /// </summary>
    public static string EncodeToHex(string text)
    {
        StringBuilder hexBuilder = new StringBuilder();

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        foreach (byte b in bytes)
        {
            hexBuilder.Append(b.ToString("X2"));
            hexBuilder.Append(" ");
        }

        // Eliminar el último espacio adicional
        return hexBuilder.ToString().TrimEnd();
    }

    /// <summary>
    /// Decodifica una cadena hexadecimal a texto (ej: "48 6F 6C 61" → "Hola").
    /// </summary>
    public static string DecodeFromHex(string hexString)
    {
        string[] hexValues = hexString.Split(' ');
        byte[] bytes = new byte[hexValues.Length];

        for (int i = 0; i < hexValues.Length; i++)
        {
            bytes[i] = Convert.ToByte(hexValues[i], 16);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
