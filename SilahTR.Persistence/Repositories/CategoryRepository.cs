using SilahTR.Domain.Entities;
using SilahTR.Persistence.Contexts;

namespace SilahTR.Persistence.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, Guid, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
