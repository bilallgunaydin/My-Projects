using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        ELessonSelectionContext _context;
        public UnitOfWork()
        {
            _context = ELessonSelectionContext.ContextOlustur();
        }
        LessonRepository _lessonRepository;

        public LessonRepository LessonRepository
        {
            get
            {
                if (_lessonRepository == null)
                {
                    _lessonRepository = new LessonRepository(_context);
                }
                return _lessonRepository;
            }

        }
        ManagerRepository _managerRepository;
        public ManagerRepository ManagerRepository
        { 
            get
            {
                if (_managerRepository == null)
                {
                    _managerRepository = new ManagerRepository(_context);
                }
                return _managerRepository;
            }
        }
        StudentRepository _studentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }
        TeacherRepository _teacherRepository;
        public TeacherRepository TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_context);
                }
                return _teacherRepository;
            }
        }
        AccountTypeRepository _accountTypeRepository;
        

        public AccountTypeRepository AccountTypeRepository
        {
            get
            {
                if (_accountTypeRepository == null)
                {
                    _accountTypeRepository = new AccountTypeRepository(_context);
                }
                return _accountTypeRepository;
            }
        }
        DbContextTransaction _tran;
        public bool ApplyChanges()
        {
            bool isSucces = false;
            _tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                _context.SaveChanges();
                _tran.Commit();
                isSucces = true;
            }
            catch (Exception)
            {

                _tran.Rollback();
                isSucces = false;
            }
            finally
            {
                _tran.Dispose();
            }
            return isSucces;
        }
        
    }
}
