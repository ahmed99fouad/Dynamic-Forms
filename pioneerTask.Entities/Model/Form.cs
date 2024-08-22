using System.ComponentModel;

namespace pioneerTask.Entities.Model
{
    public class Form : BaseEntity
    {
        public string ControlName { get; set; }
        public int ControlType { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public  ICollection<UserInfo> UserInfos { get; set; }
    }
}
