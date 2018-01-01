using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    [Table("T_Museum")]

    public class TableMuseum
    {

        public TableMuseum()
        {
            IsEnable = true;
            Remark = "";
            CreateTime = DateTime.Now;
        }

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
        /// 名称: 
        /// </summary>
        [Column("Name")]
        [Description("")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否启用: 
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
