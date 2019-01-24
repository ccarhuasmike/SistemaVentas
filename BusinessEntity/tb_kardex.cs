using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tb_kardex : EntidadBase
    {        
        public int IdTipoMovimiento { get; set; } = 0;
        public int IdProducto { get; set; } = 0;
        public int In_cant_entrada { get; set; } = 0;
        public int In_cant_salida { get; set; } = 0;
        public int In_unidad { get; set; } = 0;
        public double db_precio_costo { get; set; } = 0;
        public double db_precio_por_unidad { get; set; } = 0;
        public double db_precio_total { get; set; } = 0; 
    }
}
