using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmergencyAccount.Enum
{

    /// <summary>
    /// 文物类别 
    /// </summary>
    public enum EnumAntiquesClassLevel : int
    {
        [Description("主类别")]
        MainLevel = 1,

        [Description("子类")]
        SubLevel = 2
    }
}
