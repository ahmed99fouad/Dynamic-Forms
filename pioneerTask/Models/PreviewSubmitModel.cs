namespace pioneerTask.Models
{
    public class PreviewSubmitModel
    {
        public List<int> FormControlId { get; set; }
        public List<string?> FormControlValue { get; set; }
        public List<IFormFile?> FormControlFileValue { get; set; }
    }
}
