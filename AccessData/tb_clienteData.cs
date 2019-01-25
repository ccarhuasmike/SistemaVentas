using BusinessEntity;
using Communities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData
{
    public class tb_clienteData
    {
        #region Variables
        private static List<tb_cliente> lstcliente;
        private static tb_cliente entidad;
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader reader;
        private static ClientResponse clientResponse;
        #endregion

        #region Constructor
        public tb_clienteData()
        {
            lstcliente = new List<tb_cliente>();
            entidad = null;
            conexion = null;
            comando = null;
            reader = null;
            clientResponse = new ClientResponse();
            clientResponse.Status = "OK";
        }
        #endregion

        #region Metodo
        public ClientResponse ins_cliente(object[] parametro)
        {
            int id = 0;
            var _cliente = (tb_cliente)parametro[0];
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_ins_cliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = _cliente.tx_nombre;
                        comando.Parameters.Add("@tx_apellido_paterno", SqlDbType.VarChar, 50).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_apellido_materno", SqlDbType.VarChar, 50).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_ruc", SqlDbType.VarChar, 11).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@txt_email", SqlDbType.VarChar, 50).Value = _cliente.tx_email;
                        comando.Parameters.Add("@tx_direccion", SqlDbType.VarChar, 100).Value = _cliente.tx_direccion;
                        comando.Parameters.Add("@tx_telefono", SqlDbType.VarChar, 11).Value = _cliente.tx_telefono;
                        comando.Parameters.Add("@tx_celular", SqlDbType.VarChar, 11).Value = _cliente.tx_celular;
                        comando.Parameters.Add("@IdUsuario_crea", SqlDbType.Int).Value = _cliente.IdUsuario_crea;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        if (comando.Parameters["@Id"] != null)
                        {
                            id = Convert.ToInt32(comando.Parameters["@Id"].Value);
                            object initDatos = new
                            {
                                Id = id
                            };
                            clientResponse.Status = "OK";
                            clientResponse.Data = initDatos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clientResponse.Mensaje = ex.Message;
                clientResponse.Status = "ERROR";
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                comando.Dispose();
            }
            return clientResponse;
        }
        public ClientResponse upd_cliente(object[] parametro)
        {
            try
            {
                var _cliente = (tb_cliente)parametro[0];
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_upd_cliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = _cliente.tx_nombre;
                        comando.Parameters.Add("@tx_apellido_paterno", SqlDbType.VarChar, 50).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_apellido_materno", SqlDbType.VarChar, 50).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_ruc", SqlDbType.VarChar, 11).Value = _cliente.tx_apellido_paterno;
                        comando.Parameters.Add("@txt_email", SqlDbType.VarChar, 50).Value = _cliente.tx_email;
                        comando.Parameters.Add("@tx_direccion", SqlDbType.VarChar, 100).Value = _cliente.tx_direccion;
                        comando.Parameters.Add("@tx_telefono", SqlDbType.VarChar, 11).Value = _cliente.tx_telefono;
                        comando.Parameters.Add("@tx_celular", SqlDbType.VarChar, 11).Value = _cliente.tx_celular;
                        comando.Parameters.Add("@IdUsuario_mod", SqlDbType.Int).Value = _cliente.IdUsuario_mod;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _cliente.Id;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clientResponse.Mensaje = ex.Message;
                clientResponse.Status = "ERROR";
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                comando.Dispose();
            }
            return clientResponse;
        }
        public ClientResponse del_cliente(object[] parametro)
        {
            try
            {
                var _cliente = (tb_cliente)parametro[0];
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_del_cliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _cliente.Id;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        clientResponse.Status = "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                clientResponse.Mensaje = ex.Message;
                clientResponse.Status = "ERROR";
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                comando.Dispose();                
            }
            return clientResponse;
        }
        public ClientResponse sel_clientexId(object[] parametro)
        {
            var _cliente = (tb_cliente)parametro[0];
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_sel_cliente_x_id", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _cliente.Id;
                        conexion.Open();
                        using (reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                entidad = new tb_cliente();
                                entidad.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"].ToString());
                                entidad.Codigo = (reader["Codigo"] == DBNull.Value) ? String.Empty : (reader["Codigo"]).ToString();
                                entidad.tx_nombre = (reader["tx_nombre"] == DBNull.Value) ? String.Empty : (reader["tx_nombre"]).ToString();
                                entidad.tx_apellido_paterno = (reader["tx_apellido_paterno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_paterno"]).ToString();
                                entidad.tx_apellido_materno = (reader["tx_apellido_materno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_materno"]).ToString();
                                entidad.tx_ruc = (reader["tx_ruc"] == DBNull.Value) ? String.Empty : (reader["tx_ruc"]).ToString();
                                entidad.tx_email = (reader["tx_email"] == DBNull.Value) ? String.Empty : (reader["tx_email"]).ToString();
                                entidad.tx_direccion = (reader["tx_direccion"] == DBNull.Value) ? String.Empty : (reader["tx_direccion"]).ToString();
                                entidad.tx_telefono = (reader["tx_telefono"] == DBNull.Value) ? String.Empty : (reader["tx_telefono"]).ToString();
                                entidad.tx_celular = (reader["tx_celular"] == DBNull.Value) ? String.Empty : (reader["tx_celular"]).ToString();
                                entidad.IdEstado_reg = (reader["IdEstado_reg"] == DBNull.Value) ? 0 : int.Parse((reader["IdEstado_reg"]).ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clientResponse.Mensaje = ex.Message;
                clientResponse.Status = "ERROR";
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                comando.Dispose();
                reader.Dispose();
            }
            clientResponse.DataJson = JsonConvert.SerializeObject(entidad).ToString();
            return clientResponse;
        }
        public ClientResponse sel_cliente(object[] parametro)
        {
            var _cliente = (tb_cliente)parametro[0];
            var _paginacion = (Pagination)parametro[1];
            int recordCount = 0;
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_sel_cliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        /*comando.Parameters.Add("@serie", SqlDbType.VarChar, 20).Value = objeto.reporte.Serie;
                        comando.Parameters.Add("@numerodoc", SqlDbType.VarChar, 20).Value = objeto.reporte.Numerodoc;
                        comando.Parameters.Add("@fechaproceso_ini", SqlDbType.VarChar, 8).Value = objeto.reporte.Fecha_Ini;
                        comando.Parameters.Add("@fechaproceso_fin", SqlDbType.VarChar, 8).Value = objeto.reporte.Fecha_Fin;*/
                        comando.Parameters.Add("@vi_pagina", SqlDbType.Int).Value = _paginacion.CurrentPage;
                        comando.Parameters.Add("@vi_registrosporpagina", SqlDbType.Int).Value = _paginacion.ItemsPerPage;
                        comando.Parameters.Add("@vi_RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                        conexion.Open();
                        using (reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entidad = new tb_cliente();
                                entidad.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"].ToString());
                                entidad.Codigo = (reader["Codigo"] == DBNull.Value) ? String.Empty : (reader["Codigo"]).ToString();
                                entidad.tx_nombre = (reader["tx_nombre"] == DBNull.Value) ? String.Empty : (reader["tx_nombre"]).ToString();
                                entidad.tx_apellido_paterno = (reader["tx_apellido_paterno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_paterno"]).ToString();
                                entidad.tx_apellido_materno = (reader["tx_apellido_materno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_materno"]).ToString();
                                entidad.tx_ruc = (reader["tx_ruc"] == DBNull.Value) ? String.Empty : (reader["tx_ruc"]).ToString();
                                entidad.tx_email = (reader["tx_email"] == DBNull.Value) ? String.Empty : (reader["tx_email"]).ToString();
                                entidad.tx_direccion = (reader["tx_direccion"] == DBNull.Value) ? String.Empty : (reader["tx_direccion"]).ToString();
                                entidad.tx_telefono = (reader["tx_telefono"] == DBNull.Value) ? String.Empty : (reader["tx_telefono"]).ToString();
                                entidad.tx_celular = (reader["tx_celular"] == DBNull.Value) ? String.Empty : (reader["tx_celular"]).ToString();
                                entidad.IdEstado_reg = (reader["IdEstado_reg"] == DBNull.Value) ? 0 : int.Parse((reader["IdEstado_reg"]).ToString());
                                lstcliente.Add(entidad);
                            }
                        }
                        recordCount = Convert.ToInt32(comando.Parameters["@vi_RecordCount"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                clientResponse.Mensaje = ex.Message;
                clientResponse.Status = "ERROR";
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                comando.Dispose();
                reader.Dispose();
            }
            Pagination responsepaginacion = new Pagination()
            {
                TotalItems = recordCount,
                TotalPages = (int)Math.Ceiling((double)recordCount / _paginacion.ItemsPerPage)
            };
            clientResponse.DataJson = JsonConvert.SerializeObject(lstcliente).ToString();
            clientResponse.paginacion = JsonConvert.SerializeObject(responsepaginacion).ToString();
            return clientResponse;
        }
        #endregion
    }
}
