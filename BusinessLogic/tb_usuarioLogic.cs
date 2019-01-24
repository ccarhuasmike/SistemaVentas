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
        public ClientResponse ListarUsuario(object[] parameter)
        {          
            return _tb_usuarioData.ListarUsuario(parameter);
        }
    }
}
