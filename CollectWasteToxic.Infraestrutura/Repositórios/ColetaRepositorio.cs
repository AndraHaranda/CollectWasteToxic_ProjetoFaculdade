using CollectToxicWaste.Dados;
using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class ColetaRepositorio : RepositorioBase<Coleta>
    {
        public IEnumerable<Coleta> ListarColeta()
        {
            return Contexto
                .Coleta
                .Where(f => f.IdColeta > 0);
        }
    }
}
