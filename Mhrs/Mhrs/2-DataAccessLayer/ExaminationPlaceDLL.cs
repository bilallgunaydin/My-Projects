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
    public class ExaminationPlaceDLL : IDataMapper<ExaminationPlace, Int32>
    {
        SqlCommand _command;
        public ExaminationPlaceDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public int insert(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }

        public int update(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }

        public int delete(ExaminationPlace item)
        {
            throw new NotImplementedException();
        }
        public List<ExaminationPlace> GetAll()
        {
            throw new NotImplementedException();

        }
        public List<ExaminationPlace> GetAll(HospitalClinicExaminationPlace exam)
        {
            throw new NotImplementedException();
        }

        public List<ExaminationPlace> GetAll(Hospital hospital,Clinic clinic)
        {
            List<ExaminationPlace> examinationPlaceList = new List<ExaminationPlace>();
            _command.CommandText = "sp_GetExaminationPlace";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@hospitalId", hospital.ID);
            _command.Parameters.AddWithValue("@clinicId", clinic.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExaminationPlace examinationPlace = new ExaminationPlace();
                        examinationPlace.ID = (int)reader[0];
                        examinationPlace.Name = reader[1].ToString();
                        examinationPlaceList.Add(examinationPlace);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception("İşlem başarısız oldu");

            }
            finally
            {
                _command.Connection.Close();
            }
            return examinationPlaceList;
        }

        public ExaminationPlace Get(int id)
        {
            ExaminationPlace examinationPlace = new ExaminationPlace();
            _command.CommandText = "sp_GetExaminationPlace";
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
                        examinationPlace.ID = (int)reader[0];
                        examinationPlace.Name = reader[1].ToString();
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
            return examinationPlace;
        }
    }
}
