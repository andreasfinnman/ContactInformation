using ContactInformation.Api.Models;

namespace ContactInformation.Api.Services
{
    public interface IContactInfoService
    {
        public Task<List<ContactInfo>> ListContactInfo();
        public Task<ContactInfo> GetContactInfo(string id);
        public Task CreateContactInfo(Models.ContactInfo id);
        public Task UpdateContactInfo(string id, ContactInfo contactInfo);
        public Task<bool> DeleteContactInfo(string id);

    }
}
