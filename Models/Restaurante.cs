﻿using System.Globalization;
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
                for (int i = 0; i < quantidadeMesas; i++)
                {
                    mesas.Add(new Mesa());
                }
                Console.WriteLine("Restaurante aberto com sucesso!");
            }
            else
            {
                Console.WriteLine("A quantidade de mesas deve ser maior que zero");
            }
            Console.ReadKey();
        }

        public void ListarMesas()
        {
            for (int i = 0; i < mesas.Count; i++)
            {
                Console.WriteLine($"Mesa {i + 1} - {(mesas[i].Ocupada ? "Ocupada" : "Disponível")}");

            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void AbrirMesa(int numeroMesa)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                mesas[numeroMesa].Ocupada = true;
                mesas[numeroMesa].Comanda = new Comanda();
                Console.WriteLine($"Mesa {numeroMesa + 1} aberta com sucesso!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Console.ReadLine();
            }
        }

        public void AdicionarItemNaComanda(int numeroMesa, Produto produto, int quantidade)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                Mesa mesa = mesas[numeroMesa];
                if (mesa.Ocupada)
                {
                    mesa.Comanda.AdicionarItem(produto, quantidade);
                    Console.WriteLine($"Item adicionado à comanda da mesa {numeroMesa + 1}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Esta mesa não está ocupada!");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Console.ReadLine();
            }
        }

        public void FecharMesa(int numeroMesa)
        {
            if (numeroMesa >= 0 && numeroMesa < mesas.Count)
            {
                Mesa mesa = mesas[numeroMesa];
                if (mesa.Ocupada)
                {
                    {
                        if (mesa.Ocupada)
                        {
                            TotalVendas += mesa.Comanda.CalcularTotal();
                            mesa.Ocupada = false;
                        }
                    }


                    mesa.Ocupada = false;
                    decimal totalMesa = mesa.Comanda.CalcularTotal();
                    TotalVendas = TotalVendas + totalMesa;
                    mesa.Comanda.ListarItensComanda();
                    Console.WriteLine("".PadRight(40, '-'));
                    Console.WriteLine($"Total da mesa {numeroMesa + 1}: R${totalMesa}");
                    Console.WriteLine($"Mesa {numeroMesa + 1} fechada com sucesso!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Esta mesa não está ocupada!");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Console.ReadLine();
            }
        }

        public void FecharRestaurante()
        {
            foreach (Mesa mesa in mesas)
            {
                if (mesa.Ocupada)
                {
                    TotalVendas += mesa.Comanda.CalcularTotal();
                    mesa.Ocupada = false;
                }
            }
            Console.WriteLine($"Total de vendas do dia: R${TotalVendas}");
            Console.ReadLine();
        }

        public void CriarProdutos()
        {
            produtos.Add(new Produto() { Codigo = "1", Nome = "Cerveja 600ML", Preco = 12.9M });
            produtos.Add(new Produto() { Codigo = "2", Nome = "Refrigerante lata", Preco = 5.5M });
            produtos.Add(new Produto() { Codigo = "3", Nome = "Batata Frita 500g", Preco = 28.9M });
            produtos.Add(new Produto() { Codigo = "4", Nome = "Água", Preco = 5M });
            produtos.Add(new Produto() { Codigo = "5", Nome = "Sanduíche", Preco = 10.9M });
            produtos.Add(new Produto() { Codigo = "6", Nome = "Suco (Copo 300ml)", Preco = 7.9M });
        }

        public void ExibirCardapio()
        {
            Console.WriteLine("");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{produtos[i].Codigo.PadLeft(5, ' ')} : {produtos[i].Nome.PadRight(30, '.')} - {produtos[i].Preco.ToString("C", CultureInfo.CurrentCulture)}");
            }
        }

        public void CadastrarProduto(string nome, decimal preco)
        {
            int codigo = produtos.Count;
            produtos.Add(new Produto() { Codigo = codigo.ToString(), Nome = nome, Preco = preco });
        }

        public Produto BuscarProduto(string codigo)
        {
            Produto prod = produtos.Find(p => p.Codigo == codigo);
            if (prod != null)
            {
                return prod;
            }
            {
                Console.WriteLine("Produto não encontrado.");
                return null;
            }
        }

        public bool ExisteMesa(int codigo)
        {
            Console.WriteLine(codigo);
            Console.WriteLine("aaa");
            return (codigo >= 0 && codigo < mesas.Count);
        }

        public bool MesaAberta(int codigo)
        {
            Console.WriteLine(codigo);
            return (mesas[codigo].Ocupada);
        }
    }

}
