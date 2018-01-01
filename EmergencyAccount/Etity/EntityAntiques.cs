using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmergencyAccount.Etity
{
    /// <summary>
    /// 文物信息
    /// </summary>
    public class EntityAntiques
    {
        public string Id
        {
            get;
            set;
        }
        [Required(ErrorMessage = "名称不能为空")]
        public string Name
        {
            get;
            set;
        }
        [Required(ErrorMessage = "年代信息不能为空")]
        public string AgeInfo
        {
            get;
            set;
        }

        [Required(ErrorMessage ="大分类编号不能为空")]
        public string MaxClassId
        {
            get;
            set;
        }

        public string MinClassId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "特征信息不能为空")]
        public string FeatureInfo
        {
            get;
            set;
        }
        [Required(ErrorMessage = "出土信息不能为空")]
        public string UnearthedInfo
        {
            get;
            set;
        }
        [Required(ErrorMessage = "馆藏信息不能为空")]
        public string BookInfo
        {
            get;
            set;
        }


        public string Description
        {
            get;
            set;
        }

        public string VoiceUrl
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public List<EntityAntiquesImg> ListImg { get; set; }
    }

    public class EntityAntiquesImg
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl
        {
            get; set;
        }

        /// <summary>
        /// 热度等级
        /// </summary>
        public int HotLevel
        {
            get; set;
        }
    }
}
