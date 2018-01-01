using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    [Table("T_AntiquesClass")]
    public class TableAntiquesClass
    {
        /// <summary>
        /// 属性: 
        /// </summary>
        [Column("Id")]
        [Description("")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 标题: 
        /// </summary>
        [Column("Title")]
        [Description("")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 描述: 
        /// </summary>
        [Column("Description")]
        [Description("")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 分类登记: 
        /// </summary>
        [Column("ClassLevel")]
        [Description("")]
        public int ClassLevel
        {
            get;
            set;
        }

        /// <summary>
        /// 父编号: 
        /// </summary>
        [Column("ParentId")]
        [Description("")]
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可用: 
        /// </summary>
        [Column("IsEnable")]
        [Description("")]
        public bool IsEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间: 
        /// </summary>
        [Column("CreateTime")]
        [Description("")]
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 备注: 
        /// </summary>
        [Column("Remark")]
        [Description("")]
        public string Remark
        {
            get;
            set;
        }
    }
}
