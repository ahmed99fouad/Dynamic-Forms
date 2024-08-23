namespace pioneerTask.Models
{
    public class PreviewFormModel
    {
        public int FormControlId { get; set; }
        public string FormControlName { get; set; }
        public bool FormControlRequired { get; set; }
        public bool FormControlIsActive { get; set; }
        public int FormControlType { get; set; }
        public string? FormControlValue { get; set; }

    }
}
