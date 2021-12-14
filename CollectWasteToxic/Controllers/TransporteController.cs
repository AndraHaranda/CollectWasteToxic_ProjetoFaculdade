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

        [HttpGet("ListarTodos")]
        public IEnumerable<Transporte> ListarTransportes() => transporteServico.ListarTransporte();

        [HttpGet("ListarUm")]
        public Transporte ListarUm(int IdTransporte) => transporteServico.ListarUm(IdTransporte);

        [HttpPost("Adicionar")]
        public NotificationResult Adicionar(Transporte entidade) => transporteServico.Adicionar(entidade);

        [HttpDelete("Remover")]
        public NotificationResult Remover(int IdTransporte) => transporteServico.Remover(IdTransporte);

        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Transporte entidade) => transporteServico.Atualizar(entidade);
    }

}
