using System.Security.Cryptography;
using System.Text;

namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;

public static class SignatureProvider
{
    public static string HMACSHA256(string key, string message) 
    {
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

        byte[] keyByte = encoding.GetBytes(key);

        HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);


        byte[] messageBytes = encoding.GetBytes(message);

        byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

        return Convert.ToBase64String(hashmessage);
    }
}
