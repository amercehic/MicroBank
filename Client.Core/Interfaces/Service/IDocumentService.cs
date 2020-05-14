using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Service
{
    public interface IDocumentService
    {
        Task<DocumentDto> CreateAsync(DocumentCreateBindingModel model);
        Task<DocumentDto> GetByIdAsync(Guid id);
        Task<DocumentDto> UpdateAsync(Guid id, DocumentPatchBindingModel model);
        Task DeleteAsync(Guid id);
    }
}
