namespace NetCore.Application.ViewModels.System
{
    public class ConfigViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Hotline { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string EmailReceive { get; set; }
        public string Slogan { get; set; }
        public string ImageLogo { get; set; }
        public string ImageFavicon { get; set; }
        public string Content { get; set; }
        public string UserMail { get; set; }
        public string PassMail { get; set; }
        public string Analytics { get; set; }
        public string WebMasterTool { get; set; }
        public string AppFacebook { get; set; }
        public string CodeChat { get; set; }
        public string FanpageFacebook { get; set; }
        public string FanpageGoogle { get; set; }
        public string FanpageYoutube { get; set; }
        public string GeoMeta { get; set; }
        public string Color { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string TimeOut { get; set; }
        public bool Coppy { get; set; }
        public bool Status { get; set; }

        public string TitleMeta { set; get; }
        public string KeywordMeta { set; get; }
        public string DescriptionMeta
        {
            set; get;
        }
    }
}