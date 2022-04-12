namespace LMS.ViewModels
{
    public class DaftarPembayaranVM
    {
        public string User_Email { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_FullName { get; set; }
        public string User_Gender { get; set; }
        public string user_Phone { get; set; }
        public int TakenCLass_Id { get; set; }
        public int TakenClass_ProgressChapter { get; set; }
        public bool TakenClass_IsDone{ get; set; }
        public string TakenClass_OrderId { get; set; }
        public string TakenClass_Expired { get; set; }
        public bool TakenClass_IsPaid { get; set; }
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
