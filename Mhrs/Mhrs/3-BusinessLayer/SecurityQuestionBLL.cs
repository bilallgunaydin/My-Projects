using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities;

namespace BusinessLayer
{
    public class SecurityQuestionBLL : IBusiness<Entities.SecurityQuestion, Int32>
    {
        SecurityQuestionDLL _securityDLL = new SecurityQuestionDLL();
       
        public bool Insert(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public bool Update(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SecurityQuestion item)
        {
            throw new NotImplementedException();
        }

        public List<SecurityQuestion> GetAll()
        {
            List<SecurityQuestion> QuestionList = _securityDLL.GetAll();
            return QuestionList;
        }

        public SecurityQuestion Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
