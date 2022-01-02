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
    public class SecurityQuestionDLL:IDataMapper<SecurityQuestion,Int32>
    {
        SqlCommand _command;
        public SecurityQuestionDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }
        public int insert(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public int update(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public int delete(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public List<SecurityQuestion> GetAll()
        {
            List<SecurityQuestion> _securityQuestionlist = new List<SecurityQuestion>();
            _command.CommandText = "sp_GetQuestion";
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
                        SecurityQuestion securityQuestion = new SecurityQuestion();
                        securityQuestion.ID = (int)reader[0];
                        securityQuestion.Question = (string)reader[1];
                        _securityQuestionlist.Add(securityQuestion);
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
            return _securityQuestionlist;
        }

        public SecurityQuestion Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
