using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

public static class ToSha1
{
    public static StringBuilder convert(string word)
    {
        // hashing password
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(word);
        SHA1 sha = new SHA1CryptoServiceProvider();
        bytes = sha.ComputeHash(bytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb;
    }

}
