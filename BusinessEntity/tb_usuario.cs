using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class tb_usuario : EntidadBase
    {        
        public string tx_nombre { get; set; } = "";
        public string tx_apellido_paterno { get; set; } = "";
        public string tx_apellido_materno { get; set; } = "";
        public string tx_email { get; set; } = "";        
        public string tx_login { get; set; } = "";
        public string tx_password { get; set; } = ""; 
        

    }
}
