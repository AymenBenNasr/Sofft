﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Auth
{
    public class EmployerRegisterDto : RegisterDto
    {
        string? companyName { get; set; }
        string? title { get; set; }
        string? companyWebsite { get; set; }


    }
}
