using CollectToxicWaste.Dados;
using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class RotaRepositorio : RepositorioBase<Rota>
    {
        public IEnumerable<Rota> ListarRota()
        {
            return Contexto
                .Rota
                .Where(f => f.IdRota > 0);
        }
    }
}
