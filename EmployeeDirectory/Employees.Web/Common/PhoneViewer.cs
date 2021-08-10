namespace Employees.Web.Common
{
    public static class PhoneViewer
    {
        public static string ViewPhone(string p)
        {
            var phoneNumberView = $"+{p.Substring(0, 1)} ({p.Substring(1, 3)}) {p.Substring(4, 3)}-{p.Substring(7, 2)}-{p.Substring(9, 2)}";  
            return phoneNumberView;
        }
    }
}
