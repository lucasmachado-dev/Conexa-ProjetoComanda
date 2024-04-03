using System.Globalization;
namespace prjComanda.Models
{
    public class ItemComanda
    {
        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }

    public class Comanda
    {
        private List<ItemComanda> itens = new List<ItemComanda>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = new ItemComanda
            {
                CodigoProduto = produto.Codigo,
                Quantidade = quantidade,
                Descricao = produto.Nome,
                Total = produto.Preco * quantidade
            };

            itens.Add(item);
        }

        public void ListarItensComanda()
        {
            foreach (var item in itens)
            {
                Console.WriteLine($"{item.Descricao.PadRight(30, '.')} - {item.Total.ToString("C", CultureInfo.CurrentCulture)}");
            }
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in itens)
            {
                total += item.Total;
            }
            return total;
        }
    }
}