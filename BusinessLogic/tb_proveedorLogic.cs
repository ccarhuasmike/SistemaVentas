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
        public ClientResponse sel_proveedor(object[] parameter)
        {
            return _tb_proveedorData.sel_proveedor(parameter);
        }
        public ClientResponse ins_proveedor(object[] parameter)
        {
            return _tb_proveedorData.ins_proveedor(parameter);
        }
        public ClientResponse upd_proveedor(object[] parameter)
        {
            return _tb_proveedorData.upd_proveedor(parameter);
        }
        public ClientResponse del_proveedor(object[] parameter)
        {
            return _tb_proveedorData.del_proveedor(parameter);
        }
        public ClientResponse sel_proveedorxId(object[] parameter)
        {
            return _tb_proveedorData.sel_proveedorxId(parameter);
        }
    }
}
