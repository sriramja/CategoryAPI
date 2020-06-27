using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.DataAccess.Contract
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
