using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DataAccess.Contract;
using TrainingApp.Domain;

namespace TrainingApp.DataAccess.UnitOfWork.Contract
{
    public interface IUnitOfWork<T> where T: class
    {
        IRepository<Category> Category { get; }
        IRepository<Product> Product { get; }
        void Commit();
        void Rollback();
    }
}
