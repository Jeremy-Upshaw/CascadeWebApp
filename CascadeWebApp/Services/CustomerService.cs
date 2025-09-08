using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class CustomerService
    {
        private readonly CascadeDbContext? _context;

        public CustomerService(CascadeDbContext? context = null)
        {
            _context = context;
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                await Task.Delay(10);
                return new List<Customers>
                {
                    new Customers 
                    { 
                        CustomerID = 1, 
                        Studio = "Acme Photography Studio", 
                        FirstName = "John", 
                        LastName = "Smith",
                        Email = "john.smith@acmephoto.com", 
                        Phone = "555-123-4567", 
                        DiscountLevel = "Premium", 
                        PaymentTerms = "Net 30",
                        Ship_To_1 = "123 Main Street",
                        Ship_To_2 = "Suite 100",
                        Ship_To_3 = "New York, NY 10001",
                        Ship_To_4 = "USA",
                        Bill_To_1 = "456 Oak Avenue",
                        Bill_To_2 = "Floor 2",
                        Bill_To_3 = "New York, NY 10002",
                        Bill_To_4 = "USA"
                    },
                    new Customers 
                    { 
                        CustomerID = 2, 
                        Studio = "Creative Vision Labs", 
                        FirstName = "Sarah", 
                        LastName = "Johnson",
                        Email = "sarah@creativevision.com", 
                        Phone = "555-987-6543", 
                        DiscountLevel = "Standard", 
                        PaymentTerms = "Net 15",
                        Ship_To_1 = "789 Pine Road",
                        Ship_To_2 = "Unit B",
                        Ship_To_3 = "Los Angeles, CA 90210",
                        Ship_To_4 = "USA",
                        Bill_To_1 = "789 Pine Road",
                        Bill_To_2 = "Unit B",
                        Bill_To_3 = "Los Angeles, CA 90210",
                        Bill_To_4 = "USA"
                    },
                    new Customers 
                    { 
                        CustomerID = 3, 
                        Studio = "Artisan Works", 
                        FirstName = "Michael", 
                        LastName = "Davis",
                        Email = "mike@artisanworks.net", 
                        Phone = "555-456-7890", 
                        DiscountLevel = "Basic", 
                        PaymentTerms = "COD",
                        Ship_To_1 = "321 Elm Street",
                        Ship_To_3 = "Chicago, IL 60601",
                        Ship_To_4 = "USA",
                        Bill_To_1 = "987 Maple Drive",
                        Bill_To_2 = "Apt 5A",
                        Bill_To_3 = "Chicago, IL 60602",
                        Bill_To_4 = "USA"
                    },
                    new Customers 
                    { 
                        CustomerID = 4, 
                        Studio = "Digital Dreams", 
                        FirstName = "Lisa", 
                        LastName = "Wilson",
                        Email = "lisa.wilson@digitaldreams.org", 
                        Phone = "555-321-0987", 
                        DiscountLevel = "Premium", 
                        PaymentTerms = "Net 45",
                        Ship_To_1 = "654 Cedar Lane",
                        Ship_To_2 = "Building C",
                        Ship_To_3 = "Miami, FL 33101",
                        Ship_To_4 = "USA",
                        Bill_To_1 = "654 Cedar Lane",
                        Bill_To_2 = "Building C", 
                        Bill_To_3 = "Miami, FL 33101",
                        Bill_To_4 = "USA"
                    },
                    new Customers 
                    { 
                        CustomerID = 5, 
                        Studio = "Pro Photo Services", 
                        FirstName = "Robert", 
                        LastName = "Brown",
                        Email = "rob@prophoto.biz", 
                        Phone = "555-654-3210", 
                        DiscountLevel = "Standard", 
                        PaymentTerms = "Net 30",
                        Ship_To_1 = "147 Birch Avenue",
                        Ship_To_3 = "Seattle, WA 98101",
                        Ship_To_4 = "USA",
                        Bill_To_1 = "147 Birch Avenue",
                        Bill_To_3 = "Seattle, WA 98101", 
                        Bill_To_4 = "USA"
                    }
                };
            }

            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderContents)
                .ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(int customerId)
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                var customers = await GetCustomersAsync();
                return customers.FirstOrDefault(c => c.CustomerID == customerId);
            }

            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderContents)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId);
        }

        public async Task<Customers> CreateCustomerAsync(Customers customer)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return customer;
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customers> UpdateCustomerAsync(Customers customer)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return customer;
            }

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return;
            }

            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
