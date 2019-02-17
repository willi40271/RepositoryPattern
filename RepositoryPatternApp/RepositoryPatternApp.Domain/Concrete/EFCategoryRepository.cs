using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }

        public void Save(Category category)
        {
            if (category.CategoryId.Equals(0))
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories.Find(category.CategoryId);
                if (dbEntry != null)
                {
                    dbEntry.Description = category.Description;
                }
            }

            context.SaveChanges();
        }

        public Category Delete(int id)
        {
            Category dbEntry = context.Categories.Find(id);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
        }
    }
}