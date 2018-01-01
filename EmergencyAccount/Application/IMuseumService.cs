using EmergencyAccount.Etity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Application
{
    public interface IMuseumService
    {
        Task<List<EntityMuseum>> GetAllMuseumAsync();

        Task AddMuseumAsync(EntityMuseum entityMuseum);

        Task EditMuseumAsync(EntityMuseum entityMuseum);
    }
}
