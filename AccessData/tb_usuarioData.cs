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
    public class tb_usuarioData
    {
        #region Variables
        private static List<tb_usuario> lstusuario;
        private static tb_usuario entidad;
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader reader;
        private static ClientResponse clientResponse;
        #endregion

        #region Constructor
        public tb_usuarioData()
        {
            lstusuario = new List<tb_usuario>();
            entidad = null;
            conexion = null;
            comando = null;
            reader = null;
            clientResponse = new ClientResponse();
            clientResponse.Status = "OK";
        }
        #endregion

        #region Metodo
        public ClientResponse insertar_usuario(tb_usuario objeto)
        {
            int id = 0;
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_ins_tb_usuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = objeto.tx_nombre;
                        comando.Parameters.Add("@tx_apellido_paterno", SqlDbType.VarChar, 50).Value = objeto.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_apellido_materno", SqlDbType.VarChar, 50).Value = objeto.tx_apellido_paterno;
                        comando.Parameters.Add("@txt_email", SqlDbType.VarChar, 50).Value = objeto.tx_email;
                        comando.Parameters.Add("@tx_login", SqlDbType.VarChar, 20).Value = objeto.tx_login;
                        comando.Parameters.Add("@tx_password", SqlDbType.VarChar, 200).Value = objeto.tx_password;
                        comando.Parameters.Add("@IdUsuario_crea", SqlDbType.Int, 50).Value = objeto.IdUsuario_crea;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        if (comando.Parameters["@Id"] != null)
                        {
                            id = Convert.ToInt32(comando.Parameters["@Id"].Value);
                            //IEnumerable<Tbl_usuario> lst = GetUsuario_X_Id(id);
                            //clientResponse.DataJson = JsonConvert.SerializeObject(lst).ToString();
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

        public ClientResponse update_usuario(tb_usuario objeto)
        {
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_upd_tb_usuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tx_nombre", SqlDbType.VarChar, 50).Value = objeto.tx_nombre == null ? "" : objeto.tx_nombre;
                        comando.Parameters.Add("@tx_apellido_paterno", SqlDbType.VarChar, 50).Value = objeto.tx_apellido_paterno == null ? "" : objeto.tx_apellido_paterno;
                        comando.Parameters.Add("@tx_apellido_materno", SqlDbType.VarChar, 50).Value = objeto.tx_apellido_materno == null ? "" : objeto.tx_apellido_materno;
                        comando.Parameters.Add("@txt_email", SqlDbType.VarChar, 50).Value = objeto.tx_email == null ? "" : objeto.tx_email;
                        comando.Parameters.Add("@tx_login", SqlDbType.VarChar, 20).Value = objeto.tx_login == null ? "" : objeto.tx_login;
                        comando.Parameters.Add("@tx_password", SqlDbType.VarChar, 200).Value = objeto.tx_password == null ? "" : objeto.tx_password; ;
                        comando.Parameters.Add("@IdUsuario_mod", SqlDbType.Int).Value = objeto.IdUsuario_mod;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = objeto.Id;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        //IEnumerable<Tbl_anuncio> lst = GetAnucionXId(objeto.id);
                        //clientResponse.DataJson = JsonConvert.SerializeObject(lst).ToString();
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

        public ClientResponse ListarUsuario(object[] parametro)
        {
            var _persona = (tb_usuario)parametro[0];
            var _paginacion = (Pagination)parametro[1];
            int recordCount = 0;
            try
            {
                using (conexion = new SqlConnection(ConnectionBaseSql.ConexionBDSQL().ToString()))
                {
                    using (comando = new SqlCommand("sp_sel_usuario", conexion))
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
                                entidad = new tb_usuario();

                                entidad.Id = (reader["id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["id"].ToString());
                                entidad.tx_nombre = (reader["tx_nombre"] == DBNull.Value) ? String.Empty : (reader["tx_nombre"]).ToString();
                                entidad.tx_apellido_paterno = (reader["tx_apellido_paterno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_paterno"]).ToString();
                                entidad.tx_apellido_materno = (reader["tx_apellido_materno"] == DBNull.Value) ? String.Empty : (reader["tx_apellido_materno"]).ToString();
                                entidad.tx_email = (reader["tx_email"] == DBNull.Value) ? String.Empty : (reader["tx_email"]).ToString();
                                entidad.tx_login = (reader["tx_login"] == DBNull.Value) ? String.Empty : (reader["tx_login"]).ToString();
                                entidad.tx_password = (reader["tx_password"] == DBNull.Value) ? string.Empty : (reader["tx_password"]).ToString();
                                /*entidad.Fechaproceso = (reader["fechaproceso"] == DBNull.Value) ? String.Empty : (reader["fechaproceso"]).ToString();
                                entidad.Fecharegistro = (reader["fecharegistro"] == DBNull.Value) ? String.Empty : (reader["fecharegistro"]).ToString();*/
                                lstusuario.Add(entidad);
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
            clientResponse.DataJson = JsonConvert.SerializeObject(lstusuario).ToString();
            clientResponse.paginacion = JsonConvert.SerializeObject(responsepaginacion).ToString();
            return clientResponse;
        }

        #endregion
    }
}
