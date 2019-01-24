using AccessData;
using Communities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class tb_proveedorLogic
    {
        private tb_proveedorData _tb_proveedorData;

        public tb_proveedorLogic()
        {
            _tb_proveedorData = new tb_proveedorData();
        }
        public ClientResponse ListarProveedor(object[] parameter)
        {
            return _tb_proveedorData.ListarProveedor(parameter);
        }
    }
}
