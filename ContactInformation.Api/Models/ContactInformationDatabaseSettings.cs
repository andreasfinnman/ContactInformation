namespace ContactInformation.Api.Models
{
    public class ContactInformationDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ContactInfoCollectionName { get; set; } = null!;
    }
}
