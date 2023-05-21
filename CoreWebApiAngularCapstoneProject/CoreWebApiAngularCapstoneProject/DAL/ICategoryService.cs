using CoreWebApiAngularCapstoneProject.Models;

namespace CoreWebApiAngularCapstoneProject.DAL
{

    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryListAsync();
        public Task<IEnumerable<Category>> GetCategoryByIdAsync(int CategoryId);
        public Task<int> AddCategoryAsync(Category category);
        public Task<int> DeleteCategoryAsync(int CategoryId);
        public Task<int> UpdateCategoryAsync(int CategoryId, Category category);
    }
}
