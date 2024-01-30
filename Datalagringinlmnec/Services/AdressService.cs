using Datalagringinlmnec.Entities;
using Datalagringinlmnec.Repositories;

namespace Datalagringinlmnec.Services;

internal class AdressService
{
    private readonly AdressRepository _adressRepository;

    public AdressService(AdressRepository adressRepository)
    {
        _adressRepository = adressRepository;
    }

    public AdressEntity CreateAdress(string streetName, string postalCode, string city)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (adressEntity == null)
            {
                adressEntity = _adressRepository.Create(new AdressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
            }
            return adressEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public AdressEntity GetAdressByStreetName(string streetName, string postalCode, string city)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return adressEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public AdressEntity GetAdressById(int Id)
    {
        try
        {
            var adressEntity = _adressRepository.Get(x => x.Id == Id);
            return adressEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<AdressEntity> GetAllAdresses()
    {
        try
        {
            var adresses = _adressRepository.GetAll();
            return adresses;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public AdressEntity UpdateAdress(AdressEntity adressEntity)
    {
        var updatedEntity = _adressRepository.Update(x => x.Id == adressEntity.Id, adressEntity);
        return updatedEntity;
    }

    public bool DeleteAdress(int id)
    {
        try
        {
            _adressRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
    }
}
