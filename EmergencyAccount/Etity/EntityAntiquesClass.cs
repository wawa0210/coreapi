using EmergencyAccount.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmergencyAccount.Etity
{
    public class EntityAntiquesClass
    {
        public EntityAntiquesClass()
        {
            Description = "";
            ClassLevel = (int)EnumAntiquesClassLevel.MainLevel;
            IsEnable = true;
            Remark = "";
            ParentId = "";
            HotLevel = 1;
        }
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 标题: 
        /// </summary>
        [Required(ErrorMessage = "分类标题不能为空")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 描述: 
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 分类等级: 
        /// </summary>
        public int HotLevel
        {
            get;
            set;
        }

        [Required(ErrorMessage = "分类等级不能为空")]
        public int ClassLevel
        {
            get;
            set;
        }

        /// <summary>
        /// 父编号: 
        /// </summary>
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可用: 
        /// </summary>
        public bool IsEnable
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }
    }
}
