using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class ClientFamilyDetailsData
    {
        public int Id { get; set; }
        public int NumberOfMembers { get; set; }
        [Required]
        [StringLength(50)]
        public string MaritalStatus { get; set; }
        [Required]
        public int NumberOfDependents { get; set; }
        [Required]
        public int NumberOfChildren { get; set; }
    }

}
