using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntityAsync();
            ExcluirProdutosAsync();
            RecuperarProdutosAsync();
            Console.ReadKey();
        }

        private static async void ExcluirProdutosAsync()
        {
            using (var context = new LojaContext())
            {
                IList<Produto> produtos = await context.Produtos.ToListAsync();
                foreach(Produto produto in produtos)
                {
                    context.Remove(produto);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async void RecuperarProdutosAsync()
        {
            using (var context = new LojaContext())
            {
                IList<Produto> produtos = await context.Produtos.ToListAsync();
                Console.WriteLine($"Foram encontrados {produtos.Count} produto(s)");
                foreach(var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }
            }
        }

        private static async void GravarUsandoEntityAsync()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new LojaContext())
            {
                context.Produtos.Add(p);
                await context.SaveChangesAsync();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
