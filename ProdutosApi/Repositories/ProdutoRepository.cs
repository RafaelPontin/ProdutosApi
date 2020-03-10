using ProdutosApi.DataBase;
using ProdutosApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosApi.Repositories
{
    public class ProdutoRepository : IDisposable
    {

        private Context context;

        public ProdutoRepository()
        {
            context = new Context();
        }

        public void Add(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public void Remove(Produto produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
        }

        public Produto Find(int id)
        {
            Produto produto = (Produto) context.Produtos.Where(p => p.Id == id).FirstOrDefault();
            return produto;
        }


        public IList<Produto> GetAll()
        {
            IList<Produto> produtos = (IList<Produto>) context.Produtos.ToList();
            return produtos;
        }


        public void Dispose()
        {
            context.Dispose();
            context = null;
        }
        
    }
}
