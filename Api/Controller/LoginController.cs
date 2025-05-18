using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;


public class LoginController : BaseController
{
 
    [HttpPost("Register")]
    public async Task<Result> Register()
    {
        return Result.Succeed();
    }
    
    [HttpPost("Login")]
    public async Task<Result<string>> Login()
    {
        return Result<string>.Succeed("sdfa");
    }
    
    [HttpPost("Test")]
    public async Task<Result<string>> Test()
    {
        throw new Exception("fsdfsd");
        
    }
}