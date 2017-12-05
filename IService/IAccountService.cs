using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IAccountService
    {
        /// <summary>
        /// 根据主站店铺编号获得店铺信息
        /// </summary>
        /// <returns></returns>
        Task<List<MscAccount>> GetAllAccounts();


        Task<MscAccount> GetAccountById(int accId);
    }
}
