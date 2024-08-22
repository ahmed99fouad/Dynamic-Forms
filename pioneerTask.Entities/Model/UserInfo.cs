using System.ComponentModel.DataAnnotations.Schema;

namespace pioneerTask.Entities.Model
{
    public class UserInfo : BaseEntity
    {
        public string? ControlValue { get; set; }
        [ForeignKey(nameof(FormId))]
        public Form form { get; set; }
        public int FormId { get; set; }
    }
}
