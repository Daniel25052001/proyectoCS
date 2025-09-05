public class AesEncryption{

public string Encryption(string algoritmo, string text){

    switch (algoritmo.ToLower()){

        case "base32": return new Base32().Encrypt(text);

        default: return  "";
    }

}



}
