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
    public class DoctorDLL:IDataMapper<Doctor,Int32>
    {
        SqlCommand _command;
        public DoctorDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public int insert(Doctor item)
        {
            throw new NotImplementedException();
        }

        public int update(Doctor item)
        {
            throw new NotImplementedException();
        }

        public int delete(Doctor item)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Doctor> GetAll(HospitalClinicExaminationPlace doc)
        {
            List<Doctor> doctorList = new List<Doctor>();
            _command.CommandText = "sp_GetAllDoctor";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@examinationID", doc.ExaminationPlaceID.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor();
                        doctor.DoctorID = (int)reader[0];
                        doctor.FirstName = reader[1].ToString();
                        doctor.LastName = reader[2].ToString();
                        doctorList.Add(doctor);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw new Exception("İşlem başarısız");
            }
            finally
            {
                _command.Connection.Close();
            }
            return doctorList;
        }

        public List<Doctor> GetAll(ExaminationPlace examinationPlace)
        {
            List<Doctor> doctorList = new List<Doctor>();
            if (examinationPlace == null)
                return doctorList;
            _command.CommandText = "sp_examinationPlaceGetAllDoctor";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@examinationPlaceID", examinationPlace.ID);
            try{
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor();
                        doctor.DoctorID = (int)reader[0];
                        doctor.FirstName = reader[1].ToString();
                        doctor.LastName = reader[2].ToString();
                        doctorList.Add(doctor);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw new Exception("İşlem başarısız");
            }
            finally
            {
                _command.Connection.Close();
            }
            return doctorList;
        }

        public List<Doctor> GetAll(Hospital hospital, Clinic clinic)
        {
            List<Doctor> doctorList = new List<Doctor>();
            _command.CommandText = "sp_DoctorList";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@hospitalID",hospital.ID);
            _command.Parameters.AddWithValue("@clinicID", clinic.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor();
                        doctor.DoctorID = (int)reader[0];
                        doctor.FirstName = reader[1].ToString();
                        doctor.LastName = reader[2].ToString();
                        doctor.HospitalClinicExaminationPlaceID.ClinicID.Name = reader[3].ToString();
                        doctor.HospitalClinicExaminationPlaceID.HospitalID.Name = reader[4].ToString();
                        doctor.HospitalClinicExaminationPlaceID.ExaminationPlaceID.Name = reader[5].ToString();
                        doctor.HospitalClinicExaminationPlaceID.ClinicID.ExaminationPeriod = int.Parse(reader[8].ToString());
                        doctor.HospitalClinicExaminationPlaceID.StartTime = DateTime.Parse(reader[9].ToString());
                        doctor.HospitalClinicExaminationPlaceID.EndTime = DateTime.Parse(reader[10].ToString());
                        doctorList.Add(doctor);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw new Exception("İşlem başarısız");
            }
            finally
            {
                _command.Connection.Close();
            }
            return doctorList;
        }

        public Doctor Get(int id)
        {
            Doctor doctor = new Doctor();
            _command.CommandText = "sp_GetDoctor";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", id);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        doctor.DoctorID = (int)reader[0];
                        doctor.FirstName = reader[1].ToString();
                        doctor.LastName = reader[2].ToString();
                    }
                }
            }
            catch (Exception)
            {
                
                throw new Exception("İşlem başarısız oldu");
            }
            finally
            {
                _command.Connection.Close();
            }
            return doctor;
        }
    }
}
