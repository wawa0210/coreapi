using System.Threading.Tasks;
using DataAccess;
using CommonLib;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAccount.Application
{
    public class AccountService : IAccountService
    {
        private readonly EfDbContext _context;
        public AccountService(EfDbContext context)
        {
            _context = context;
        }

        public bool CheckLoginInfo(string inputPwd, string salt, string dbPwd)
        {
            var userPwd = DESEncrypt.Encrypt(inputPwd, salt);
            return userPwd == dbPwd;
        }

        public async Task<TableAccountManager> GetAccountManagerSync(string userName)
        {
            return await _context.AccountManagerData.FirstAsync(x => x.UserName == userName);
        }

        //Task<EntityAccountManager> IAccountService.GetAccountManager(string userName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
