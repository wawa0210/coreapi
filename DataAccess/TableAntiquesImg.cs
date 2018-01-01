using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    [Table("T_AntiquesImg")]
    public class TableAntiquesImg
    {
        public TableAntiquesImg()
        {
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
        /// 文物编号: 
        /// </summary>
        [Column("AntiquesId")]
        [Description("")]
        public string AntiquesId
        {
            get;
            set;
        }

        /// <summary>
        /// 图片地址: 
        /// </summary>
        [Column("ImgUrl")]
        [Description("")]
        public string ImgUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 热度等级: 
        /// </summary>
        [Column("HotLevel")]
        [Description("")]
        public int HotLevel
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
