public class AesDecryption{

public string Decryption(string algoritmo, string text){

    switch (algoritmo.ToLower()){

        case "base32": return new Base32().Decode(text);

        default: return  "";
    }

}



}
