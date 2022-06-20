using System;
namespace Api.Config
{
	public class JwtAthenticationOptions
	{
        public string jwtKey { get; set; }

        public string ValidAudience { get; set; }

        public string ValidIssuer { get; set; }
    }
}

