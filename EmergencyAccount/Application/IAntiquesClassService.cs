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
    /// 文物类别
    /// </summary>
    public interface IAntiquesClassService
    {
        Task<EntityAntiquesClass> GetAntiquesClassAsync(string id);

        Task AddAntiquesClassAsync(EntityAntiquesClass entityAntiquesClass);

        Task UpdateAntiquesClassAsync(EntityAntiquesClass entityAntiquesClass);

        Task<PageBase<EntityAntiquesClass>> GetPageAntiquesClassAsync(EntityAntiquesClassSearch entityAntiquesClassSearch);
    }
}
