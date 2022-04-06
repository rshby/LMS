namespace LMS.ViewModels
{
    public class TakenClassVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ProgressChapter { get; set; }
        public int TotalChapter { get; set; }
        public bool IsDone { get; set; }
        public int Class_Id { get; set; }
        public string ClassName { get; set; }
        public string Desc { get; set; }
        public string Level { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
    }
}
