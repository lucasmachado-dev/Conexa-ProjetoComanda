using prjComanda;
using prjComanda.Models;

class Program
{
    static void Main(string[] args)
    {
        Restaurante restaurante = new Restaurante();

        OpcaoSelecionada opcaoSelecionada;
        
        
        do
        {
            Console.Clear();
            Util.CabecalhoMenu("Menu");
            Console.WriteLine("[1] - Abrir Restaurante");
            Console.WriteLine("[2] - Listar Mesas");
            Console.WriteLine("[3] - Abrir Mesa");
            Console.WriteLine("[4] - Adicionar Item na Comanda");
            Console.WriteLine("[5] - Fechar Mesa");
            Console.WriteLine("[6] - Fechar Restaurante");
            Console.WriteLine("[7] - Cadastrar Produto");
            Console.WriteLine("[8] - Cardápio");
            Console.WriteLine("[9] - Sair");

            opcaoSelecionada = LerOpcao(); 
            

            switch (opcaoSelecionada)
            {
                case OpcaoSelecionada.AbrirRestaurante:
                    AbrirRestaurante();
                    break;
                case OpcaoSelecionada.ListarMesas:
                    ListarMesas();
                    break;
                case OpcaoSelecionada.AbrirMesa:
                    AbrirMesa();
                    break;
                case OpcaoSelecionada.AdicionarItemComanda:
                    AdicionarItemComanda();
                    break;
                case OpcaoSelecionada.FecharMesa:
                    FecharMesa();
                    break;
                case OpcaoSelecionada.FecharRestaurante:
                    Console.Clear();
                    restaurante.FecharRestaurante();
                    break;
                case OpcaoSelecionada.CadastrarProduto:
                    CadastrarProduto();
                    break;
                case OpcaoSelecionada.Cardapio:
                    Console.Clear();
                    restaurante.ExibirCardapio();
                    Util.Continuar();
                    break;
                case OpcaoSelecionada.Sair:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcaoSelecionada != OpcaoSelecionada.Sair);

        void AbrirRestaurante()
        {
            Console.Clear();
            Console.WriteLine("Quantas mesas o restaurante tem disponível?");
            try
            {
                int quantidadeMesas = int.Parse(Console.ReadLine());
                restaurante.AbrirRestaurante(quantidadeMesas);

            }
            catch (FormatException)
            {
                Console.WriteLine("*** Erro ao tentar abrir o restaurante ***");
                Console.WriteLine("Verifique se você digitou a quantidade de mesas corretamente.");
                Util.Continuar();
            }
        }

        void ListarMesas()
        {
            Console.Clear();
            restaurante.ListarMesas();
        }

        void AbrirMesa()
        {
            Console.Clear();
            restaurante.ListarMesas(false);
            Console.WriteLine("Qual mesa deseja abrir?");
            int numeroMesaAbrir;
            if (int.TryParse(Console.ReadLine(), out numeroMesaAbrir) && restaurante.ExisteMesa(numeroMesaAbrir - 1))
            {
                restaurante.AbrirMesa(numeroMesaAbrir - 1);
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
                Util.Continuar();
            }
        }

        void AdicionarItemComanda()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa?");
            int numeroMesa;
            if (int.TryParse(Console.ReadLine(), out numeroMesa) && restaurante.ExisteMesa(numeroMesa - 1) && restaurante.MesaAberta(numeroMesa - 1))
            {
                restaurante.ExibirCardapio();
                Console.WriteLine("Código do produto:");
                string codigoProduto = Console.ReadLine();

                Produto p1 = restaurante.BuscarProduto(codigoProduto);
                if (p1 != null)
                {
                    Console.WriteLine("Quantidade:");
                    if (int.TryParse(Console.ReadLine(), out int quantidade))
                    {
                        Produto produto = new Produto { Nome = p1.Nome, Codigo = p1.Codigo, Preco = p1.Preco };
                        restaurante.AdicionarItemNaComanda(numeroMesa - 1, produto, quantidade);
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida!");
                        Util.Continuar();
                    }
                }
            }
            else
            {
                Console.WriteLine("Mesa não encontrada ou não está aberta.");
                Util.Continuar();
            }
        }

        void FecharMesa()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa deseja fechar?");
            int numeroMesaFechar;
            if (int.TryParse(Console.ReadLine(), out numeroMesaFechar) && restaurante.ExisteMesa(numeroMesaFechar - 1))
            {
                restaurante.FecharMesa(numeroMesaFechar - 1);
            }
            else
            {
                Console.WriteLine("Mesa inválida!");
            }
        }
        
        void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Nome do produto:");
            string nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            if (decimal.TryParse(Console.ReadLine(), out decimal precoProduto))
            {
                restaurante.CadastrarProduto(nomeProduto, precoProduto);
            }
            else
            {
                Console.WriteLine("Preço inválido!");
                Util.Continuar();
            }
        }

    }

    private static OpcaoSelecionada LerOpcao()
    {
        Console.WriteLine("Escolha uma opção:");
        try
        {
            return (OpcaoSelecionada)int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Opção inválida! Digite apenas números.");
            Console.ReadKey();
            return OpcaoSelecionada.Sair;
        }
    }

    enum OpcaoSelecionada
    {
        AbrirRestaurante = 1,
        ListarMesas,
        AbrirMesa,
        AdicionarItemComanda,
        FecharMesa,
        FecharRestaurante,
        CadastrarProduto,
        Cardapio,
        Sair
    }


}
