using System;
using System.ComponentModel.DataAnnotations;
using DDR.Models;

namespace DDR.ViewModels
{
    public class LoginViewModel
    {
  
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            
        }
    }
}
