using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Servico;
using Microsoft.AspNetCore.Mvc;

namespace CollectToxicWaste.Controllers
{

    [ApiController]
    [Route("api/Controller/Rota")]
    public class RotaController : Controller
    {
        private readonly RotaServico rotaServico;

        public RotaController() => rotaServico = new RotaServico();

        [HttpGet("ListarTodos")]
        public IEnumerable<Rota> ListarRotas() => rotaServico.ListarRota();

        [HttpGet("ListarUm")]
        public Rota ListarUm(int IdRota) => rotaServico.ListarUm(IdRota);

        [HttpPost("Adicionar")]
        public NotificationResult Adicionar(Rota entidade) => rotaServico.Adicionar(entidade);

        [HttpDelete("Remover")]
        public NotificationResult Remover(int IdRota) => rotaServico.Remover(IdRota);

        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Rota entidade) => rotaServico.Atualizar(entidade);
    }

}



     
