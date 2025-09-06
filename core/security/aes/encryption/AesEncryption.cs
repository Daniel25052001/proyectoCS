using System.Buffers.Text;
using System.Text;
public class AesEncryption{

public string Encryption(string algoritmo, string text){

        switch (algoritmo.ToLower())
        {

            case "base32": return new Base32().Encrypt(text);
            case "base64": return Base64.EncodeBase64(Encoding.UTF8.GetBytes(text));
            case "base58": return Base58.EncodeBase58(Encoding.UTF8.GetBytes(text));
            case "binario": return BinaryHelper.EncodeToBinary(text);
            case "decimal": return DecimalHelper.EncodeToDecimal(text);
            case "hexadecimal": return HexHelper.EncodeToHex(text);
            case "octal": return OctalHelper.EncodeToOctal(text);
            default:  return "";
           

    }

}



}
