using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CollectToxicWaste.Dominio.Entidades;

namespace CollectToxicWaste.Dados
{
    /// <summary>
    /// Buscar todos os usuarios que o Código é maior que zero (todos)
    /// </summary>
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarUsuarios()
        {
            return Contexto
                .Usuario
                .Where(f => f.IdUsuario > 0);
        }
    }

}
