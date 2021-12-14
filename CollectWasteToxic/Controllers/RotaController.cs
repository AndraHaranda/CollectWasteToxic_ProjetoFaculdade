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

        [HttpGet("listar-Rota")]
        public IEnumerable<Rota> ListarRotas() => rotaServico.ListarRota();

        [HttpGet("listar-um")]
        public Rota ListarUm(int IdRota) => rotaServico.ListarUm(IdRota);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Rota entidade) => rotaServico.Salvar(entidade);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int IdRota) => rotaServico.Excluir(IdRota);

        [HttpPut("atualizar")]
        public NotificationResult Atualizar(Rota entidade) => rotaServico.Atualizar(entidade);
    }

}



     
