using Client.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Core.Models.Dto.ClientApplication
{
    public class ClientApplicationFamilyDetailsDto
    {
        public int NumberOfMembers { get; set; }
        public string MaritalStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public int NumberOfChildren { get; set; }

        public ClientApplicationFamilyDetailsDto()
        {

        }

        public ClientApplicationFamilyDetailsDto(ClientApplicationFamilyDetailsData entity) 
        {
            NumberOfMembers = entity.NumberOfMembers;
            MaritalStatus = entity.MaritalStatus;
            NumberOfDependents = entity.NumberOfDependents;
            NumberOfChildren = entity.NumberOfChildren;
        }
    }    
}
