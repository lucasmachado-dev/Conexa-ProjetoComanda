using System;
using System.Collections.Generic;
using System.Linq;

namespace prjComanda.Models
{
    public class Restaurante
    {
        private List<Mesa> mesas = new List<Mesa>();
        private List<Produto> produtos = new List<Produto>();
        public decimal TotalVendas = 0;

        public Restaurante()
        {
            CriarProdutos();
        }

        public void AbrirRestaurante(int quantidadeMesas)
        {
            if (quantidadeMesas > 0)
            {
                TotalVendas = 0;
                mesas.AddRange(Enumerable.Range(0, quantidadeMesas).Select(_ => new Mesa()));
                Console.WriteLine("Restaurante aberto com sucesso!");
            }
            else
            {
                Console.WriteLine("A quantidade de mesas deve ser maior que zero");
            }
            Util.Continuar();
        }

        public void ListarMesas(bool continuar = true)
        {
            foreach (var mesa in mesas)
            {
                Console.WriteLine($"Mesa {mesas.IndexOf(mesa) + 1} - {(mesa.Ocupada ? "Ocupada" : "Disponível")}");
            }
            if (continuar)
            {
                Util.Continuar();
            }
        }

        public void AbrirMesa(int numeroMesa)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                mesas[numeroMesa].Ocupada = true;
                mesas[numeroMesa].Comanda = new Comanda();
                Console.WriteLine($"Mesa {numeroMesa + 1} aberta com sucesso!");
                Util.Continuar();
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Util.Continuar();
            }
        }

        public void AdicionarItemNaComanda(int numeroMesa, Produto produto, int quantidade)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                var mesa = mesas[numeroMesa];
                if (mesa.Ocupada)
                {
                    mesa.Comanda.AdicionarItem(produto, quantidade);
                    Console.WriteLine($"Item adicionado à comanda da mesa {numeroMesa + 1}");
                    Util.Continuar();
                }
                else
                {
                    Console.WriteLine("Esta mesa não está ocupada!");
                    Util.Continuar();
                }
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Util.Continuar();
            }
        }

        public void FecharMesa(int numeroMesa)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                var mesa = mesas[numeroMesa];
                if (mesa.Ocupada)
                {
                    mesa.Ocupada = false;
                    decimal totalMesa = mesa.Comanda.CalcularTotal();
                    TotalVendas += totalMesa;
                    mesa.Comanda.ListarItensComanda();
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Total da mesa {numeroMesa + 1}: R${totalMesa}");
                    Console.WriteLine($"Mesa {numeroMesa + 1} fechada com sucesso!");
                    Util.Continuar();
                }
                else
                {
                    Console.WriteLine("Esta mesa não está ocupada!");
                    Util.Continuar();
                }
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Util.Continuar();
            }
        }

        public void FecharRestaurante()
        {
            TotalVendas += mesas.Where(m => m.Ocupada).Sum(m => m.Comanda.CalcularTotal());
            Console.WriteLine($"Total de vendas do dia: R${TotalVendas}");
            mesas.Clear();
            Util.Continuar();
        }

        public void CriarProdutos()
        {
            produtos.AddRange(new List<Produto>
            {
                new Produto() { Codigo = "1", Nome = "Cerveja 600ML", Preco = 12.9M },
                new Produto() { Codigo = "2", Nome = "Refrigerante lata", Preco = 5.5M },
                new Produto() { Codigo = "3", Nome = "Batata Frita 500g", Preco = 28.9M },
                new Produto() { Codigo = "4", Nome = "Água", Preco = 5M },
                new Produto() { Codigo = "5", Nome = "Sanduíche", Preco = 10.9M },
                new Produto() { Codigo = "6", Nome = "Suco (Copo 300ml)", Preco = 7.9M }
            });
        }

        public void ExibirCardapio()
        {
            Util.CabecalhoMenu("Cardápio");
            Console.WriteLine();
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Codigo.PadLeft(5, ' ')} : {produto.Nome.PadRight(30, '.')} - {produto.Preco.ToString("C")}");
            }
        }

        public void CadastrarProduto(string nome, decimal preco)
        {
            produtos.Add(new Produto() { Codigo = (produtos.Count + 1).ToString(), Nome = nome, Preco = preco });
        }

        public Produto BuscarProduto(string codigo)
        {
            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);
            if (produto != null)
            {
                return produto;
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
                return null;
            }
        }

        public bool ExisteMesa(int codigo)
        {
            return (codigo >= 0 && codigo < mesas.Count);
        }

        public bool MesaAberta(int codigo)
        {
            return (mesas[codigo].Ocupada);
        }
    }
}
