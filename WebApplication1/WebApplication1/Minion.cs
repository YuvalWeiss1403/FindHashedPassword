using System.Text;
using System.Security.Cryptography;



namespace WebApplication1
{
    public class Minion
    {

        public string MinionAnswer (string hash,string phonecode)
        {
            return MinionWorker(hash,phonecode);
        }

        static List<string> Permute()
        {
            List<string> list = new List<string>();
            var range = Enumerable.Range(0, 10);
            var result = from d1 in range
                         from d2 in range
                         from d3 in range
                         from d4 in range
                         from d5 in range
                         from d6 in range
                         from d7 in range
                         select new { d1, d2, d3, d4, d5, d6, d7 };

            foreach (var r in result)
            {
                string number = r.d1.ToString() + r.d2.ToString() + r.d3.ToString() + r.d4.ToString() + r.d5.ToString() + r.d6.ToString() + r.d7.ToString();
                list.Add(number);
            }

            return list;

        }


        static string MinionWorker(string hash, string numberstart)
        {

            List<string> passwords = Permute();
            foreach (string number in passwords)
            {
                string hashnumber = GetMD5(numberstart + number);
                if (hash == hashnumber)
                    return (numberstart + number);
            }

            return "";
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
    }
}
