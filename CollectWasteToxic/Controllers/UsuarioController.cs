using CollectToxicWaste.Comum.NotificationPattern;
using CollectToxicWaste.Dominio.Entidades;
using CollectToxicWaste.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectToxicWaste.Controllers
{
    [ApiController]
    [Route("api/Controller/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioServico usuarioServico;

        public UsuarioController() => usuarioServico = new UsuarioServico();

        [HttpGet("ListarTodos")]
        public IEnumerable<Usuario> ListarUsuarios() => usuarioServico.ListarUsuarios();

        [HttpGet("ListarUm")]
        public Usuario ListarUm(int IdUsuario) => usuarioServico.ListarUm(IdUsuario);

        [HttpPost("Adicionar")]
        public NotificationResult Adicionar(Usuario entidade) => usuarioServico.Adicionar(entidade);

        [HttpDelete("Remover")]
        public NotificationResult Remover(int IdUsuario) => usuarioServico.Remover(IdUsuario);

        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Usuario entidade) => usuarioServico.Atualizar(entidade);
    }

}