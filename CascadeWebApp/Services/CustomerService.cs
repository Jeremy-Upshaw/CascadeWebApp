using CascadeWebApp.Models;

namespace CascadeWebApp.Services
{
    public class CustomerService
    {
        public Task<List<Customer>> GetCustomersAsync()
        {
            // Placeholder data
            var customers = new List<Customer>
            {
                new Customer{ CustomerID=1, Studio="Studio A", Email="contact@studioa.com", Phone="555-1111", DiscountLevel="Gold", PaymentTerms="Net 30",
                    ContactFirstName="Alice", ContactSecondName="Smith", ShippingAddressLine1="100 Main St", ShippingCity="Townsville", ShippingState="CA", ShippingZip="90001", ShippingCountry="USA",
                    BillingAddressLine1="100 Main St", BillingCity="Townsville", BillingState="CA", BillingZip="90001", BillingCountry="USA"
                },
                new Customer{ CustomerID=2, Studio="Studio B", Email="hello@studiob.com", Phone="555-2222", DiscountLevel="Silver", PaymentTerms="Prepaid",
                    ContactFirstName="Bob", ContactSecondName="Lee", ShippingAddressLine1="200 Oak Ave", ShippingCity="Villageton", ShippingState="TX", ShippingZip="73301", ShippingCountry="USA",
                    BillingAddressLine1="200 Oak Ave", BillingCity="Villageton", BillingState="TX", BillingZip="73301", BillingCountry="USA"
                }
            };
            return Task.FromResult(customers);
        }
    }
}
