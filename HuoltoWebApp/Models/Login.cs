using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public string Käyttäjätunnus { get; set; } = null!;
        public string Salasana { get; set; } = null!;
    }
}
