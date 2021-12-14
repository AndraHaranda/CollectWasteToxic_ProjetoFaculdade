using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Rota
    {
        [Key]
        public int IdRota { get; set; }
        public string NomeRota { get; set; }
        public DateTime Horario { get; set; }
        public string MaterialDescarte { get; set; }
        public string Responsavel { get; set; }

    }
}

