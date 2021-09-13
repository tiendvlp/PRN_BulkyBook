using System;
using System.Collections;
using System.Linq;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.MvcControllers.CategoryMvcController
{
    public class CategoryMvcController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryMvcController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }

        public Category Get(int id)
        {
            return _unitOfWork.Category.Get(id);
        }
    }
}
