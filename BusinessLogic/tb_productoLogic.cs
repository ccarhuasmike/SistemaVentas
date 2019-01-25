using AccessData;
using Communities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class tb_productoLogic
    {
        private tb_productoData _tb_productoData;

        public tb_productoLogic()
        {
            _tb_productoData = new tb_productoData();
        }
        public ClientResponse sel_producto(object[] parameter)
        {
            return _tb_productoData.sel_producto(parameter);
        }
        public ClientResponse ins_producto(object[] parameter)
        {
            return _tb_productoData.ins_producto(parameter);
        }
        public ClientResponse update_proucto(object[] parameter)
        {
            return _tb_productoData.update_proucto(parameter);
        }
        public ClientResponse del_producto(object[] parameter)
        {
            return _tb_productoData.del_producto(parameter);
        }
        public ClientResponse sel_productoxId(object[] parameter)
        {
            return _tb_productoData.sel_productoxId(parameter);
        }
    }
}
