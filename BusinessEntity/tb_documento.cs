using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tb_documento:EntidadBase
    {        
        public string Codigo { get; set; } = "";
        public int IdTipoDocumento { get; set; } = 0;
        public int serie { get; set; } = 0;
        public int correlativos { get; set; } = 0;
        public int IdCliente { get; set; } = 0;
        public DateTime? dt_fec_emi_factura { get; set; }
        public DateTime? dt_fec_venc_factura { get; set; }
        public string tx_nota { get; set; }
        public int IdTipoMoneda { get; set; } = 0;
        public double db_precio_neto { get; set; } = 0;
        public double db_precio_bruto { get; set; } = 0;
        public double db_descuento { get; set; } = 0;
        public double db_total_igv { get; set; } = 0;
        public double db_monto_total { get; set; } = 0;
        public double db_tipo_cambio { get; set; } = 0;
        public int IdCond_pago { get; set; } = 0;        
        public int IdEstado_documento  { get; set; } = 0;  
    }
}
