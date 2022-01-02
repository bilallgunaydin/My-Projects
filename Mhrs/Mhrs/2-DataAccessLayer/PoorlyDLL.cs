using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;

namespace Entities
{
    public class PoorlyDLL : IDataMapper<Poorly, Int32>
    {
        SqlCommand _command;
        public PoorlyDLL()
        {
            _command = SqlHelper.CreateSqlCommand();
        }

        public int insert(Poorly item)
        {
            int affectedRows = 0;
            if (item == null)
                return affectedRows;
            _command.CommandText = "Sp_PoorlySave";
            _command.Parameters.Clear();
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@firstName", item.Personel.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.Personel.LastName);
            _command.Parameters.AddWithValue("@tcNumber", item.Personel.TCNumber);
            _command.Parameters.AddWithValue("@birthdate", item.Personel.BirthDate);
            _command.Parameters.AddWithValue("@genderID", item.Personel.Gender.GenderID);
            _command.Parameters.AddWithValue("@fatherName", item.Personel.FatherName);
            _command.Parameters.AddWithValue("@motherName", item.Personel.MotherName);
            _command.Parameters.AddWithValue("@birthPlace", item.Personel.BirthPlace);
            _command.Parameters.AddWithValue("@mobilePhone", item.Contact.MobilePhone);
            _command.Parameters.AddWithValue("@landPhone", item.Contact.LandPhone);
            _command.Parameters.AddWithValue("@mail", item.Contact.Email);
            _command.Parameters.AddWithValue("@password", item.Safety.Password);
            _command.Parameters.AddWithValue("@securityQuestionID", item.Safety.SecurityQuestion.ID);
            _command.Parameters.AddWithValue("@answer", item.Safety.Answer);
            try
            {
                _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Kayıt başarısız oldu.");

            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }
        public int MailControl(Poorly inputPoorly,out Poorly outPoortly)
        {
            outPoortly = new Poorly();
            int affectedRows = 0;
            if (inputPoorly == null)
                return affectedRows;
            _command.CommandText = "sp_MailControl";
            _command.Parameters.Clear();
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@tcnumber", inputPoorly.Personel.TCNumber);
            _command.Parameters.AddWithValue("@mail", inputPoorly.Contact.Email);
            try
            {
                _command.Connection.Open();
                affectedRows =(int)_command.ExecuteScalar();
                if (affectedRows>0)
                {
                    SqlDataReader reader = _command.ExecuteReader();
                    while (reader.Read())
                    {
                        outPoortly.Personel.FirstName = reader[1].ToString();
                        outPoortly.Personel.LastName = reader[2].ToString();
                        outPoortly.Personel.TCNumber = reader[3].ToString();
                        outPoortly.Contact.Email = reader[4].ToString();
                        outPoortly.Safety.Password = reader[5].ToString();
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
            return affectedRows;
        }

        public int Get(Poorly poorly)
        {
            object result;
            int affectedRows = 0;
            _command.CommandText = "sp_LoginPoorly";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@TCNumber", poorly.Personel.TCNumber);
            _command.Parameters.AddWithValue("@password", poorly.Safety.Password);
            _command.Connection.Open();
            try
            {
                result = _command.ExecuteScalar();
                if (result != null)
                {
                    affectedRows = (int)result;
                }

            }
            catch (Exception)
            {
                throw new Exception("Giriş başarısız oldu.");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;

        }

        public int update(Poorly item)
        {
            int affectedRows = 0;
            if (item == null)
                return affectedRows;
            _command.CommandText = "sp_UpdatePoorly";
            _command.Parameters.Clear();
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@poorlyID", item.Personel.PatientID);
            _command.Parameters.AddWithValue("@firstName", item.Personel.FirstName);
            _command.Parameters.AddWithValue("@lastName", item.Personel.LastName);
            _command.Parameters.AddWithValue("@tcNumber", item.Personel.TCNumber);
            _command.Parameters.AddWithValue("@birthdate", item.Personel.BirthDate);
            _command.Parameters.AddWithValue("@genderID", item.Personel.Gender.GenderID);
            _command.Parameters.AddWithValue("@mobilePhone", item.Contact.MobilePhone);
            _command.Parameters.AddWithValue("@landPhone", item.Contact.LandPhone);
            _command.Parameters.AddWithValue("@mail", item.Contact.Email);
            _command.Parameters.AddWithValue("password", item.Safety.Password);
            _command.Parameters.AddWithValue("@securityQuestionID", item.Safety.SecurityQuestion.ID);
            _command.Parameters.AddWithValue("@answer", item.Safety.Answer);
            _command.Connection.Open();
            try
            {
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Güncelleme başarısız oldu.");

            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }

        public int delete(Poorly item)
        {
            int affectedRows = 0;
            if (item == null)
                return affectedRows;
            _command.CommandText = "sp_DeletePoorly";
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@poorlyID", item.Personel.PatientID);
            try
            {
                if (_command.Connection.State == ConnectionState.Closed)
                    _command.Connection.Open();
                affectedRows = _command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception("Silme işlemi başarısız oldu");
            }
            finally
            {
                _command.Connection.Close();
            }
            return affectedRows;
        }

        public List<Poorly> GetAll()
        {
            List<Poorly> poorlyList = new List<Poorly>();
            _command.CommandText = "sp_GetAllPorly";
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
                        Poorly poorly = new Poorly();
                        poorly.Personel.PatientID = (int)reader[0];
                        poorly.Personel.FirstName = reader[1].ToString();
                        poorly.Personel.LastName = reader[2].ToString();
                        poorly.Personel.TCNumber = reader[3].ToString();
                        poorly.Personel.BirthDate = (DateTime)reader[4];
                        poorly.Personel.FatherName = reader[6].ToString();
                        poorly.Personel.MotherName = reader[7].ToString();
                        poorly.Personel.BirthPlace = reader[8].ToString();
                        poorly.Personel.Gender.GenderName = reader[9].ToString();
                        poorly.Contact.MobilePhone = reader[10].ToString();
                        poorly.Contact.Email = reader[11].ToString();
                        poorly.Contact.LandPhone = reader[12].ToString();
                        poorlyList.Add(poorly);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw new Exception("İşlem Başarısız");
            }
            finally
            {
                _command.Connection.Close();
            }
            return poorlyList;
        }

        public Poorly Get(int id)
        {
            Poorly poorly = new Poorly();
            _command.CommandText = "sp_GetPoorly";
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
                        poorly.Personel.PatientID = (int)reader[0];
                        poorly.Personel.FirstName = reader[1].ToString();
                        poorly.Personel.LastName = reader[2].ToString();
                        poorly.Personel.TCNumber = reader[3].ToString();
                        poorly.Personel.BirthDate = (DateTime)reader[4];
                        poorly.Personel.FatherName = reader[6].ToString();
                        poorly.Personel.MotherName = reader[7].ToString();
                        poorly.Personel.BirthPlace = reader[8].ToString();
                        poorly.Personel.Gender.GenderName = reader[9].ToString();
                        poorly.Contact.MobilePhone = reader[10].ToString();
                        poorly.Contact.Email = reader[11].ToString();
                        poorly.Contact.LandPhone = reader[12].ToString();
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
            return poorly;
        }
    }
}
