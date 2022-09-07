using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    
    public class  Program
    {
        static HttpClient client = new HttpClient();

        static void ShowPassword(string hash)
        {
            List<WebApplication1.Controllers.MinionController> minionControllers = new List<WebApplication1.Controllers.MinionController>();
   

            string[ ] answer = new string[9];
            bool iffound=false;
            string password="";

                for (int i = 0; i < 10; i++)
                {
                    minionControllers.Add(new WebApplication1.Controllers.MinionController());
                    string numbercode = "05" + i;
                    password = minionControllers[i].GetMinionAnswer(hash, numbercode);
                    if (password != "")
                    {
                    Console.WriteLine("your password is:" + password);
                    iffound = true;
                        break;
                    }
                    Console.WriteLine("start working on minion" + i);
                }
            if (!iffound)
                Console.WriteLine("Not found");   
                

        }

        public static string GetMD5(string input)
        {
            MD5 MD5 = MD5.Create();
            byte[] tmpHash;
            byte[] tmpSource;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(input);
            tmpHash = MD5.ComputeHash(tmpSource);
            StringBuilder sb = new StringBuilder();
            foreach (byte x in tmpHash)
                sb.Append(x.ToString("x2"));
            return sb.ToString();
        }

        static void Main()
        {
            Console.WriteLine("enter password");
            string originalphonenumber = Console.ReadLine();
            string hash = GetMD5(originalphonenumber);
            ShowPassword(hash);
        }
    }
}
