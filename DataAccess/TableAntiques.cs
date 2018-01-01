using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    [Table("T_Antiques")]
    public class TableAntiques
    {
        public TableAntiques()
        {
            CreateTime = DateTime.Now;
            IsEnable = true;
            Remark = "";
            MinClassId = "";
            VoiceUrl = "";
        }

        [Column("Id")]
        [Description("")]
        public string Id
        {
            get;
            set;
        }

        [Column("MaxClassId")]
        [Description("")]
        public string MaxClassId
        {
            get;
            set;
        }

        [Column("MinClassId")]
        [Description("")]
        public string MinClassId
        {
            get;
            set;
        }

        [Column("Name")]
        [Description("")]
        public string Name
        {
            get;
            set;
        }

        [Column("AgeInfo")]
        [Description("")]
        public string AgeInfo
        {
            get;
            set;
        }

        [Column("FeatureInfo")]
        [Description("")]
        public string FeatureInfo
        {
            get;
            set;
        }

        [Column("UnearthedInfo")]
        [Description("")]
        public string UnearthedInfo
        {
            get;
            set;
        }

        [Column("BookInfo")]
        [Description("")]
        public string BookInfo
        {
            get;
            set;
        }

        [Column("Description")]
        [Description("")]
        public string Description
        {
            get;
            set;
        }

        [Column("VoiceUrl")]
        [Description("")]
        public string VoiceUrl
        {
            get;
            set;
        }

        [Column("IsEnable")]
        [Description("")]
        public bool IsEnable
        {
            get;
            set;
        }

        [Column("CreateTime")]
        [Description("")]
        public DateTime CreateTime
        {
            get;
            set;
        }

        [Column("Remark")]
        [Description("")]
        public string Remark
        {
            get;
            set;
        }
    }
}
