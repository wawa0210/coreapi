using EmergencyAccount.Etity.PageQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAccount.Etity.Dto
{
    public class EntityAntiquesClassSearch : EntityBasePageQuery
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 父级分类编号
        /// </summary>
        public string ParentId { get; set; }
    }
}
