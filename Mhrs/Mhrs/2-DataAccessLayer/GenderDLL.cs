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
   public class GenderDLL:IDataMapper<Gender,Int32>
    {
        SqlCommand _command;
        public GenderDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public int insert(Gender item)
        {
            throw new NotImplementedException();
        }

        public int update(Gender item)
        {
            throw new NotImplementedException();
        }

        public int delete(Gender item)
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetAll()
        {
            List<Gender> genderList = new List<Gender>();
            _command.CommandText = "Sp_GetGender";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Gender gender = new Gender();
                        gender.GenderName = (string)reader[1];
                        gender.GenderID = (int)reader[0];
                        genderList.Add(gender);
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
            return genderList;

        }

        public Gender Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
