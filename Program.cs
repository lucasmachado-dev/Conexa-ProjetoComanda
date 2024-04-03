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
            Console.WriteLine("[7] - Cardápio");
            Console.WriteLine("[8] - Sair");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Quantas mesas o restaurante tem disponível?");
                    int quantidadeMesas = int.Parse(Console.ReadLine());
                    restaurante.AbrirRestaurante(quantidadeMesas);
                    break;
                case 2:
                    Console.Clear();
                    restaurante.ListarMesas();
                    break;
                case 3:
                    Console.Clear();
                    restaurante.ListarMesas();
                    Console.WriteLine("Qual mesa deseja abrir?");
                    int numeroMesaAbrir = int.Parse(Console.ReadLine()) - 1;
                    restaurante.AbrirMesa(numeroMesaAbrir);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Qual mesa?");
                    int numeroMesa = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Nome do produto:");
                    string nomeProduto = Console.ReadLine();
                    Console.WriteLine("Código do produto:");
                    string codigoProduto = Console.ReadLine();
                    Console.WriteLine("Preço do produto:");
                    decimal precoProduto = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Quantidade:");
                    int quantidade = int.Parse(Console.ReadLine());
                    Produto produto = new Produto { Nome = nomeProduto, Codigo = codigoProduto, Preco = precoProduto };
                    restaurante.AdicionarItemNaComanda(numeroMesa, produto, quantidade);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Qual mesa deseja fechar?");
                    int numeroMesaFechar = int.Parse(Console.ReadLine()) - 1;
                    restaurante.FecharMesa(numeroMesaFechar);
                    break;
                case 6:
                    Console.Clear();
                    restaurante.FecharRestaurante();
                    break;
                case 7:
                    Console.Clear();
                    restaurante.ExibirCardapio();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 8);
    }
}
