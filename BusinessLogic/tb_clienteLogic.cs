using AccessData;
using Communities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class tb_clienteLogic
    {
        private tb_clienteData _tb_clienteData;

        public tb_clienteLogic()
        {
            _tb_clienteData = new tb_clienteData();
        }
        public ClientResponse sel_cliente(object[] parameter)
        {
            return _tb_clienteData.sel_cliente(parameter);
        }
        public ClientResponse ins_cliente(object[] parameter)
        {
            return _tb_clienteData.ins_cliente(parameter);
        }
        public ClientResponse upd_cliente(object[] parameter)
        {
            return _tb_clienteData.upd_cliente(parameter);
        }
        public ClientResponse del_cliente(object[] parameter)
        {
            return _tb_clienteData.del_cliente(parameter);
        }
        public ClientResponse sel_clientexId(object[] parameter)
        {
            return _tb_clienteData.sel_clientexId(parameter);
        }
    }
}
