using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace MuseumAntiques.Entity
{
    /// <summary>
    /// 博物馆信息
    /// </summary>
    public class EntityMuseum
    {
        /// <summary>
        /// 属性: 
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 名称: 
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否启用: 
        /// </summary>
        public bool IsEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间: 
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 备注: 
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
    }
}
