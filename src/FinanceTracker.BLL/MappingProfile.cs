using AutoMapper;
using FinanceTracker.DAL.Db.Entities;
using FinanceTracker.Shared.Models.ApiModels;

namespace FinanceTracker.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionWriteModel, Transaction>();
            CreateMap<Transaction, TransactionReadModel>();
                //.ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTimeOffset.UtcNow));
        }
    }
}
