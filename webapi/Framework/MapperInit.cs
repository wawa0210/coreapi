using AutoMapper;
using DataAccess;
using EmergencyAccount.Etity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Framework
{
    public class MapperInit
    {
        public static void InitMapping()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<TableMuseum, EntityMuseum>()
                       .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                       .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                       .ForMember(x => x.IsEnable, y => y.MapFrom(z => z.IsEnable))
                       .ForMember(x => x.CreateTime, y => y.MapFrom(z => z.CreateTime))
                       .ForMember(x => x.Remark, y => y.MapFrom(z => z.Remark))
                       .ForAllOtherMembers(x => x.Ignore());

                    cfg.CreateMap<TableAntiquesClass, EntityAntiquesClass>()
                       .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                       .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                       .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                       .ForMember(x => x.ClassLevel, y => y.MapFrom(z => z.ClassLevel))
                       .ForMember(x => x.ParentId, y => y.MapFrom(z => z.ParentId))
                       .ForMember(x => x.IsEnable, y => y.MapFrom(z => z.IsEnable))
                       .ForMember(x => x.Remark, y => y.MapFrom(z => z.Remark))
                       .ForMember(x => x.HotLevel, y => y.MapFrom(z => z.HotLevel))
                       .ForAllOtherMembers(x => x.Ignore());
                }
            );
        }
    }
}
