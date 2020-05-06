using Client.Core.Entities.Client;

namespace Client.Core.Models.Dto.Client
{
    public class ClientFamilyDetailsDto
    {
        public int NumberOfMembers { get; set; }
        public string MaritalStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public int NumberOfChildren { get; set; }

        public ClientFamilyDetailsDto()
        {

        }

        public ClientFamilyDetailsDto(ClientFamilyDetailsData entity)
        {
            NumberOfMembers = entity.NumberOfMembers;
            MaritalStatus = entity.MaritalStatus;
            NumberOfDependents = entity.NumberOfDependents;
            NumberOfChildren = entity.NumberOfChildren;
        }
    }
}
