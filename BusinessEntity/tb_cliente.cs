using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tb_cliente : EntidadBase
    {        
        public string Codigo { get; set; } = "";
        public string tx_nombre { get; set; } = "";
        public string tx_apellido_paterno { get; set; } = "";
        public string tx_apellido_materno { get; set; } = "";
        public string tx_dni { get; set; } = "";
        public string tx_ruc { get; set; } = "";
        public string tx_email { get; set; } = "";
        public string tx_direccion { get; set; } = "";
        public string tx_telefono { get; set; } = "";
        public string tx_celular { get; set; } = "";
       
    }
}
