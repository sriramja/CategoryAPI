using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TariningApp.Service.Contracts;
using TrainingApp.DataAccess.UnitOfWork.Contract;
using TrainingApp.Domain;

namespace TariningApp.Service.Implementation
{
    public class CategoryRepository : ICategoryService
    {
        private IUnitOfWork<Category> unitOfWork;

        public CategoryRepository(IUnitOfWork<Category> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Category entity)
        {
            unitOfWork.Category.Add(entity);
            unitOfWork.Commit();

        }

        public async Task<IEnumerable<Category>> GetAll()
        {
           return await unitOfWork.Category.GetAll();
            
        }

        public Category GetById(int id)
        {
           return unitOfWork.Category.GetById(id);
        }

        public void Remove(int id)
        {
            unitOfWork.Category.Remove(id);
            unitOfWork.Commit();
        }

        public void Update(Category entity)
        {
            unitOfWork.Category.Update(entity);
            unitOfWork.Commit();
        }
    }
                   
}
