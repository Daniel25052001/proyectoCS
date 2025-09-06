
using System.Text;
public class AesDecryption
{

    public string Decryption(string algoritmo, string text)
    {

        switch (algoritmo.ToLower())
        {

            case "base32": return new Base32().Decode(text);
            case "base58": return Encoding.UTF8.GetString(Base58.DecodeBase58(text));
            case "base64":  return Encoding.UTF8.GetString(Base64.DecodeBase64(text));
            case "binario": return BinaryHelper.DecodeFromBinary(text);
            case "decimal": return DecimalHelper.DecodeFromDecimal(text);
            case "hexadecimal": return HexHelper.DecodeFromHex(text);
            case "octal": return OctalHelper.DecodeFromOctal(text);
            default: return "";
        }

    }



}
