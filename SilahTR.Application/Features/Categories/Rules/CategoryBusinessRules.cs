using SilahTR.Application.Features.Categories.Constants;

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
    }
}
