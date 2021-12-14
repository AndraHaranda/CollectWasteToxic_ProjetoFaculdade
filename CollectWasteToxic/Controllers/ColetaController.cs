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

        [HttpGet("listar-coleta")]
        public IEnumerable<Coleta> ListarColeta() => coletaServico.ListarColeta();

        [HttpGet("listar-um")]
        public Coleta ListarUm(int IdColeta) => coletaServico.ListarUm(IdColeta);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Coleta entidade) => coletaServico.Salvar(entidade);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int CodColeta) => coletaServico.Excluir(CodColeta);

        [HttpPut("atualizar")]
        public NotificationResult Atualizar(Coleta entidade) => coletaServico.Atualizar(entidade);
    }
}