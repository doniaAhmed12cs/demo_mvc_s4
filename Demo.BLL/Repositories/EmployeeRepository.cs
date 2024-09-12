using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MvcAppG03DbContext _context;

        public EmployeeRepository(MvcAppG03DbContext context) : base(context)
        {
            _context = context;
        }

       
		public async Task<IEnumerable<Employee>> GetEmployeeByName(string SearchValue)
		{
			return await _context.Employees.Where(E => E.Name.ToLower().Contains(SearchValue.ToLower())).Include(E => E.Department).ToListAsync();
		}



	}
}
