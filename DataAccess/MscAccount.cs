using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("MSC_Account")]

    public class MscAccount
    {
        /// <summary> 
        /// 主键编号 
        /// </summary>
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        /// <summary>
        /// 主站对应编号
        /// </summary>
        public long OriginalId { get; set; }

        /// <summary> 
        /// 店铺公告 
        /// </summary>
        [Column("ShowcaseNotice")]
        public string ShowcaseNotice { get; set; }


        /// <summary> 
        /// 橱窗标题 
        /// </summary>
        [Column("ShowcaseTitle")]
        public string ShowcaseTitle { get; set; }


        /// <summary> 
        /// 店铺电话 
        /// </summary>
        [Column("AccountMobile")]
        public string AccountMobile { get; set; }


        /// <summary> 
        /// 店铺微信号 
        /// </summary>
        [Column("AccountWechat")]
        public string AccountWechat { get; set; }


        /// <summary> 
        /// 所属省编号 
        /// </summary>
        [Column("ProvinceId")]
        public string ProvinceId { get; set; }


        /// <summary> 
        /// 省名称 
        /// </summary>
        [Column("ProvinceName")]
        public string ProvinceName { get; set; }


        /// <summary> 
        /// 市编号 
        /// </summary>
        [Column("CityId")]
        public string CityId { get; set; }


        /// <summary> 
        /// 市名称 
        /// </summary>
        [Column("CityName")]
        public string CityName { get; set; }


        /// <summary> 
        /// 县编号 
        /// </summary>
        [Column("CountyId")]
        public string CountyId { get; set; }


        /// <summary> 
        /// 县名称 
        /// </summary>
        [Column("CountyName")]
        public string CountyName { get; set; }


        /// <summary> 
        /// 详细地址 
        /// </summary>
        [Column("AddressDetail")]
        public string AddressDetail { get; set; }


        /// <summary> 
        /// 店铺行业类别(设计付款方式和配送方式，后期考虑字典表维护) 
        /// </summary>
        [Column("AccountIndustry")]
        public string AccountIndustry { get; set; }


        /// <summary> 
        /// 店铺介绍 
        /// </summary>
        [Column("AccountDesc")]
        public string AccountDesc { get; set; }


        /// <summary> 
        /// 标签 
        /// </summary>
        [Column("Flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 账户头像
        /// </summary>
        [Column("AccountPhoto")]
        public string AccountPhoto { get; set; }

        /// <summary> 
        /// 备注 
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 微信随机字符串
        /// </summary>
        [Column("RandStr")]
        public string RandStr { get; set; }

        /// <summary> 
        /// 创建时间 
        /// </summary>
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

    }
}
