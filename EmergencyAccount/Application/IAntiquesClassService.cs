using EmergencyAccount.Etity;
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

        Task<List<EntityAntiquesClass>> GetListAntiquesClassAsync();
    }
}
