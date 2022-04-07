namespace LMS.ViewModels
{
    public class AllFeedBackVM
    {
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }
        public string Class_Desc { get; set; }
        public double Class_Rating { get; set; }
        public int TakenClass_Id { get; set; }
        public string TakenClass_Email { get; set; }
        public int FeedBack_Id { get; set; }
        public double FeedBack_Rating { get; set; }
    }
}
