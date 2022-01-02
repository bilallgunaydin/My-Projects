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
    public class ClinicDLL:IDataMapper<Clinic,Int32>
    {
        SqlCommand _command;
        public ClinicDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public int insert(Clinic item)
        {
            throw new NotImplementedException();
        }

        public int update(Clinic item)
        {
            throw new NotImplementedException();
        }

        public int delete(Clinic item)
        {
            throw new NotImplementedException();
        }
        
        public List<Clinic> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Clinic> GetAll(HospitalClinicExaminationPlace item)
        {
            List<Clinic> clinicList = new List<Clinic>();
            _command.CommandText = "Sp_GetALLClinic";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@CountyId",item.HospitalID.County.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Clinic clinic = new Clinic();
                        clinic.ID = (int)reader[0];
                        clinic.Name = reader[1].ToString();
                        clinicList.Add(clinic);
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
            return clinicList;
        }

        public Clinic Get(int id)
        {
            Clinic clinic = new Clinic();
            _command.CommandText = "Sp_GetClinic";
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
                        clinic.ID= (int)reader[0];
                        clinic.Name = reader[1].ToString();
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
            return clinic;
        }
    }
}
