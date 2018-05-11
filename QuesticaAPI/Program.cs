using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuesticaAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToBase64String(EncryptString("Ell@Fay3")));
            using (var md5 = MD5.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes("Ell@Fay3");
                byte[] hash = md5.ComputeHash(input);
                Console.WriteLine($"MD5: {Convert.ToBase64String(hash)}");
            }
            using (var sha = SHA1.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes("Ell@Fay3");
                byte[] hash = sha.ComputeHash(input);
                Console.WriteLine($"Sha1: {Convert.ToBase64String(hash)}");
            }
            using (var sha = SHA256.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes("Ell@Fay3");
                byte[] hash = sha.ComputeHash(input);
                Console.WriteLine($"SHA256: {Convert.ToBase64String(hash)}");
            }
            using (var md5 = SHA384.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes("Ell@Fay3");
                byte[] hash = md5.ComputeHash(input);
                Console.WriteLine($"SHA384: {Convert.ToBase64String(hash)}");
            }
            using (var md5 = SHA512.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes("Ell@Fay3");
                byte[] hash = md5.ComputeHash(input);
                Console.WriteLine($"SHA512: {Convert.ToBase64String(hash)}");
            }

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5001/")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        private static byte[] EncryptString(string value)
        {
            value = value.PadRight(0x19);
            int length = value.Length;
            byte[] buffer = new byte[length];
            int num2 = 150;
            int num3 = 0x9b;
            int num4 = 0xcf;
            int num5 = 0x95;
            buffer = Array.ConvertAll<char, byte>(value.ToCharArray(), new Converter<char, byte>(Convert.ToByte));
            for (int i = 1; i < length; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ ((byte)(buffer[i - 1] ^ ((num2 * buffer[i - 1]) % 0x100))));
            }
            for (int j = length - 2; j >= 0; j--)
            {
                buffer[j] = (byte)(buffer[j] ^ ((byte)(buffer[j + 1] ^ ((byte)((num3 * buffer[j + 1]) % 0x100)))));
            }
            for (int k = 2; k < length; k++)
            {
                buffer[k] = (byte)(buffer[k] ^ ((byte)(buffer[k - 2] ^ ((num4 * buffer[k - 1]) % 0x100))));
            }
            for (int m = length - 3; m >= 0; m--)
            {
                buffer[m] = (byte)(buffer[m] ^ ((byte)(buffer[m + 2] ^ ((num5 * buffer[m + 1]) % 0x100))));
            }
            return buffer;
        }


    }
}
