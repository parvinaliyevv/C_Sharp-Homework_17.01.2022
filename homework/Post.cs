using System;

namespace PostNamespace
{
    internal class Post
    {
        private static uint _id = default;
        public uint ID { get; init; } = _id++;

        public string Content { get; set; }
        public ushort LikeCount { get; set; } = default;
        public ushort ViewCount { get; set; } = default;

        public DateTime CreationeDateTime { get; init; } = DateTime.Now;

        public Post(string content) => Content = content;

        public override string ToString()
        {
            return String.Format("Creation Date Time: {0}\nID: {1}\nLike Count: {2}\nView Count: {3}\nContent: {4}", CreationeDateTime, ID, LikeCount, ViewCount, Content);
        }
    }
}
