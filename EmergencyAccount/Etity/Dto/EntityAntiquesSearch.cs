using EmergencyAccount.Etity.PageQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAccount.Etity.Dto
{
    public class EntityAntiquesSearch : EntityBasePageQuery
    {
        public string Name { get; set; }

        public string MaxClassId { get; set; }
        public string MinClassId { get; set; }
    }
}
