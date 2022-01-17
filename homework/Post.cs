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
            return String.Format("ID: {0}\nLike Count: {1}\nView Count: {2}\nContent: {3}", ID, LikeCount, ViewCount, Content);
        }
    }
}
