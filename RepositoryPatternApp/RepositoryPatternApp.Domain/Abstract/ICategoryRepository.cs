using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        void Save(Category category);

        Category Delete(int id);

        IEnumerable<Category> GetAll();

        Category GetById(int id);
    }
}