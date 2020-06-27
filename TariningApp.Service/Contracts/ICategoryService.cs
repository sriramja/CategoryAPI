using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Domain;

namespace TariningApp.Service.Contracts
{
    public interface ICategoryService
    {
        Category GetById(int id);

        void Add(Category entity);
        void Update(Category entity);
        void Remove(int id);
        Task<IEnumerable<Category>> GetAll();
    }
}
