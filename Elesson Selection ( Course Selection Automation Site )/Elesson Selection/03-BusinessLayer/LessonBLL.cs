using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LessonBLL:IBusiness<Lesson>
    {
        UnitOfWork _uow;
        public LessonBLL()
        {
            _uow = new UnitOfWork();
        }
        /// <summary>
        /// Lesson eklemek için kullanılır
        /// </summary>
        /// <param name="item">Lesson tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Add(Lesson item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name) && item.Credit > 0)
            {
                item.isPassive = false;
                _uow.LessonRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        ///  Lesson silmek için kullanılır.Normalde remove metodu kullanılması gerekir. Ancak veri tabanı ile işlem yapılıyorsa silmek yerine onu pasif hale getirmek veri kaybına ve tablolar arasındaki ilişkiye zarar vermez.
        /// </summary>
        /// <param name="item">Lesson tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Remove(Lesson item)
        {
            if (item != null)
            {
                item.isPassive = true;
                _uow.LessonRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;

        }
        /// <summary>
        /// Var olan Lesson'ları güncellemek için kullanılır.
        /// </summary>
        /// <param name="item">Lesson tipinde parametre alır.</param>
        /// <returns></returns>
        public bool Update(Lesson item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name) && item.Credit > 0)
            {
                item.isPassive = false;
                _uow.LessonRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        /// <summary>
        /// id'si ile eşleşen Lesson tipini döndürür.
        /// </summary>
        /// <param name="int id"></param>
        /// <returns></returns>
        public Lesson Get(int id)
        {
            return _uow.LessonRepository.Get(id);
        }
        /// <summary>
        /// Pasif olmayan tüm Lesson tiplerini liste olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<Lesson> GetAll()
        {
            return _uow.LessonRepository.GetAll().Where(l => l.isPassive == false && l.TeacherID==null).ToList();
        }
        public List<Lesson> GetAllLesson()
        {
            return _uow.LessonRepository.GetAll().Where(l => l.isPassive == false).ToList();
        }
        /// <summary>
        /// Belirli bir Öğrenci'ye ait tüm dersleri getirir.
        /// </summary>
        /// <param name="id">Öğrencinin ID'si</param>
        /// <returns></returns>
        public List<Lesson> GetALL(int id)
        {
            List<Lesson> Lessons = _uow.LessonRepository.GetAll().Where(x => x.Students.Any(s => s.ID == id)).ToList();
            return Lessons;
        }

        /// <summary>
        /// Belirli bir öğrencinin ders listesinde bulunmayan dersleri getirir.
        /// </summary>
        /// <param name="id">Öğrencinin ID'si</param>
        /// <returns></returns>
        public List<Lesson> LessonSelection(int id)
        {
            List<Lesson> Lessons = _uow.LessonRepository.GetAll().Where(x => x.Students.All(s => s.ID != id)).ToList();
            return Lessons;
        }
        public Lesson AddTeacher(int id)
        {
            return _uow.LessonRepository.GetAll().Where(l => l.ID == id).First();
        }
        public bool AddStudent(Lesson item, Student student)
        {
            if (item != null && student != null)
            {
                item.Students.Add(student);
                _uow.LessonRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
    }
}
