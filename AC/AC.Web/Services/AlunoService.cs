using AC.Models.DTOs;
using System.Net.Http.Json;

namespace AC.Web.Services
{
    public class AlunoService : IAlunoService
    {
        public HttpClient _httpClient { get; set; }
        public ILogger<AlunoService> _logger { get; set; }

        public AlunoService(HttpClient httpClient, ILogger<AlunoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<AlunoDTO>> GetAlunos()
        {
            try
            {
                var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<AlunoDTO>>("api/aluno");
                if (alunos != null)
                {
                    return alunos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }

            return null;
        }
		public async Task CadastrarAluno(AlunoDTO alunoDTO)
        {
			try
			{
				await _httpClient.PostAsJsonAsync("api/aluno", alunoDTO);
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message);
				throw;
			}
		}

        public async Task RemoverAluno(AlunoDTO alunoDTO)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/aluno/RemoverAluno", alunoDTO);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }
    }
}