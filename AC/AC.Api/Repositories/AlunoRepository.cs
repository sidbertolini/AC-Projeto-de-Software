using AC.Api.Data;
using AC.Api.Entities;
using Microsoft.EntityFrameworkCore;
using AC.Models;
using AC.Models.DTOs;

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
            if(result != 0)
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
    }
}