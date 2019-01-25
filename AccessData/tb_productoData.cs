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
    public class tb_productoData
    {
        #region Variables
        private static List<tb_producto> lstproducto;
        private static tb_producto entidad;
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader reader;
        private static ClientResponse clientResponse;
        #endregion

        #region Constructor
        public tb_productoData()
        {
            lstproducto = new List<tb_producto>();
            entidad = null;
            conexion = null;
            comando = null;
            reader = null;
            clientResponse = new ClientResponse();
            clientResponse.Status = "OK";
        }
        #endregion
        #region Metodo
        public ClientResponse ins_producto(object[] parametro)
        {
            int id = 0;
            var _producto = (tb_producto)parametro[0];
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_ins_producto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = _producto.tx_nombre;
                        comando.Parameters.Add("@tx_descripcion", SqlDbType.VarChar, 1000).Value = _producto.tx_descripcion;
                        comando.Parameters.Add("@In_cant_producto", SqlDbType.Int).Value = _producto.In_cant_producto;
                        comando.Parameters.Add("@In_unidad", SqlDbType.Int).Value = _producto.In_unidad;
                        comando.Parameters.Add("@db_precio_costo", SqlDbType.Decimal).Value = _producto.db_precio_costo;
                        comando.Parameters.Add("@db_precio_sin_igv", SqlDbType.Decimal).Value = _producto.db_precio_sin_igv;
                        comando.Parameters.Add("@db_precio_bruto_igv", SqlDbType.Decimal).Value = _producto.db_precio_bruto_igv;
                        comando.Parameters.Add("@In_igv", SqlDbType.Decimal).Value = _producto.In_igv;
                        comando.Parameters.Add("@tx_imagen_producto", SqlDbType.VarChar, 500).Value = _producto.tx_imagen_producto;
                        comando.Parameters.Add("@IdUsuario_crea", SqlDbType.Int).Value = _producto.IdUsuario_crea;
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
                reader.Dispose();
            }
            return clientResponse;
        }
        public ClientResponse update_proucto(object[] parametro)
        {
            try
            {
                var _producto = (tb_producto)parametro[0];
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_upd_tb_usuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = _producto.tx_nombre == null ? "" : _producto.tx_nombre;
                        comando.Parameters.Add("@tx_descripcion", SqlDbType.VarChar, 50).Value = _producto.tx_descripcion == null ? "" : _producto.tx_descripcion;
                        comando.Parameters.Add("@In_cant_producto", SqlDbType.VarChar, 50).Value = _producto.In_cant_producto;
                        comando.Parameters.Add("@In_unidad", SqlDbType.VarChar, 50).Value = _producto.In_unidad;
                        comando.Parameters.Add("@db_precio_costo", SqlDbType.VarChar, 20).Value = _producto.db_precio_costo;
                        comando.Parameters.Add("@db_precio_sin_igv", SqlDbType.VarChar, 200).Value = _producto.db_precio_sin_igv;
                        comando.Parameters.Add("@db_precio_bruto_igv", SqlDbType.Decimal).Value = _producto.db_precio_bruto_igv;
                        comando.Parameters.Add("@In_igv", SqlDbType.VarChar, 20).Value = _producto.In_igv ;
                        comando.Parameters.Add("@tx_imagen_producto", SqlDbType.VarChar, 500).Value = _producto.tx_imagen_producto == null ? "" : _producto.tx_imagen_producto;
                        comando.Parameters.Add("@IdUsuario_mod", SqlDbType.Int).Value = _producto.IdUsuario_mod;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _producto.Id;
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
                reader.Dispose();
            }
            return clientResponse;
        }
        public ClientResponse del_producto(object[] parametro)
        {
            try
            {
                var _producto = (tb_producto)parametro[0];
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_del_producto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _producto.Id;
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
                reader.Dispose();
            }
            return clientResponse;
        }
        public ClientResponse sel_productoxId(object[] parametro)
        {
            var _producto = (tb_producto)parametro[0];
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_sel_producto_x_id", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = _producto.Id;
                        conexion.Open();
                        using (reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                entidad = new tb_producto();
                                entidad.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"].ToString());
                                entidad.Codigo = (reader["Codigo"] == DBNull.Value) ? String.Empty : (reader["Codigo"]).ToString();
                                entidad.tx_nombre = (reader["tx_nombre"] == DBNull.Value) ? String.Empty : (reader["tx_nombre"]).ToString();
                                entidad.tx_descripcion = (reader["tx_descripcion"] == DBNull.Value) ? String.Empty : (reader["tx_descripcion"]).ToString();
                                entidad.In_cant_producto = (reader["In_cant_producto"] == DBNull.Value) ? 0 : int.Parse((reader["In_cant_producto"]).ToString());
                                entidad.db_precio_costo = (reader["db_precio_costo"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_costo"]).ToString());
                                entidad.db_precio_sin_igv = (reader["db_precio_sin_igv"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_sin_igv"]).ToString());
                                entidad.db_precio_bruto_igv = (reader["db_precio_bruto_igv"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_bruto_igv"]).ToString());
                                entidad.In_igv = (reader["In_igv"] == DBNull.Value) ? 0 : double.Parse((reader["In_igv"]).ToString());
                                entidad.tx_imagen_producto = (reader["tx_imagen_producto"] == DBNull.Value) ? String.Empty : (reader["tx_imagen_producto"]).ToString();
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
        public ClientResponse sel_producto(object[] parametro)
        {
            var _producto = (tb_producto)parametro[0];
            var _paginacion = (Pagination)parametro[1];
            int recordCount = 0;
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_sel_producto", conexion))
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
                                entidad = new tb_producto();

                                entidad.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"].ToString());
                                entidad.Codigo = (reader["Codigo"] == DBNull.Value) ? String.Empty : (reader["Codigo"]).ToString();
                                entidad.tx_nombre = (reader["tx_nombre"] == DBNull.Value) ? String.Empty : (reader["tx_nombre"]).ToString();
                                entidad.tx_descripcion = (reader["tx_descripcion"] == DBNull.Value) ? String.Empty : (reader["tx_descripcion"]).ToString();
                                entidad.In_cant_producto = (reader["In_cant_producto"] == DBNull.Value) ? 0 : int.Parse((reader["In_cant_producto"]).ToString());
                                entidad.db_precio_costo = (reader["db_precio_costo"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_costo"]).ToString());
                                entidad.db_precio_sin_igv = (reader["db_precio_sin_igv"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_sin_igv"]).ToString());
                                entidad.db_precio_bruto_igv = (reader["db_precio_bruto_igv"] == DBNull.Value) ? 0 : double.Parse((reader["db_precio_bruto_igv"]).ToString());
                                entidad.In_igv = (reader["In_igv"] == DBNull.Value) ? 0 : double.Parse((reader["In_igv"]).ToString());
                                entidad.tx_imagen_producto = (reader["tx_imagen_producto"] == DBNull.Value) ? String.Empty : (reader["tx_imagen_producto"]).ToString();
                                entidad.IdEstado_reg = (reader["IdEstado_reg"] == DBNull.Value) ? 0 : int.Parse((reader["IdEstado_reg"]).ToString());                              
                                lstproducto.Add(entidad);
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
                //TotalPages = (int)Math.Ceiling((double)recordCount / objeto.ItemsPerPage)
            };
            clientResponse.DataJson = JsonConvert.SerializeObject(lstproducto).ToString();
            clientResponse.paginacion = JsonConvert.SerializeObject(responsepaginacion).ToString();
            return clientResponse;
        }
        #endregion
    }
}
