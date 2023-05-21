using CoreWebApiAngularCapstoneProject.DAL;
using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }
        [HttpGet("getmedicinelist")]
        public async Task<List<Medicine>> GetMedicinesAsync()
        {
            try
            {
                return await medicineService.GetMedicineListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("getmedicinebyid")]
        public async Task<IEnumerable<Medicine>> GetMedicinesByIdAsync(int Id)
        {
            try
            {
                var response = await medicineService.GetMedicineByIdAsync(Id);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addmedicine")]

        public async Task<IActionResult> AddMedicine(Medicine medicine)
        {
            if (medicine == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.AddMedicineAsync(medicine);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatemedicine")]

        public async Task<IActionResult> UpdateMedicine(int Id,Medicine medicine)
        {
            if (medicine == null && Id < 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.UpdateMedicineAsync(Id,medicine);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("deletemedicinebyid")]

        public async Task<IActionResult> DeleteMedicine(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.DeleteMedicineAsync(Id);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}


