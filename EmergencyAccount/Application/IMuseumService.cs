using DataAccess.BaseQuery;
using EmergencyAccount.Etity;
using EmergencyAccount.Etity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Application
{
    public interface IMuseumService
    {
        Task<PageBase<EntityMuseum>> GetPageMuseumAsync(EntityMuseumSearch entityMuseumSearch);

        Task AddMuseumAsync(EntityMuseum entityMuseum);

        Task EditMuseumAsync(EntityMuseum entityMuseum);
        Task DisableMuseumAsync(string id);
    }
}
