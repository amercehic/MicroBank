using Client.Core.Entities.Client;
using Client.Core.Models.Filters;
using MicroBank.Common.Specification;
using System;

namespace Client.Core.Specifications
{
    public class DocumentFilterSpecification : BaseSpecification<Document>
    {
        public DocumentFilterSpecification(Guid decisionLogId, DocumentFilter filter) : base(s =>
            (s.ClientId.Equals(decisionLogId)) &&
            (string.IsNullOrEmpty(filter.SearchTerm) || s.Title.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim()))
        )
        {
            AddInclude(s => s.Client);
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
        }
    }
}
