using Datalagringinlmnec.Entities;
using Datalagringinlmnec.Repositories;

namespace Datalagringinlmnec.Services;

internal class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AdressService _adressService;
    private readonly RoleService _roleService;

    public CustomerService(CustomerRepository customerRepository, AdressService adressService, RoleService roleService)
    {
        _customerRepository = customerRepository;
        _adressService = adressService;
        _roleService = roleService;
    }

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        try
        {
            var roleEntity = _roleService.CreateRole(roleName);
            var adressEntity = _adressService.CreateAdress(streetName, postalCode, city);

            var customerEntity = new CustomerEntity 
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntity.Id,
                AdressId = adressEntity.Id
            };
            customerEntity = _customerRepository.Create(customerEntity);
            return customerEntity;
        }
        catch(Exception ex) { Console.WriteLine(ex); }
        return null!;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        try
        {
            var customerEntity = _customerRepository.Get(x => x.Id == id);
            return customerEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        try
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            return customerEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<CustomerEntity> GetAllCustomers()
    {
        try
        {
            var roles = _customerRepository.GetAll();
            return roles;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updatedEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updatedEntity;
    }

    public bool DeleteCustomer(int id)
    {
        try
        {
            _customerRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
    }
}
