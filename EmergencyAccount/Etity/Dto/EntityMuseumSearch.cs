using EmergencyAccount.Etity.PageQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAccount.Etity.Dto
{
    public class EntityMuseumSearch : EntityBasePageQuery
    {
        /// <summary>
        /// 博物馆名称
        /// </summary>
        public string Name { get; set; }
    }
}
