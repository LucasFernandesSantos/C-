using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DAL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {

        //readonly serve para dizer que o objeto so recebera informaçao no construtor ou na criaçao de objeto;
        private readonly ProdutoDao _produtoDAO;
        public ProdutoController(ProdutoDao produtoDao)
        {
            _produtoDAO = produtoDao;
        }

        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto p)
        {

            _produtoDAO.Cadastrar(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Produto p )
        {
          /*  Produto p = _produtoDAO.BuscarProdutoPorId(Convert.ToInt32(hdnId));
            p.Nome = txtNome;
            p.Preco = Convert.ToDouble(txtPreco);
            p.Descricao = txtDescricao;
            p.Quantidade = Convert.ToInt32(txtQuantidade);*/

            _produtoDAO.Alterar(p);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            
            ViewBag.DataHora = DateTime.Now;
            return View(_produtoDAO.ListarProdutos());
        }
        public IActionResult Remover(int id)
        {
            //remover produto

            _produtoDAO.RemoverProduto(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
         
            return View(_produtoDAO.BuscarProdutoPorId(id));
        }
    }
}