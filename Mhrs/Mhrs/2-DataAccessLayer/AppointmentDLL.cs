using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;
namespace Entities
{
    public class AppointmentDLL : IDataMapper<Appointment, Int32>
    {
        SqlCommand _command;

        public AppointmentDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public int insert(Appointment item)
        {
            int affectedRows = 0;

            if (item == null)
            {
                return affectedRows;
            }

            _command.CommandText = "sp_SaveAppointment";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@doctorId" ,item.Doctor.DoctorID);
            _command.Parameters.AddWithValue("@patientId", item.Poorly.Personel.PatientID);
            _command.Parameters.AddWithValue("@dateOfAppointment", item.DateOfAppointment);
            _command.Parameters.AddWithValue("@status", item.Status);

            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ekleme başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }

        public int update(Appointment item)
        {
            int affectedRows = 0;

            if (item == null)
            {
                return affectedRows;
            }

            _command.CommandText = "sp_UpdateAppointment";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@doctorId",item.Doctor.DoctorID);
            _command.Parameters.AddWithValue("@patientId", item.Poorly.Personel.PatientID);
            _command.Parameters.AddWithValue("@dateOfAppointment", item.DateOfAppointment);
            _command.Parameters.AddWithValue("@status", item.Status);

            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ekleme başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }

        public int delete(Appointment item)
        {
            int affectedRows = 0;

            if (item == null)
            {
                return affectedRows;
            }

            _command.CommandText = "sp_DeleteAppointment";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@doctorId", item.Doctor.DoctorID);
            _command.Parameters.AddWithValue("@patientId", item.Poorly.Personel.PatientID);
            _command.Parameters.AddWithValue("@dateOfAppointment", item.DateOfAppointment);
            _command.Parameters.AddWithValue("@status", item.Status);

            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Ekleme başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;

        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appoList = new List<Appointment>();
            _command.CommandText = "sp_ListAppointment";
            _command.Parameters.Clear();
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();                  
                        appointment.Doctor.DoctorID = (int)reader[0];
                        appointment.Poorly.Personel.PatientID = (int)reader[1];


                        appoList.Add(appointment);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception("İşlem Başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return appoList;
        }

        public Appointment Get(int id)
        {
            Appointment appo = null;
            _command.CommandText = "sp_GetAppointment";
            _command.Parameters.Clear();

            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {

                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception("İşlem Başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return appo;
        }

        public int search(int doctorid, int poorlyid)
        {
            int affectedRows = 0;

            if (doctorid<0 && poorlyid<0)
            {
                return affectedRows;
            }

            _command.CommandText = "sp_searchExamination";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@doctorıd", doctorid);
            _command.Parameters.AddWithValue("@poorlyıd", poorlyid);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Sonuç başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }
    }
}
