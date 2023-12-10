namespace MusicAPI.DTO
{
    // MusicDto.cs
    public class MusicDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string S3BucketKey { get; set; } // Assume this is the key for the track file in S3
                                                // Add other properties as needed
    }
}