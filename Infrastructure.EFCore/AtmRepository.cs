using System.Linq;
using System.Threading.Tasks;
using Domain.ATM;
using Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    class AtmRepository : IAtmRepository
    {
        private readonly AtmContext _atmContext;

        public AtmRepository(AtmContext context)
        {
            _atmContext = context;
        }

        public IQueryable<Atm> Get()
        {
            return _atmContext.Atms.Select(o => DtoToEntity(o));
        }

        public Task<Atm> GetByIdAsync(int id)
        {
            return Get().FirstOrDefaultAsync(o => o.Id == id);
        }

        public Task AddAsync(Atm atm)
        {
            var dto = EntityToDto(atm);

            _atmContext.Atms.Add(dto);
            return _atmContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Atm atm)
        {
            var dto = EntityToDto(atm);

            _atmContext.Atms.Update(dto);
            return _atmContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Atm atm)
        {
            var dto = EntityToDto(atm);

            _atmContext.Atms.Remove(dto);
            return _atmContext.SaveChangesAsync();
        }

        private static Atm DtoToEntity(AtmDto dto)
        {
            var entity = new Atm(dto.ATM_ID,dto.CASH_BALANCE);
            return entity;
        }

        private static AtmDto EntityToDto(Atm atm)
        {
            var dto = new AtmDto
            {
                ATM_ID = atm.Id,
                CASH_BALANCE = atm.CashBalance
            };

            return dto;
        }
    }
}
