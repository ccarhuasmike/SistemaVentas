using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tb_producto: EntidadBase
    {
        
        public string Codigo { get; set; } = "";
        public string tx_nombre { get; set; } = "";
        public string tx_descripcion { get; set; } = "";
        public int In_cant_producto { get; set; } = 0;
        public int In_unidad { get; set; } = 0;
        public double db_precio_costo { get; set; } = 0;
        public double db_precio_sin_igv { get; set; } = 0;
        public double db_precio_bruto_igv { get; set; } = 0;
        public double In_igv { get; set; } = 0;
        public string tx_imagen_producto { get; set; } = "";        
    }
}
