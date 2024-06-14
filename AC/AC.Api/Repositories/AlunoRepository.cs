using AC.Api.Data;
using AC.Api.Entities;
using AC.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AC.Api.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarAlunoAsync(AlunoDTO aluno)
        {
            _context.Add(aluno);
            var result = await _context.SaveChangesAsync();
            if (result != 0)
            {
                await Task.CompletedTask;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> GetById(int id)
        {
            if (id != 0)
            {
                return await _context.Alunos.SingleOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        //public async Task RemoveAluno(AlunoDTO aluno)
        //{
        //    if (aluno != null)
        //    {
        //        var alunodb = await _context.Alunos.FirstOrDefaultAsync(x => x.Name == aluno.Nome);
        //        if (alunodb != null)
        //        {
        //            _context.Remove(alunodb);
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException(nameof(aluno));
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(aluno));
        //    }
        //}

        public async Task RemoverAluno(Aluno aluno)
        {
            var alunoDto = new AlunoDTO { Nome = aluno.Name };
            if (aluno != null)
            {
                var alunodb = await _context.Alunos.FirstOrDefaultAsync(x => x.Name == alunoDto.Nome);
                if (alunodb != null)
                {
                    _context.Remove(alunodb);
                    var result = await _context.SaveChangesAsync();
                    if (result != 0)
                    {
                        await Task.CompletedTask;
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(aluno));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(aluno));
            }
        }
    }
}