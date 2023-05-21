using CoreWebApiAngularCapstoneProject.Models;

namespace CoreWebApiAngularCapstoneProject.DAL
{
    public interface ICartService
    {
        public Task<List<Cart>> GetCartListAsync();
        public Task<IEnumerable<Cart>> GetCartByIdAsync(int CartId);
        public Task<int> AddCartAsync(Cart cart);
        public Task<int> DeleteCartAsync(int CartId);
        public Task<int> UpdateCartAsync(int CartId, Cart cart);
        
    }
}
