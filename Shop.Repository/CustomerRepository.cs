using Microsoft.EntityFrameworkCore;
using Shop.Entity;
using Shop.Entity.Models;

namespace Shop.Repository
{   
    //------------------------------------(DATA ACCESS LAYER)

    public class CustomerRepository
    {   //Dependency Injection
        private readonly EvaShopDbfContext _context;

        public CustomerRepository(EvaShopDbfContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
