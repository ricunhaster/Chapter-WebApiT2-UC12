using System.ComponentModel.DataAnnotations;

namespace Chapter.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-email do usuário")]
        public string  email { get; set; }

        [Required(ErrorMessage =  "Informe a senha do usuário")]
        public string senha { get; set; }
    }
}
