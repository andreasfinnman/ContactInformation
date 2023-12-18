using ContactInformation.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContactInformation.Api.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMongoCollection<Models.ContactInfo> _contactInfoCollection;
        public ContactInfoService(IOptions<ContactInformationDatabaseSettings> contactInfoDbSettings)
        {
            var mongoClient = new MongoClient(
                contactInfoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                contactInfoDbSettings.Value.DatabaseName);
            _contactInfoCollection = mongoDatabase.GetCollection<Models.ContactInfo>(
                contactInfoDbSettings.Value.ContactInfoCollectionName);
        }

        public async Task<string> CreateContactInfo(ContactInfo model)
        {
            await _contactInfoCollection.InsertOneAsync(model);
            return model.Id;
        }

        public async Task<bool> DeleteContactInfo(string id)
        {
            var result =  await _contactInfoCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount == 1;
        }
        public async Task<ContactInfo> GetContactInfo(string id)
        {
            return await _contactInfoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ContactInfo>> ListContactInfo()
        {
            return await _contactInfoCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateContactInfo(string id, ContactInfo contactInfo)
        {
            await _contactInfoCollection.ReplaceOneAsync(x => x.Id == id, contactInfo);
        }
    }
}
