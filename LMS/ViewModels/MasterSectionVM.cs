namespace LMS.ViewModels
{
    public class MasterSectionVM
    {
        public int Section_Id { get; set; }
        public string Section_Name { get; set; }
        public int Section_Chapter { get; set; }
        public string Section_Content { get; set; }
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }
        public string Class_UrlPic { get; set; }
        public string Class_Desc { get; set; }
        public int Class_TotalChapter { get; set; }
        public int Class_Price { get; set; }
        public double Class_Rating { get; set; }
        public string Level_Name { get; set; }
        public string Category_Name { get; set; }
    }
}
