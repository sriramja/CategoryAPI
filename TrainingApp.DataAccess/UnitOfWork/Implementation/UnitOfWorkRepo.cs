using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DataAccess.Contract;
using TrainingApp.DataAccess.Implementation;
using TrainingApp.DataAccess.UnitOfWork.Contract;
using TrainingApp.Domain;

namespace TrainingApp.DataAccess.UnitOfWork.Implementation
{
    public class UnitOfWorkRepo<T> : IUnitOfWork<T> where T:class
    {
        private readonly ApplicationContext _databaseContext;
        private IRepository<Category> _CategoryRepo;
        private IRepository<Product> _ProductRepo;
        public UnitOfWorkRepo(ApplicationContext _databaseContext)
        {
            this._databaseContext = _databaseContext;
        }
        public IRepository<Category> Category
        {
            get { return _CategoryRepo = _CategoryRepo ?? new GenericRepository<Category>(_databaseContext); }
        }

        public IRepository<Product> Product
        {
            get { return _ProductRepo = _ProductRepo ?? new GenericRepository<Product>(_databaseContext); }
        }

        public void Commit()
        { _databaseContext.SaveChanges(); }
        public void Rollback()
        { _databaseContext.Dispose(); }
    }


}
