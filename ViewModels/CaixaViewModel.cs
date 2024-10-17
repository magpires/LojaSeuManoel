namespace ViewModels
{
    public class CaixaViewModel
    {
        public string? Caixa_id { get; set; }
        public List<string> Produtos { get; set; } = new List<string>();
        public string? Observacao { get; set; }
    }
}
