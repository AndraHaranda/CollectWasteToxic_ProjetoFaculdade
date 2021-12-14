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

        [HttpGet("Listar-Usuarios")]
        public IEnumerable<Usuario> ListarUsuarios() => usuarioServico.ListarUsuarios();

        [HttpGet("Listar-um")]
        public Usuario ListarUm(int IdUsuario) => usuarioServico.ListarUm(IdUsuario);

        [HttpPost("Salvar")]
        public NotificationResult Salvar(Usuario entidade) => usuarioServico.Salvar(entidade);

        [HttpDelete("Excluir")]
        public NotificationResult Excluir(int CodUsuario) => usuarioServico.Excluir(CodUsuario);

        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Usuario entidade) => usuarioServico.Atualizar(entidade);
    }

}