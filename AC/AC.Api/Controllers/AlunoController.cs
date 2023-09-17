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
                await _repository.CadastrarAlunoAsync(aluno);
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}