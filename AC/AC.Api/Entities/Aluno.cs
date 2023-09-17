namespace AC.Api.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public int SchoolYear { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime PagamentoValidoAte { get; set; }
    }
}