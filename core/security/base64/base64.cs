using System;
using System.Text;

public class Base64Helper
{
    /// <summary>
    /// Codifica un array de bytes a Base64.
    /// </summary>
    public static string EncodeBase64(byte[] data)
    {
        return Convert.ToBase64String(data);
    }

    /// <summary>
    /// Decodifica una cadena Base64 a un array de bytes.
    /// </summary>
    public static byte[] DecodeBase64(string base64)
    {
        return Convert.FromBase64String(base64);
    }
}
