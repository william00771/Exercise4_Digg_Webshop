namespace Exercise4_Digg_Webshop.Models
{
    public class ImageModule_Image
    {
        public int Id { get; set; }
        public int SectionImageModuleId { get; set; }
        public SectionImageModule SectionImageModule { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
