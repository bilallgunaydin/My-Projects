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
   public class CityDLL:IDataMapper<City,Int32>
    {
        SqlCommand _command;
        public CityDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public int insert(City item)
        {
            throw new NotImplementedException();
        }

        public int update(City item)
        {
            throw new NotImplementedException();
        }

        public int delete(City item)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            List<City> cityList = new List<City>();
            _command.CommandText = "sp_GetAllCity";
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        City city = new City();
                        city.ID = (int)reader[0];
                        city.Name = reader[1].ToString();
                        cityList.Add(city);
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
            return cityList;
        }

        public City Get(int id)
        {
            City city = new City();
            _command.CommandText = "sp_GetCity";
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
                    if (reader.Read())
                    {
                        city.ID = (int)reader[0];
                        city.Name = reader[1].ToString();
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
            return city;
        }
    }
}
