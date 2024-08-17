﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Dtos
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }        
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
        public object AdditionalInfo { get; set; }
    }
}
