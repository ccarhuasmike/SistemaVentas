using BusinessEntity;
using BusinessLogic;
using Communities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace ApiRestVentas.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ApiClienteController : ApiController
    {
        [Route("sel_cliente"), HttpPost]
        public ClientResponse sel_cliente(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_cliente cliente = objData["cliente"].ToObject<tb_cliente>();
                Pagination pagination = objData["paginacion"].ToObject<Pagination>();
                response = new tb_clienteLogic().sel_cliente(new object[] { cliente, pagination });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }

        [Route("sel_clientexId"), HttpPost]
        public ClientResponse sel_clientexId(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_cliente cliente = objData["cliente"].ToObject<tb_cliente>();
                response = new tb_clienteLogic().sel_clientexId(new object[] { cliente });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("del_cliente"), HttpPost]
        public ClientResponse del_cliente(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_cliente cliente = objData["cliente"].ToObject<tb_cliente>();
                response = new tb_clienteLogic().del_cliente(new object[] { cliente });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("upd_cliente"), HttpPost]
        public ClientResponse upd_cliente(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_cliente cliente = objData["cliente"].ToObject<tb_cliente>();
                response = new tb_clienteLogic().upd_cliente(new object[] { cliente });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("ins_cliente"), HttpPost]
        public ClientResponse ins_cliente(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_cliente cliente = objData["cliente"].ToObject<tb_cliente>();
                response = new tb_clienteLogic().ins_cliente(new object[] { cliente });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
    }
}
