namespace Models
{
    public class Caixa
    {
        public Caixa(string caixa_id, int altura, int largura, int comprimento)
        {
            Caixa_Id = caixa_id;
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }

        public string Caixa_Id { get; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}
