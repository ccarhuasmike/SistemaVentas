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
        [Route("sel_usuario"), HttpPost]
        public ClientResponse sel_usuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {   
                response = new tb_usuarioLogic().sel_usuario(new object[] { parameter.usuario, parameter.paginacion });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("sel_usuarioxId"), HttpPost]
        public ClientResponse sel_usuarioxId(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {
                response = new tb_usuarioLogic().sel_usuarioxId(new object[] { parameter.usuario });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("del_usuario"), HttpPost]
        public ClientResponse del_usuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {
                response = new tb_usuarioLogic().del_usuario(new object[] { parameter.usuario });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("upd_usuario"), HttpPost]
        public ClientResponse upd_usuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {
                response = new tb_usuarioLogic().upd_usuario(new object[] { parameter.usuario });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("ins_usuario"), HttpPost]
        public ClientResponse ins_usuario(CreateParameters parameter)
        {
            ClientResponse response;
            try
            {
                response = new tb_usuarioLogic().ins_usuario(new object[] { parameter.usuario });
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
