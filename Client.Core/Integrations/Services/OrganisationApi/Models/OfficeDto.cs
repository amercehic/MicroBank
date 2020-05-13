using System;

namespace Client.Core.Integrations.Services.OfficeApi.Models
{
    public class OfficeDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OfficeDto Parent { get; set; }
        public string OfficeCode { get; set; }
        public DateTime Openingdate { get; set; }
        public bool IsMainOffice { get; set; }
    }
}
