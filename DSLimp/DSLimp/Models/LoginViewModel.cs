using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DSLimp.Models
{
    public class LoginViewModel
    {   




        [Required] //Obriga preenchimento
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // Muda o texto para *****
        public string Senha { get; set; }

        [Display(Name = "Lembre-me")]
        public bool RememberMe { get; set; }
        public ClaimsIdentity Username { get; internal set; }
    }

   
}
