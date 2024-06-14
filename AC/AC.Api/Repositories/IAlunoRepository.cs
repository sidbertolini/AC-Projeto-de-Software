using AC.Api.Entities;
using AC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll();

        Task<Aluno> GetById(int id);

        Task CadastrarAlunoAsync(Aluno aluno);

        Task RemoverAluno(Aluno aluno);
    }
}