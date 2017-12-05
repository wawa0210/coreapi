using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly EfDbContext _context;
        public AccountService(EfDbContext context)
        {
            _context = context;
        }

        public async Task<MscAccount> GetAccountById(int accId)
        {
            var result = await _context.MscAccount.FirstAsync(x => x.Id == accId);

            return result;
        }

        public async Task<List<MscAccount>> GetAllAccounts()
        {
            var result = await _context.MscAccount.FromSql("select * from msc_account").ToAsyncEnumerable().ToList();

            return result;
        }
    }
}
