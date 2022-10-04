using AddressBookAPI.Context;
using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookAPI.Services.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressBookDbContext _context;

        public AddressRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public void AddAddress(Address Address)
        {
            _context.Addresses.Add(Address);
        }

        public void AddAddresss(IList<Address> Address)
        {
            _context.Addresses.AddRange(Address);
        }

        public ICollection<Address> GetAddressByUserId(Guid userId)
        {
            var Addresss = _context.Addresses.ToList();
            return Addresss.FindAll(Address => Address.UserId == userId);
        }

        public ICollection<Address> GetAddresssByAddressBookId(Guid addressBookId)
        {
            var Addresss = _context.Addresses.ToList();
            return Addresss.FindAll(Address => Address.AddressBookId == addressBookId);
        }

        public void UpdateAddress(IList<Address> Address)
        {
            _context.Addresses.UpdateRange(Address);
        }

        public void DeleteAddress(IList<Address> Address)
        {
            _context.Addresses.RemoveRange(Address);
        }
    }
}
