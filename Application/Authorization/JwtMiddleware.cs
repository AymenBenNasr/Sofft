namespace Application.Authorization;

using Microsoft.Extensions.Options;
using Api.Helpers;
using Microsoft.AspNetCore.Http;
using Application.Interfaces;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }


    public async Task Invoke(HttpContext context, CandidatRepository userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var tokenValid = jwtUtils.ValidateJwtToken(token);

        try
        { 
        var userId = Guid.Parse(jwtUtils.ValidateJwtToken(token));

        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }
        }catch (Exception ex) 
        {

        }

        await _next(context);
    }
}