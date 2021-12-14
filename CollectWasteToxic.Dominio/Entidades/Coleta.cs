using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Coleta 
    {
        [Key]
        public int IdColeta { get; set; }
        public string Localizacao { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
        public string Imagem { get; set; }
    }
}
