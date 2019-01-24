using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class EntidadBase
    {
        public int Id { get; set; } = 0;  
        public int IdUsuario_crea { get; set; } = 0;
        public DateTime? dt_fe_crea { get; set; }
        public int IdUsuario_mod { get; set; } = 0;
        public DateTime? dt_fe_mod { get; set; }
        public int IdEstado_reg { get; set; } = 0;
    }
}
