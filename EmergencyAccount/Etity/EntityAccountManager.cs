using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAccount.Etity
{
    public class EntityAccountManager
    {
        public int RoleId { get; set; }
        public int DeptId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserSalt { get; set; }
        public string RealName { get; set; }
        public string Tel { get; set; }
        public int IsLock { get; set; }
        public int Level { get; set; }
        public DateTime AddTime { get; set; }
    }
}
