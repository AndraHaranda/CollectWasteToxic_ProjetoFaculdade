using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Servico;
using Microsoft.AspNetCore.Mvc;

namespace CollectToxicWaste.Controllers
{
    [ApiController]
    [Route("api/Controller/Transporte")]
    public class TransporteController : Controller
    {
        private readonly TransporteServico transporteServico;

        public TransporteController() => transporteServico = new TransporteServico();

        [HttpGet("Listar-transporte")]
        public IEnumerable<Transporte> ListarTransportes() => transporteServico.ListarTransporte();

        [HttpGet("Listar-um")]
        public Transporte ListarUm(int IdTransporte) => transporteServico.ListarUm(IdTransporte);

        [HttpPost("Salvar")]
        public NotificationResult Salvar(Transporte entidade) => transporteServico.Salvar(entidade);

        [HttpDelete("Excluir")]
        public NotificationResult Excluir(int IdTransporte) => transporteServico.Excluir(IdTransporte);

        [HttpPut("atualizar")]
        public NotificationResult Atualizar(Transporte entidade) => transporteServico.Atualizar(entidade);
    }

}
