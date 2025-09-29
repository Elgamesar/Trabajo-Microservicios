using Bogus;
using WebClient.DTOs;

namespace WebClient.Data
{
    public class DataGeneratorCustomer
    {
        Faker<CreateCustomerDto> _customerFaker;

        public DataGeneratorCustomer()
        {
            Randomizer.Seed = new Random(123);

            _customerFaker = new Faker<CreateCustomerDto>()
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email);
        }

        public CreateCustomerDto GenerateCustomer()
        {
            return _customerFaker.Generate();
        }

    }
}