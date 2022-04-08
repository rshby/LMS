namespace LMS.ViewModels
{
    public class CertificateVM
    {
        public int Certificate_Id { get; set; }
        public string Certificate_Code { get; set; }
        public int TakenClass_Id { get; set; }
        public string User_Email { get; set; }
        public string User_FullName { get; set; }
        public string User_Gender { get; set; }
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }
        public string Class_Desc { get; set; }
    }
}
