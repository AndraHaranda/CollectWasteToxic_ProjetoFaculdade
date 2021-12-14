using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Transporte 
    {
        [Key]
        public int IdTransporte { get; set; }
        public string Motorista { get; set; }
        public string TipoVeiculo { get; set; }
        public string Placa { get; set; }
        public string CategoriaCNH { get; set; }
        public string Empresa { get; set; }
    }
}
