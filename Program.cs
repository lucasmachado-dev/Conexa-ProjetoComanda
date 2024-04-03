using prjComanda.Models;

class Program
{
    static void Main(string[] args)
    {
        Restaurante restaurante = new Restaurante();

        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Abrir Restaurante");
            Console.WriteLine("[2] - Listar Mesas");
            Console.WriteLine("[3] - Abrir Mesa");
            Console.WriteLine("[4] - Adicionar Item na Comanda");
            Console.WriteLine("[5] - Fechar Mesa");
            Console.WriteLine("[6] - Fechar Restaurante");
            Console.WriteLine("[7] - Cadastrar Produto");
            Console.WriteLine("[8] - Cardápio");
            Console.WriteLine("[9] - Sair");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    OpcaoAbrirRestaurante();
                    break;
                case 2:
                    OpcaoListarMesas();
                    break;
                case 3:
                    OpcaoAbrirMesa();
                    break;
                case 4:
                    OpcaoAdicionarItemComanda();
                    break;
                case 5:
                    OpcaoFecharMesa();
                    break;
                case 6:
                    Console.Clear();
                    restaurante.FecharRestaurante();
                    break;
                case 7:
                    OpcaoCadastrarProduto();
                    break;
                case 8:
                    Console.Clear();
                    restaurante.ExibirCardapio();
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 9);

        void OpcaoAbrirRestaurante()
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
                Console.ReadKey();
            }
        }

        void OpcaoListarMesas()
        {
            Console.Clear();
            restaurante.ListarMesas();
        }

        void OpcaoAbrirMesa()
        {
            Console.Clear();
            restaurante.ListarMesas();
            Console.WriteLine("Qual mesa deseja abrir?");
            int numeroMesaAbrir = int.Parse(Console.ReadLine()) - 1;
            restaurante.AbrirMesa(numeroMesaAbrir);
        }

        void OpcaoAdicionarItemComanda()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa?");
            int numeroMesa = int.Parse(Console.ReadLine()) - 1;

            if (!restaurante.ExisteMesa(numeroMesa) || !restaurante.MesaAberta(numeroMesa))
            {
                Console.WriteLine("Mesa não encontrada ou não está aberta.");
                Console.ReadKey();
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
                Console.ReadLine();
            }
        }

        void OpcaoFecharMesa()
        {
            Console.Clear();
            Console.WriteLine("Qual mesa deseja fechar?");
            int numeroMesaFechar = int.Parse(Console.ReadLine()) - 1;
            restaurante.FecharMesa(numeroMesaFechar);
        }
        
        void OpcaoCadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Nome do produto:");
            string nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            decimal precoProduto = decimal.Parse(Console.ReadLine());
            restaurante.CadastrarProduto(nomeProduto, precoProduto);
        }
    }


}
