using System;
using System.Text;

public class DecimalHelper
{
    /// <summary>
    /// Codifica un texto a una cadena decimal (ej: "Hola" → "72 111 108 97").
    /// </summary>
    public static string EncodeToDecimal(string text)
    {
        StringBuilder decimalBuilder = new StringBuilder();

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        foreach (byte b in bytes)
        {
            decimalBuilder.Append(b.ToString());
            decimalBuilder.Append(" ");
        }

        // Eliminar el último espacio adicional
        return decimalBuilder.ToString().TrimEnd();
    }

    /// <summary>
    /// Decodifica una cadena decimal a texto (ej: "72 111 108 97" → "Hola").
    /// </summary>
    public static string DecodeFromDecimal(string decimalString)
    {
        string[] decimalValues = decimalString.Split(' ');
        byte[] bytes = new byte[decimalValues.Length];

        for (int i = 0; i < decimalValues.Length; i++)
        {
            bytes[i] = byte.Parse(decimalValues[i]);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
