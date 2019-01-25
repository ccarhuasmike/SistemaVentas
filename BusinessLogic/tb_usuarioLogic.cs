using AccessData;
using BusinessEntity;
using Communities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class tb_usuarioLogic
    {
        private tb_usuarioData _tb_usuarioData;

        public tb_usuarioLogic()
        {
            _tb_usuarioData = new tb_usuarioData();
        }
        public ClientResponse sel_usuario(object[] parameter)
        {          
            return _tb_usuarioData.sel_usuario(parameter);
        }
        public ClientResponse ins_usuario(object[] parameter)
        {
            return _tb_usuarioData.ins_usuario(parameter);
        }
        public ClientResponse upd_usuario(object[] parameter)
        {
            return _tb_usuarioData.upd_usuario(parameter);
        }
        public ClientResponse del_usuario(object[] parameter)
        {
            return _tb_usuarioData.del_usuario(parameter);
        }
        public ClientResponse sel_usuarioxId(object[] parameter)
        {
            return _tb_usuarioData.sel_usuarioxId(parameter);
        }      
    }
}
