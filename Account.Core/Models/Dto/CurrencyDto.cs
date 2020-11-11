using Account.Core.Entities;
using MicroBank.Common.Models;

namespace Account.Core.Models.Dto
{
    public class CurrencyDto : BaseDto<int>
    {
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public string Code { get; set; }
        public int CountryNumber { get; set; }

        //public CurrencyDto(Currency entity) : base(entity)
        //{
        //    Country = entity.Country;
        //    CurrencyName = entity.CurrencyName;
        //    Code = entity.Code;
        //    CountryNumber = entity.CountryNumber;
        //}
    }
}
