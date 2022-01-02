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
    public class CountyDLL:IDataMapper<County,Int32>
    {
        SqlCommand _command;
        public CountyDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public int insert(County item)
        {
            throw new NotImplementedException();
        }

        public int update(County item)
        {
            throw new NotImplementedException();
        }

        public int delete(County item)
        {
            throw new NotImplementedException();
        }

        public List<County> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<County> GetAll(County item)
        {
            List<County> countyList = new List<County>();
            _command.CommandText = "Sp_GetALLCounty";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@cityId",item.CityID.ID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        County county = new County();
                        county.ID = (int)reader[0];
                        county.CountyName = reader[1].ToString();
                        countyList.Add(county);
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
            return countyList;

        }

        public County Get(int id)
        {
            County county = new County();
            _command.CommandText = "Sp_GetCounty";
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
                    while(reader.Read())
                    {
                        county.ID = (int)reader[0];
                        county.CountyName = reader[1].ToString();
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
            return county;
        }
    }
}
