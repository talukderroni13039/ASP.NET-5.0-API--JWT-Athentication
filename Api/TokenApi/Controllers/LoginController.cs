
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TokenConfigaration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _configuration;
        public LoginController(IConfiguration config)
        {
          
            _configuration = config;
        }

        [Route("VerifyUser")]
        [HttpPost]
        public string VerifyUser(string userName,string password)
        {
            // add user verify logic with userName and PassWord.
            // after verify then generate token

          return JsonConvert.SerializeObject(  TokenHelper.GenerateJwtToken(_configuration,"10001")); // pass configuration and userId


        }
        [HttpGet]
        [Route("RefreshToken")]
        public string RefreshToken()
        {
            // var headerInfo = getHeaderInfo();
            // if (_loginRepository.HasUser(headerInfo.UserPkID))
            // {
            //  var token = TokenHelper.GenerateJwtToken(_configuration,headerInfo.UserPkID);
            //  return JsonConvert.SerializeObject(token);
            // }

            //else
            //    return null;


            var token = TokenHelper.GenerateJwtToken(_configuration, "10001");
            return JsonConvert.SerializeObject(token);

        }

        //private SecurityHeader getHeaderInfo()
        //{
        //    var headerCredentials = HttpContext.Request.Headers["CurrentRequest"];
        //    return HelperMethods.GetHttpHeaderValue(HttpContext.Request.Headers["CurrentRequest"]);
        //}

        [Authorize]
        [HttpGet]
        [Route("GetName")]
        public string GetName()
        {
            // var headerInfo = getHeaderInfo();
            // if (_loginRepository.HasUser(headerInfo.UserPkID))
            // {
            //  var token = TokenHelper.GenerateJwtToken(_configuration,headerInfo.UserPkID);
            //  return JsonConvert.SerializeObject(token);
            // }

            //else
            //    return null;


            return JsonConvert.SerializeObject("The Name Is Talukder");

        }


    }
}
