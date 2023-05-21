using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiAngularCapstoneProject.DAL
{
    public class MedicineService : IMedicineService
    {
        private readonly ApplicationDbContext _context;

        public MedicineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddMedicineAsync(Medicine medicine)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@medicine_name", medicine.medicine_name));
            parameter.Add(new SqlParameter("@medicine_img", medicine.medicine_img));
            parameter.Add(new SqlParameter("@medicine_seller", medicine.medicine_seller));
            parameter.Add(new SqlParameter("@medicine_price", medicine.medicine_price));
            parameter.Add(new SqlParameter("@medicine_details", medicine.medicine_details));
            parameter.Add(new SqlParameter("@CategoryId", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddMedicine @medicine_name,@medicine_img,@medicine_seller,@medicine_price,@medicine_details,@CategoryId", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteMedicineAsync(int Id)
        {
            var parameter = new SqlParameter("@MedicineId", Id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteMedicine @MedicineId", parameter));
            return result;
        }


        public async Task<IEnumerable<Medicine>> GetMedicineByIdAsync(int Id)
        {
            var parameter = new SqlParameter("@MedicineId", Id);

            var result = await Task.Run(() => _context.Medicines
            .FromSqlRaw(@"exec GetMedicineById @MedicineId", parameter).ToListAsync());
            return result;
        }

        public async Task<List<Medicine>> GetMedicineListAsync()
        {
            return await _context.Medicines
                .FromSqlRaw<Medicine>("GetMedicineList")
                .ToListAsync();
        }

        public async Task<int> UpdateMedicineAsync(int Id, Medicine medicine)
        {
           
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("MedicineId", Id));
            parameter.Add(new SqlParameter("@medicine_name", medicine.medicine_name));
            parameter.Add(new SqlParameter("@medicine_img", medicine.medicine_img));
            parameter.Add(new SqlParameter("@medicine_seller", medicine.medicine_seller));
            parameter.Add(new SqlParameter("@medicine_price", medicine.medicine_price));
            parameter.Add(new SqlParameter("@medicine_details", medicine.medicine_details));
            parameter.Add(new SqlParameter("@CategoryId", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec UpdateMedicine @MedicineId, @medicine_name, @medicine_img, @medicine_seller, @medicine_price, @medicine_details, @CategoryId", parameter.ToArray()));
            return result;
        }











      /*  public Task<int> UpdateMedicineAsync(Medicine medicine, int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
