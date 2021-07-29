using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Automovil
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AutomovilGetAll";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.Connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(query, context);
                        DataTable automovil = new DataTable();
                        da.Fill(automovil);

                        if(automovil.Rows.Count > 0 )
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in automovil.Rows)
                            {
                                ML.Automovil automovilItem = new ML.Automovil();
                                automovilItem.IdAutomovil = int.Parse(row[0].ToString());
                                automovilItem.Marca = row[1].ToString();
                                automovilItem.Modelo = row[2].ToString();
                                automovilItem.Color = row[3].ToString();
                                automovilItem.Imagen = (row[4].ToString()) == "" ? null : (byte[])row[4];

                                result.Objects.Add(automovilItem);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo agregar al Alumno.";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AutomovilGetById";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAutomovil", SqlDbType.Int);
                        collection[0].Value = IdAutomovil;

                        cmd.Parameters.AddRange(collection);

                        DataTable automoviles = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(automoviles);
                        if (automoviles.Rows.Count > 0)
                        {
                            DataRow row = automoviles.Rows[0];

                            ML.Automovil automovilItem = new ML.Automovil();
                            automovilItem.IdAutomovil = int.Parse(row[0].ToString());
                            automovilItem.Marca = row[1].ToString();
                            automovilItem.Modelo = row[2].ToString();
                            automovilItem.Color = row[3].ToString();
                            automovilItem.Imagen = (row[4].ToString()) == "" ? null : (byte[])row[4];

                            result.Object = automovilItem;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = true;
                            result.ErrorMessage = "No se encontraro registos del automovil";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AutomovilAdd";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Marca", SqlDbType.VarChar);
                        collection[0].Value = automovil.Marca;

                        collection[1] = new SqlParameter("Modelo", SqlDbType.VarChar);
                        collection[1].Value = automovil.Modelo;

                        collection[2] = new SqlParameter("Color", SqlDbType.VarChar);
                        collection[2].Value = automovil.Color;

                        collection[3] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                        collection[3].Value = automovil.Imagen;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if(RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo añadir correctamente el registro.";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AutomovilUpdate";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdAutomovil", SqlDbType.Int);
                        collection[0].Value = automovil.IdAutomovil;

                        collection[1] = new SqlParameter("Marca", SqlDbType.VarChar);
                        collection[1].Value = automovil.Marca;

                        collection[2] = new SqlParameter("Modelo", SqlDbType.VarChar);
                        collection[2].Value = automovil.Modelo;

                        collection[3] = new SqlParameter("Color", SqlDbType.VarChar);
                        collection[3].Value = automovil.Color;

                        collection[4] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                        collection[4].Value = automovil.Imagen;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if( RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo actualizar el registro correctamente.";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AutomovilDelete";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAutomovil", SqlDbType.Int);
                        collection[0].Value = IdAutomovil;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo eliminar el registro correctamente";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
