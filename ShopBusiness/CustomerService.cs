using Shop.Repository;
using Shop.Entity.Models;
namespace ShopBusiness
{
    public class CustomerService
    {   
        //Depandency Injection
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            // Validate customer data
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            // Validate email format
            if (!IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (string.IsNullOrWhiteSpace(customer.ShippingAddress))
            {
                throw new ArgumentException("Shipping address is required.");
            }

            //// Check if a customer with the same email already exists
            //var existingCustomer = await _customerRepository.GetCustomerByEmail(customer.Email);
            //if (existingCustomer != null)
            //{
            //    throw new ArgumentException($"A customer with email '{customer.Email}' already exists.");
            //}

            // Add the customer
            return await _customerRepository.AddCustomer(customer);
        }
        //----------------
        private bool IsValidEmail(string email)
        {
            throw new NotImplementedException();
        }
        //----------------
        //Updating Customer Validation
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            // Validate customer data
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            // Validate email format
            if (!IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (string.IsNullOrWhiteSpace(customer.ShippingAddress))
            {
                throw new ArgumentException("Shipping address is required.");
            }

            //// Check if a customer with the same email already exists (excluding the current customer)
            //var existingCustomer = await _customerRepository.GetCustomerByEmail(customer.Email);
            //if (existingCustomer != null && existingCustomer.CustomerId != customer.CustomerId)
            //{
            //    throw new ArgumentException($"A customer with email '{customer.Email}' already exists.");
            //}

            // Update the customer
            return await _customerRepository.UpdateCustomer(customer);
        }
        //Delete Customer Validation
        public async Task DeleteCustomer(int customerId)
        {
            // Check if the customer exists
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} does not exist.");
            }

            //// Check if the customer has any associated orders
            //var customerOrders = await _orderRepository.GetOrdersByCustomerId(customerId);
            //if (customerOrders.Any())
            //{
            //    throw new InvalidOperationException("Cannot delete a customer with associated orders.");
            //}

            // Delete the customer
            await _customerRepository.DeleteCustomer(customerId);
        }
    }
}
