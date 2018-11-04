using DSLimp.Models;
using DSLimp.Modulos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSLimp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("cadastrocliente");
        }



        public LoginViewModel loginData { get; set; }

        public IActionResult Login(string email, string senha)
        {
            if (email == "123")
            {
                return RedirectToAction("cadastrocliente");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModel vm)
        {


            if (ModelState.IsValid)
            {
                var isValid = (vm.Email == "usuario@usuario.com" && vm.Senha == "123");
                if(!isValid)
                {
                    ModelState.AddModelError("", "Usuário ou senha inválido");
                    return RedirectToAction("Login");
                }

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, vm.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, vm.Email));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = vm.RememberMe });
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "username or password is blank");
                return RedirectToAction("Login");
            }


            return View();
        }

        public async Task<IActionResult> Deslogar()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult cadastrocliente(int salvo)
        {
            //Viewbag que define se algo acabou de ser salvo
            ViewBag.Salvo = 0;

            if(salvo == 1)
            {
                ViewBag.Salvo = 1;     
            }   

            return View();
        }
        [Authorize]
        public IActionResult Financeiro()
        {
          

            return View();
        }
        [Authorize]
        public IActionResult salvarcliente(string nomecli, string contatocli, string bairro, string cidade, string telefone,
            string cnpj, string endereco, string pontoreferencia, string pesquisa,int btncancelar,int btnsalvar,int btnpesquisa)
        {
            if(btncancelar == 1) // Caso usuário clique no botão cancelar
            {
                return RedirectToAction("cadastrocliente");
            }

            if(btnsalvar == 1) // Caso usuário clique no botão salvar
            {
                Modulos.HomeModel.SalvaCliente(nomecli, contatocli, bairro, cidade, telefone, cnpj, endereco, pontoreferencia);
                return RedirectToAction("cadastrocliente");
            }

            if(btnpesquisa == 1) // Caso usuário clique no botão de pesquisa
            {

            }

            return View();
           
        }
        [Authorize]
        public IActionResult CadastroProduto()
        {


            return View();
        }

        public IActionResult CadastroGastos()
        {


            return View();
        }

        /*  [HttpPost]
          public IActionResult SalvaGastos(string descricaogasto,double valorgasto, IFormfile notafiscal,IFormfile recibo)
          {

              return RedirectToAction("financeiro");
          }*/


        [Authorize]
        public IActionResult salvarproduto(string descricaoproduto,double valorcusto,double valorvenda,string telefone,string cnpj,string endereco,string pontoreferencia,string pesquisa,int salvar,int cancelar,int pesquisar)
        {
            if(salvar == 1)
            {
                HomeModel.SalvaProduto(descricaoproduto, valorcusto, valorvenda, telefone, cnpj, endereco, pontoreferencia);
                return RedirectToAction("cadastroproduto");
            }
            if(cancelar == 1)
            {
                return RedirectToAction("cadastroproduto");
            }
            if(pesquisar == 1)
            {
                return RedirectToAction("cadastroproduto");
            }

            return RedirectToAction("cadastroproduto");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
