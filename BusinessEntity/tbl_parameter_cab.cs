using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tbl_parameter_cab
    {
        public int Id { get; set; } = 0;
        public string skey_cab { get; set; } = "";        
        public string tx_descripcion { get; set; } = "";
        public int IdEstado_reg { get; set; } = 0;
        public DateTime? dt_fe_crea { get; set; }
        public string tx_comentario { get; set; } = "";
    }
}
