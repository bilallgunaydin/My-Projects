using _02_DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer
{
    public class UnitOfWork
    {
        TaskManagementContext _context;
        public UnitOfWork()
        {
            _context = new TaskManagementContext();
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
        CustomerRepository _customerRepository;
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }
                return _customerRepository;
            }

        }
        CustomerRequestRepository _customerRequestRepository;
        public CustomerRequestRepository CustomerRequestRepository
        {
            get
            {
                if (_customerRequestRepository == null)
                {
                    _customerRequestRepository = new CustomerRequestRepository(_context);
                }
                return _customerRequestRepository;
            }
        }
        EmployeeRepository _employeeRepository;

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }

        ProjectRepository _projectRepository;

        public ProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new ProjectRepository(_context);
                }
                return _projectRepository;
            }
        }
        ProjectEmployeeRepository _projectEmployeeRepository;

        public ProjectEmployeeRepository ProjectEmployeeRepository
        {
            get
            {
                if (_projectEmployeeRepository == null)
                {
                    _projectEmployeeRepository = new ProjectEmployeeRepository(_context);
                }
                return _projectEmployeeRepository;
            }
        }

        SituaitionRepository _situaitionRepository;

        public SituaitionRepository SituaitionRepository
        {
            get
            {
                if (_situaitionRepository == null)
                {
                    _situaitionRepository = new SituaitionRepository(_context);
                }
                return _situaitionRepository;
            }
        }

        TaskRepository _taskRepository;

        public TaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_context);
                }
                return _taskRepository;
            }
        }
        DbContextTransaction _tran;
        public bool ApplyChanges()
        {
            bool isSucces = false;
            _tran = _context.Database.BeginTransaction
                (System.Data.IsolationLevel.ReadCommitted);

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
