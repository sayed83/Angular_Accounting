using Accounting_Api.Data;
using Accounting_Api.Models.Admin;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class CompanyController : ControllerBase
    {
        private readonly DBContext _context;

        public CompanyController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompany()
        {
            return Ok(await _context.Companies.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Company>>> CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return Ok(await _context.Companies.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Company>>> UpdateCompany(Company company)
        {
            var comdata = await _context.Companies.FindAsync(company.ComId);
            if (comdata == null)
                return BadRequest("Company Not Fount");
            comdata.Name = company.Name;
            comdata.ComType = company.ComType;
            comdata.BusinessType = company.BusinessType;
            comdata.Address = company.Address;
            comdata.Phone = company.Phone;
            comdata.Email = company.Email;
            comdata.WorkingHour = company.WorkingHour;

            await _context.SaveChangesAsync();
            return Ok(await _context.Companies.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> DeleteCompany(int id)
        {
            var comdata = await _context.Companies.FindAsync(id);
            if (comdata == null)
                return BadRequest("Company Not Fount");
            _context.Companies.Remove(comdata);
            await _context.SaveChangesAsync();
            return Ok(await _context.Companies.ToListAsync());
        }
    }
}
