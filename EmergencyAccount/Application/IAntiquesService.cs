using DataAccess.BaseQuery;
using EmergencyAccount.Etity;
using EmergencyAccount.Etity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Application
{
    /// <summary>
    /// 文物信息
    /// </summary>
    public interface IAntiquesService
    {
        Task<PageBase<EntityAntiques>> GetPageAntiquesInfoAsync(EntityAntiquesSearch entityAntiquesSearch);


        Task<EntityAntiques> GetAntiquesInfoAsync(string id);

        Task<EntityAntiques> GetSingleAntiquesInfoAsync(string name, string maxClassId);

        Task UpdateAntiquesAsync(EntityAntiques entityAntiques);

        Task AddAntiquesAsync(EntityAntiques entityAntiques);
    }
}
