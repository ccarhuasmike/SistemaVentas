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
    [RoutePrefix("api/usuario")]
    public class ApiUsuarioController : ApiController
    {
        [Route("listarUsuario"), HttpPost]
        public ClientResponse listarUsuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {   
                response = new tb_usuarioLogic().ListarUsuario(new object[] { parameter.usuario, parameter.paginacion });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        //public ClientResponse ConsultarPersona(params string[] data)
        //{
        //    ClientResponse response;
        //    try
        //    {
        //        VMPersona oPersona = new VMPersona();
        //        oPersona.dni = data[2];
        //        oPersona.nombre = data[3];
        //        //int estado = 0;
        //        //int.TryParse(data[4], out estado);
        //        oPersona.estado = 1;
        //        int CurrentPage = 0, ItemsPerPage = 0;
        //        int.TryParse(data[0], out CurrentPage);
        //        int.TryParse(data[1], out ItemsPerPage);
        //        BEPaginacion paginacion = new BEPaginacion() { CurrentPage = CurrentPage, ItemsPerPage = ItemsPerPage };
        //        response = new LNPersona().ConsultarPersona(oPersona, paginacion);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return response;
        //}

    }
}
