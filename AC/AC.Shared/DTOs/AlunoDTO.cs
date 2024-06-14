using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Models.DTOs
{
    public class AlunoDTO
    {
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime PagamentoValidoAte { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}