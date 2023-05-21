using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiAngularCapstoneProject.DAL
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCartAsync(Cart cart)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Name", cart.Name));
            parameter.Add(new SqlParameter("@Price", cart.Price));
            parameter.Add(new SqlParameter("@Seller", cart.Seller));
            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddCart @Name,@Price,@Seller", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteCartAsync(int CartId)
        {
            var parameter = new SqlParameter("@CartId", CartId);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteCart @CartId", parameter));
            return result;
        }


        public async Task<IEnumerable<Cart>> GetCartByIdAsync(int CartId)
        {
            var parameter = new SqlParameter("@CartId", CartId);

            var result = await Task.Run(() => _context.Carts
            .FromSqlRaw(@"exec GetCartById @CartId", parameter).ToListAsync());
            return result;
        }

        public async Task<List<Cart>> GetCartListAsync()
        {
            return await _context.Carts
                .FromSqlRaw<Cart>("GetCartList")
                .ToListAsync();
        }

        public async Task<int> UpdateCartAsync(int CartId, Cart cart)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CartId", CartId));
            parameter.Add(new SqlParameter("@Name", cart.Name));
            parameter.Add(new SqlParameter("@Price", cart.Price));
            parameter.Add(new SqlParameter("@Seller", cart.Seller));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec UpdateCart @CartId, @Name, @Price, @Seller", parameter.ToArray()));
            return result;
        }

      
    }
}

