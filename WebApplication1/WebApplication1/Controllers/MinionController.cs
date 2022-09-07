using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinionController : ControllerBase
    {
        [HttpGet]


        public string GetMinionAnswer(string hash, string phonecode)
        { 


            Minion M1 = new Minion();
            string mypassword =M1.MinionAnswer(hash, phonecode);

           return mypassword;


        }

    }
}
