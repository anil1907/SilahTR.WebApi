using SilahTR.Domain.Entities;

namespace SilahTR.Persistence.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, Guid, BaseDbContext>, ICategoryRepository
    {
        public CategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
