using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiAngularCapstoneProject.DAL
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.Description));
         

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddCategory @CategoryName,@CategoryDescription", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteCategoryAsync(int CategoryId)
        {
            var parameter = new SqlParameter("@CategoryId", CategoryId);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteCategory @CategoryId", parameter));
            return result;
        }


        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int CategoryId)
        {
            var parameter = new SqlParameter("@CategoryId", CategoryId);

            var result = await Task.Run(() => _context.Categories
            .FromSqlRaw(@"exec GetCategoryById @CategoryId", parameter).ToListAsync());
            return result;
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _context.Categories
                .FromSqlRaw<Category>("GetCategoryList")
                .ToListAsync();
        }

        public async Task<int> UpdateCategoryAsync(int CategoryId, Category category)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", CategoryId));
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.Description));
           

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec UpdateCategory @CategoryId, @CategoryName, @CategoryDescription", parameter.ToArray()));
            return result;
        }











        /*public Task<int> UpdateMedicineAsync(Medicine medicine, int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
