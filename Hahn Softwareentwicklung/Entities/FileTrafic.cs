namespace Hahn_Softwareentwicklung.Entities
{
    public class FileTrafic
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public string UploadedBy { get; set; }
        public bool isUpload { get; set; }
    }
}
