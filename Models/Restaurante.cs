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
            TotalVendas = 0;
            for (int i = 0; i < quantidadeMesas; i++)
            {
                mesas.Add(new Mesa());
            }
            Console.WriteLine("Restaurante aberto com sucesso!");
            Console.ReadLine();
        }

        public void ListarMesas()
        {
            for (int i = 0; i < mesas.Count; i++)
            {
                Console.WriteLine($"Mesa {i + 1} - {(mesas[i].Ocupada ? "Ocupada" : "Disponível")}");
                
            }
            Console.ReadLine();
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
            produtos.Add(new Produto() { Codigo = "1", Nome = "Cerveja 600ML", Preco = 12.9M} );
            produtos.Add(new Produto() { Codigo = "2", Nome = "Refrigerante lata", Preco = 5.5M });
            produtos.Add(new Produto() { Codigo = "3", Nome = "Batata Frita 500g", Preco = 28.9M });
            produtos.Add(new Produto() { Codigo = "4", Nome = "Água", Preco = 5M });
            produtos.Add(new Produto() { Codigo = "5", Nome = "Sanduíche", Preco = 10.9M });
        }

        public void ExibirCardapio()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{produtos[i].Nome.PadRight(20,'.')} - {produtos[i].Preco} ");
            }
            Console.ReadLine();
        }
    }

}
