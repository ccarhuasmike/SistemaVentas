using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class tb_documento_detalle:EntidadBase
    {
        public int IdDocumento { get; set; } = 0;
        public int IdProducto { get; set; } = 0;
        public int In_cantidad { get; set; } = 0;
        public double db_precio_unitario { get; set; } = 0;
        public double db_precio_x_cantidad { get; set; } = 0;
        public double db_total { get; set; } = 0;
        public string tx_nombre { get; set; } = "";   
    }
}
