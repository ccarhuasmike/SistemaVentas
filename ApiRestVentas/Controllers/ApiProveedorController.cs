using BusinessEntity;
using BusinessLogic;
using Communities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestVentas.Controllers
{
    [RoutePrefix("api/proveedor")]
    public class ApiProveedorController : ApiController
    {
        [Route("listarProveedor"), HttpPost]
        public ClientResponse listarUsuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {
                response = new tb_proveedorLogic().ListarProveedor(new object[] { parameter.usuario, parameter.paginacion });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
    }
}
