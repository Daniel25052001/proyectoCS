using System;
using System.Numerics;
using System.Text;

public class Base58
{
    private const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

    /// <summary>
    /// Codifica un array de bytes a Base58.
    /// </summary>
    public static string EncodeBase58(byte[] input)
    {
        BigInteger intData = new BigInteger(input.Concat(new byte[] { 0 }).ToArray()); // Ensure positive BigInteger

        StringBuilder result = new StringBuilder();
        while (intData > 0)
        {
            int remainder = (int)(intData % 58);
            intData /= 58;
            result.Insert(0, Alphabet[remainder]);
        }

        // Añadir '1' por cada 0 al inicio del array original
        foreach (byte b in input)
        {
            if (b == 0)
                result.Insert(0, Alphabet[0]);
            else
                break;
        }

        return result.ToString();
    }

    /// <summary>
    /// Decodifica una cadena Base58 a bytes.
    /// </summary>
    public static byte[] DecodeBase58(string input)
    {
        BigInteger intData = BigInteger.Zero;
        foreach (char c in input)
        {
            int digit = Alphabet.IndexOf(c);
            if (digit < 0)
                throw new FormatException($"Invalid Base58 character '{c}'");

            intData = intData * 58 + digit;
        }

        // Convertir BigInteger a byte[]
        var bytesWithoutLeadingZeros = intData.ToByteArray();

        // Quitar el byte adicional si es necesario
        if (bytesWithoutLeadingZeros[^1] == 0)
        {
            bytesWithoutLeadingZeros = bytesWithoutLeadingZeros[..^1];
        }

        // Añadir ceros por cada '1' al inicio del string Base58
        int leadingZeros = input.TakeWhile(c => c == Alphabet[0]).Count();
        var result = new byte[leadingZeros + bytesWithoutLeadingZeros.Length];
        Array.Copy(bytesWithoutLeadingZeros.Reverse().ToArray(), 0, result, leadingZeros, bytesWithoutLeadingZeros.Length);

        return result;
    }
}
