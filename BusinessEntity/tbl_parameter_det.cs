using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tbl_parameter_det
    {
        public int Id { get; set; } = 0;
        public string skey_det { get; set; } = "";
        public int In_valor { get; set; } = 0;
        public string tx_valor { get; set; } = "";
        public string tx_descripcion { get; set; } = "";
        public string tx_comentario { get; set; } = "";
        public int In_orden { get; set; } = 0;
        public int InIdEstado_reg_orden { get; set; } = 0;
        public DateTime? dt_fe_crea { get; set; }
        public string skey_cab { get; set; } = "";
    }
}
