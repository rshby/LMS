using System;

namespace LMS.ViewModels
{
    public class TakenClassVM
    {
        public int TakenClass_Id { get; set; }
        public string Email { get; set; }
        public int TakenClass_ProgressChapter { get; set; }
        public bool TakenClass_IsDone { get; set; }
        public bool TakenCLass_IsPaid { get; set; }
        public string TakenClass_OrderId { get; set; }
        public DateTime TakenClass_Expired { get; set; }
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }
        public string Class_Desc { get; set; }
        public double Class_Rating { get; set; }
        public int Class_TotalChapter { get; set; }
        public string Class_Level { get; set; }
        public string Class_Category { get; set; }
        public int Class_Price { get; set; }
    }
}
