using AC.Models.DTOs;

namespace AC.Web.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAlunos();
        Task CadastrarAluno(AlunoDTO alunoDTO);
    }
}