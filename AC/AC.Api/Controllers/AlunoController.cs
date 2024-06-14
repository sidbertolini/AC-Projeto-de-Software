using AC.Api.Entities;
using AC.Api.Mappings;
using AC.Api.Repositories;
using AC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;

        public AlunoController(IAlunoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> GetAlunos()
        {
            var alunos = await _repository.GetAll();
            if (alunos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(alunos.ConverterAlunosParaDTO());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAluno(AlunoDTO aluno)
        {
            if (aluno != null)
            {
				var alunodb = new Aluno
				{
					Name = aluno.Nome,
					School = aluno.Unidade,
                    PagamentoValidoAte = aluno.DataPagamento.AddMonths(1),
                    DataPagamento = aluno.DataPagamento,
                    Birthdate = aluno.DataDeNascimento,
                    Address = "",
				};

				await _repository.CadastrarAlunoAsync(alunodb);
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        [Route("RemoverAluno")]
        public async Task<ActionResult> RemoverAluno(AlunoDTO aluno)
        {
            if (aluno != null)
            {
                var alunodb = new Aluno
                {
                    Name = aluno.Nome,
                    School = aluno.Unidade,
                    PagamentoValidoAte = new DateTime(),
                    DataPagamento = aluno.DataPagamento,
                    Birthdate = aluno.DataDeNascimento,
                    Address = "",
                };

                await _repository.RemoverAluno(alunodb);
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}