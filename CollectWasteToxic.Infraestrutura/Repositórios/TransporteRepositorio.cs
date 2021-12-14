using CollectToxicWaste.Dados;
using CollectToxicWaste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Infraestrutura.Repositórios
{
    public class TransporteRepositorio : RepositorioBase<Transporte>
    {
        public IEnumerable<Transporte> ListarTransporte()
        {
            return Contexto
                .Transporte
                .Where(f => f.IdTransporte > 0);
        }
    }
}

