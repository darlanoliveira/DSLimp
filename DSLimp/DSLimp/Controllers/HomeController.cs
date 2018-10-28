using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DSLimp.Modulos;
using DSLimp.Models;

namespace DSLimp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login(string email, string senha)
        {
            if(email == "123")
            {
                return RedirectToAction("cadastrocliente");
            }

            return View();
        }

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

        public IActionResult Financeiro()
        {
          

            return View();
        }

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

        public IActionResult cadastroproduto()
        {


            return View();
        }

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
