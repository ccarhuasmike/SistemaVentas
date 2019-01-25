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
    [RoutePrefix("api/producto")]
    public class ApiProductoController : ApiController
    {
        [Route("sel_producto"), HttpPost]
        public ClientResponse sel_producto(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_producto producto = objData["producto"].ToObject<tb_producto>();
                Pagination paginacion = objData["paginacion"].ToObject<Pagination>();
                response = new tb_productoLogic().sel_producto(new object[] { producto, paginacion });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("sel_productoxId"), HttpPost]
        public ClientResponse sel_productoxId(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_producto producto = objData["producto"].ToObject<tb_producto>();
                response = new tb_productoLogic().sel_productoxId(new object[] { producto });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("del_producto"), HttpPost]
        public ClientResponse del_producto(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_producto producto = objData["producto"].ToObject<tb_producto>();
                response = new tb_productoLogic().del_producto(new object[] { producto });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("update_proucto"), HttpPost]
        public ClientResponse update_proucto(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_producto producto = objData["producto"].ToObject<tb_producto>();
                response = new tb_productoLogic().update_proucto(new object[] { producto });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("ins_producto"), HttpPost]
        public ClientResponse ins_producto(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_producto producto = objData["producto"].ToObject<tb_producto>();
                response = new tb_productoLogic().ins_producto(new object[] { producto });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
    }
}
