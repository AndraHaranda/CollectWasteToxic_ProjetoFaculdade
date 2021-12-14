using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Servico;
using Microsoft.AspNetCore.Mvc;

namespace CollectToxicWaste.Controllers
{
    [ApiController]
    [Route("api/Controller/Coleta")]
    public class ColetaController : Controller
    {
        private readonly ColetaServico coletaServico;

        public ColetaController() => coletaServico = new ColetaServico();

        [HttpGet("ListarTodos")]
        public IEnumerable<Coleta> ListarColeta() => coletaServico.ListarColeta();

        [HttpGet("ListarUm")]
        public Coleta ListarUm(int IdColeta) => coletaServico.ListarUm(IdColeta);

        [HttpPost("Adicionar")]
        public NotificationResult Adicionar(Coleta entidade) => coletaServico.Adicionar(entidade);

        [HttpDelete("Remover")]
        public NotificationResult Remover(int IdColeta) => coletaServico.Remover(IdColeta);

        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Coleta entidade) => coletaServico.Atualizar(entidade);
    }
}