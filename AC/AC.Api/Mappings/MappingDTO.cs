using AC.Api.Entities;
using AC.Models.DTOs;

namespace AC.Api.Mappings
{
    public static class MappingDTOs
    {
        public static IEnumerable<AlunoDTO> ConverterAlunosParaDTO(this IEnumerable<Aluno> alunos)
        {
            return (from aluno in alunos
                    select new AlunoDTO
                    {
                        Nome = aluno.Name,
                        Unidade = aluno.School,
                        DataPagamento = aluno.DataPagamento,
                        PagamentoValidoAte = aluno.PagamentoValidoAte
                    }).ToList();
        }
    }
}