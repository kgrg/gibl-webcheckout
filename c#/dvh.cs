using System;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json ;
public class TokenRequestModel
{
	
    public decimal amount { get; set; }
	public string apiKey { get; set; }
	public string bankCode { get; set; }
	public string currency { get; set; }
	public string dateOfRequest { get; set; }
	public string referenceId { get; set; }
		
}

public class Program
{
	public static void Main()
	{
		var account = new TokenRequestModel() { amount = 100.5M , apiKey = "3568f8c7-3f33-49dc-bbc9-9362c130f7c8" , bankCode = "GIBL" ,  currency= "NPR" ,dateOfRequest = "2020-09-10" , referenceId = "Drz9699731138518"  };
        string json = JsonConvert.SerializeObject(account);
		string ipnSecret = "3568f8c73f3349dcbbc99362c130f7c8";
		Console.WriteLine("json : "+ json);
		// string json = "{\"amount\":100.5,\"apiKey\":\"3568f8c7-3f33-49dc-bbc9-9362c130f7c8\",\"bankCode\":\"GIBL\",\"currency\":\"NPR\",\"dateOfRequest\":\"2020-09-10\",\"referenceId\":\"Drz9699731138518\"}";
		string base64EncodedExternalAccount = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
		string hmac = calcHMAC(base64EncodedExternalAccount , ipnSecret);
		Console.WriteLine("hmac : "+ hmac);
		
	}
	public static string calcHMAC(string parms, string ipnSecret)
	{
		byte[] keyBytes = Encoding.UTF8.GetBytes(ipnSecret);
		byte[] postBytes = Encoding.UTF8.GetBytes(parms);
		var hmacsha512 = new HMACSHA512(keyBytes);
		string hmac = BitConverter.ToString(hmacsha512.ComputeHash(postBytes)).Replace("-", "").ToLowerInvariant();
		return hmac;
	}
	
}