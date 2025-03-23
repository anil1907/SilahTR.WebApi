using SilahTR.Application.Features.Categories.Constants;
using SilahTR.Domain.Entities;

namespace SilahTR.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task NameCannotBeDuplicatedWhenInserted(string name)
        {
            var result = await _categoryRepository.AnyAsync(c => c.Name == name);
            if (result)
                throw new BusinessException(CategoryMessages.NameAlreadyExists);
        }

        public async Task CategoryNotFound(Category category)
        {
            if (category is null)
                throw new BusinessException(CategoryMessages.CustomerNotFound);
        }
        
        public async Task CategoryShouldExistWhenRequested(Guid id)
        {
            var result = await _categoryRepository.GetAsync(c => c.Id == id);
            if (result == null)
                throw new BusinessException(CategoryMessages.CustomerNotFound);
        }
    }
}