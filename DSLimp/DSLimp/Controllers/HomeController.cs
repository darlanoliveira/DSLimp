using DSLimp.Models;
using DSLimp.Modulos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace DSLimp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("resumodiario");
        }



        public LoginViewModel loginData { get; set; }

        public IActionResult Login(string email, string senha)
        {
            if (email == "123")
            {
                return RedirectToAction("resumodiario");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModel vm)
        {


            if (ModelState.IsValid)
            {
                 var isValid = (vm.Email == "usuario@usuario.com" && vm.Senha == "123");
               // var isValid = HomeModel.RecuperarUsuario(vm.Email, vm.Senha);
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
        public IActionResult resumodiario()
        {


            ViewBag.titulo = "Resumo";

            return View();
        }

        [Authorize]
        public IActionResult estoque()
        {
            ViewBag.titulo = "Estoque";

            return View();
        }

        [Authorize]
        public IActionResult vendas(string cliente)
        {
            //Parte responsável pelos dados dos clientes
            ViewBag.cli_nome = "";
            ViewBag.cli_cnpj = "";
            ViewBag.cli_end = "";
            ViewBag.cli_ref = "";

            ViewBag.cont = 0;
            
            if (cliente != null)
            {
                if (cliente.Length > 0)
                {
                    ViewBag.cliente = HomeModel.BuscaCliente(cliente);
                    foreach(var item in ViewBag.cliente)
                    {
                        ViewBag.cli_nome = item.Cli_Nome.ToString();
                        ViewBag.cli_cnpj = item.Cli_Cnpj.ToString();
                        ViewBag.cli_end = item.Cli_End.ToString();
                        ViewBag.cli_ref = item.Cli_Ref.ToString();
                    }
                }
            }

            ViewBag.lista = HomeModel.RecuperarClientes();

            //---------------------------------------------------------------------------//

            //Parte responsável por buscar os produtos

            ViewBag.listaProdutos = HomeModel.RecuperarProdutos();
            ViewBag.qtd = 0;


            //----------------------------------------//


            ViewBag.titulo = "Vendas";
            
            return View();
        }

        [Authorize]
        public IActionResult cadastrocliente(int salvo)
        {
            //Viewbag que define se algo acabou de ser salvo
            ViewBag.Salvo = 0;
            ViewBag.titulo = "Clientes";

            ViewBag.listaDeClientes = HomeModel.RecuperarClientes();

            if(salvo == 1)
            {
                ViewBag.Salvo = 1;     
            }   

            return View();
        }
        [Authorize]
        public IActionResult Financeiro(DateTime inicial, DateTime final)
        {
            ViewBag.titulo = "Financeiro";

            ViewBag.listaGasto = new List<dynamic>();
            if (inicial != null)
            {
                ViewBag.listaGasto = HomeModel.GastoData(inicial, final);
            }    

            return View();
        }

        [Authorize]
        public IActionResult Agenda()
        {
            ViewBag.titulo = "Agenda";

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
            ViewBag.listaDeProdutos = HomeModel.RecuperarProdutos();
            ViewBag.titulo = "Produtos";

            return View();
        }

        public IActionResult CadastroGastos()
        {
            ViewBag.titulo = "Gastos";
            ViewBag.listaDeGastos = HomeModel.RecuperarGastos();
            return View();
        }

          [HttpPost]
          public IActionResult SalvarGastos(string descricaogasto,string valorgasto,IFormFile notafiscal,IFormFile recibo,DateTime datagasto)
          {
            var valorgastoD = double.Parse(valorgasto, System.Globalization.CultureInfo.InvariantCulture);

            var arquivoNF = notafiscal.OpenReadStream();
            MemoryStream flnf = new MemoryStream();
            arquivoNF.CopyTo(flnf);
            byte[] nfArr = flnf.ToArray();

            var arquivoRec = recibo.OpenReadStream();
            MemoryStream flrec = new MemoryStream();
            arquivoRec.CopyTo(flrec);
            byte[] recArr = flrec.ToArray();

            HomeModel.SalvaGastos(descricaogasto, valorgastoD, nfArr, recArr,datagasto);

            return RedirectToAction("financeiro");
          }


        [Authorize]
        public IActionResult salvarproduto(string descricaoproduto,string valorcusto,string valorvenda,string linhaproduto,IFormFile fotoproduto,string pesquisa,int salvar,int cancelar,int pesquisar)
        {
            if(salvar == 1)
            {
                var valorcustoD = double.Parse(valorcusto, System.Globalization.CultureInfo.InvariantCulture);
                var valorvendaD = double.Parse(valorvenda, System.Globalization.CultureInfo.InvariantCulture);

                var arquivo = fotoproduto.OpenReadStream();
                MemoryStream fl = new MemoryStream();
                arquivo.CopyTo(fl);
                byte[] ftArr = fl.ToArray();

                HomeModel.SalvaProduto(descricaoproduto, valorcustoD, valorvendaD, linhaproduto,ftArr);
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
