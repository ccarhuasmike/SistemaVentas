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
    [RoutePrefix("api/proveedor")]
    public class ApiProveedorController : ApiController
    {
        [Route("sel_proveedor"), HttpPost]
        public ClientResponse sel_proveedor(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_proveedor proveedor = objData["proveedor"].ToObject<tb_proveedor>();
                Pagination pagination = objData["paginacion"].ToObject<Pagination>();
                response = new tb_proveedorLogic().sel_proveedor(new object[] { proveedor, pagination });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }

        [Route("sel_proveedorxId"), HttpPost]
        public ClientResponse sel_proveedorxId(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_proveedor proveedor = objData["proveedor"].ToObject<tb_proveedor>();
                response = new tb_proveedorLogic().sel_proveedorxId(new object[] { proveedor });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("del_proveedor"), HttpPost]
        public ClientResponse del_proveedor(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_proveedor proveedor = objData["proveedor"].ToObject<tb_proveedor>();
                response = new tb_proveedorLogic().del_proveedor(new object[] { proveedor });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("upd_proveedor"), HttpPost]
        public ClientResponse upd_proveedor(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_proveedor proveedor = objData["proveedor"].ToObject<tb_proveedor>();
                response = new tb_proveedorLogic().upd_proveedor(new object[] { proveedor });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
        [Route("ins_proveedor"), HttpPost]
        public ClientResponse ins_proveedor(JObject objData)
        {
            ClientResponse response;
            try
            {
                tb_proveedor proveedor = objData["proveedor"].ToObject<tb_proveedor>();
                response = new tb_proveedorLogic().ins_proveedor(new object[] { proveedor });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
    }
}
