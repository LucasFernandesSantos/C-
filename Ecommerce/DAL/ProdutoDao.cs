using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class ProdutoDao
    {
        private readonly Context ctx;
        public ProdutoDao(Context context)
        {
            ctx = context;
        }

        public void Cadastrar(Produto p)
        {
            ctx.Produtos.Add(p);
            ctx.SaveChanges();
        }

        public List<Produto> ListarProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }
        public void RemoverProduto(int id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();
        }
        public void Alterar(Produto p)
        {
            ctx.Produtos.Update(p);
            ctx.SaveChanges();
        }

      
    }
}
