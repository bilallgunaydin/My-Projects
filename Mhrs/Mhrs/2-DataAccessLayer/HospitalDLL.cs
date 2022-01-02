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
    public class HospitalDLL:IDataMapper<Hospital,Int32>
    {
        SqlCommand _command;
        public HospitalDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }


        public int insert(Hospital item)
        {
            throw new NotImplementedException();
        }

        public int update(Hospital item)
        {
            throw new NotImplementedException();
        }

        public int delete(Hospital item)
        {
            throw new NotImplementedException();
        }

        public List<Hospital> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Hospital> GetAll(HospitalClinicExaminationPlace clinic)
        {
            List<Hospital> hospitalList = new List<Hospital>();
            _command.CommandText = "Sp_SelectCountyGetALLHospital";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@CountyId",clinic.HospitalID.County.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Hospital hospital = new Hospital();
                        hospital.ID = (int)reader[0];
                        hospital.Name = reader[1].ToString();
                        hospitalList.Add(hospital);
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
            return hospitalList;
        }

        public List<Hospital> GetAll(Hospital item,Clinic clinic)
        {
            List<Hospital> hospitalList = new List<Hospital>();
            _command.CommandText = "Sp_GetALLHospital";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@cityID", item.City.ID);
            _command.Parameters.AddWithValue("@countyID", item.County.ID);
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
                        Hospital hospital = new Hospital();
                        hospital.ID = (int)reader[0];
                        hospital.Name = reader[1].ToString();
                        hospitalList.Add(hospital);
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
            return hospitalList;
        }

        public Hospital Get(int id)
        {
            Hospital hospital = new Hospital();
            _command.CommandText = "Sp_GetHospital";
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
                        hospital.ID = (int)reader[0];
                        hospital.Name= reader[1].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("İşlem Başarısız!");
            }
            finally
            {
                _command.Connection.Close();
            }
            return hospital;
        }
    }
}
