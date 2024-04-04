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

            opcaoSelecionada = (OpcaoSelecionada)int.Parse(Console.ReadLine());
            

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
            catch
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
            int numeroMesaAbrir = int.Parse(Console.ReadLine()) - 1;
            restaurante.AbrirMesa(numeroMesaAbrir);
        }

        void AdicionarItemComanda()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa?");
            int numeroMesa = int.Parse(Console.ReadLine()) - 1;

            if (!restaurante.ExisteMesa(numeroMesa) || !restaurante.MesaAberta(numeroMesa))
            {
                Console.WriteLine("Mesa não encontrada ou não está aberta.");
                Util.Continuar();
            }
            else
            {

                restaurante.ExibirCardapio();
                Console.WriteLine("");
                Console.WriteLine("Código do produto:");
                string codigoProduto = Console.ReadLine();

                Produto p1 = restaurante.BuscarProduto(codigoProduto);
                if (p1 != null)
                {
                    string nomeProduto = p1.Nome;
                    decimal precoProduto = p1.Preco;
                    Console.WriteLine("Quantidade:");
                    int quantidade = int.Parse(Console.ReadLine());
                    Produto produto = new Produto { Nome = nomeProduto, Codigo = codigoProduto, Preco = precoProduto };
                    restaurante.AdicionarItemNaComanda(numeroMesa, produto, quantidade);
                }
                
            }
        }

        void FecharMesa()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa deseja fechar?");
            int numeroMesaFechar = int.Parse(Console.ReadLine()) - 1;
            restaurante.FecharMesa(numeroMesaFechar);
        }
        
        void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Nome do produto:");
            string nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            decimal precoProduto = decimal.Parse(Console.ReadLine());
            restaurante.CadastrarProduto(nomeProduto, precoProduto);
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
