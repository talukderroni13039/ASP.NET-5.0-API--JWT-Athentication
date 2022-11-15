# JWTToken
In this article, we will learn how to setup JWT with ASP.NET core web application.Hope u know what is token why it is nessary.It is the implementation of token in .net core.
Prerequisites
If you're to work with the code examples discussed in this article, you should have the following installed in your system:
Visual Studio 2019 (an earlier version will also work but Visual Studio 2019 is preferred)
.NET 3.1 Or above .NET 5.0


First of All we need following JWT library in the project
    Microsoft.AspNetCore.Authentication.JwtBearer
    System.IdentityModel.Tokens.Jwt

# ASP.NET Core Custom JWT Middleware

To configure JWT authentication in .NET Core, you have to add the modifications in the Startup.cs file inside the ConfigureServices method.
let’s add the code to configure JWT right above the builder.Services.AddControllers() line

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearerConfiguration(Configuration);
    
AddJwtBearerConfiguration(Configuration) this method comes from tokenConfiguration class library from the project
This is something we would do in the Configure method inside the Startup class.Then add the ASP.NET Core Custom JWT Middleware in the start up class.

    app.UseMiddleware<JWTMiddleware>();
    
we have created  Customize Class JWTMIddleware in the Class LIbrary Project Name token Configuration so that we can use this Custom midddleware in other projects.
and sequence should be like
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<JWTMiddleware>();

We have add some global variable in appsettings.json so that we can access it from any class.

      "Jwt": {
      "Key": "p0GXO&#6VuVZLRPef0ty@O9jCqK4uZufDa6LP4n8#Gj+8hQPB30f94pFiECAnPe&Mi5N6VT3/uscoGH7+zJrv4AuuPg==",
      "Issuer": "RestaurentJWTAuthenticationServer",
      "Audience": "RestaurentJWTServiceClient",
      "Subject": "RestaurentJWTServiceAccessToken",
      "Expiration": "5"
    }

This is where you should specify your secret key, which is used to sign and verify Jwt tokens.

after initialise the JWT Configurarion u have to generate token after successfully login and back to the client site.

      var token = TokenHelper.GenerateJwtToken(_configuration, "10001"); // here 10001 means userId it has been added to Claim in token
      return JsonConvert.SerializeObject(token);

Use   [Authorize] Attribute before Action Method to authorize the specific method. U acn also set it globally in startup.cs. 
For token expire in actual time use  using TokenConfigaration not using Microsoft.AspNetCore.Authorization.  because it delay always 5 mins extra.
so that we just customize the Authorize Attribute.

In the Client side I have used Angular to generate token and verify the method.








