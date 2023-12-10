using Amazon.DynamoDBv2.DataModel;

namespace MusicAPI
{
    // MusicEntity.cs
    [DynamoDBTable("Music")]
    public class MusicEntity
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Artist { get; set; }

        [DynamoDBProperty]
        public string S3BucketKey { get; set; }

        // Add other DynamoDB properties as needed
    }
}