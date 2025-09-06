using System;
using System.Text;

public class OctalHelper
{
    /// <summary>
    /// Codifica un texto a una cadena octal (ej: "Hola" → "110 157 154 141").
    /// </summary>
    public static string EncodeToOctal(string text)
    {
        StringBuilder octalBuilder = new StringBuilder();

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        foreach (byte b in bytes)
        {
            octalBuilder.Append(Convert.ToString(b, 8).PadLeft(3, '0'));
            octalBuilder.Append(" ");
        }

        // Eliminar el último espacio adicional
        return octalBuilder.ToString().TrimEnd();
    }

    /// <summary>
    /// Decodifica una cadena octal a texto (ej: "110 157 154 141" → "Hola").
    /// </summary>
    public static string DecodeFromOctal(string octalString)
    {
        string[] octalValues = octalString.Split(' ');
        byte[] bytes = new byte[octalValues.Length];

        for (int i = 0; i < octalValues.Length; i++)
        {
            bytes[i] = Convert.ToByte(octalValues[i], 8);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
