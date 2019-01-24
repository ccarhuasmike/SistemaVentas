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
        public ClientResponse ListarProducto(object[] parameter)
        {
            return _tb_productoData.ListarProducto(parameter);
        }
    }
}
