using System;

namespace NotificationNamespace
{
    internal class Notification
    {

        private static uint _id = default;
        public uint ID { get; init; } = _id++;

        public string Text { get; set; }
        public string FromUser { get; set; }

        public DateTime Datetime { get; init; } = DateTime.Now;

        public Notification(string text, string fromUser)
        {
            Text = text;
            FromUser = fromUser;
        }

        public override string ToString()
        {
            return String.Format("Date Time: {0}\nFrom User: {1}\nText: {2}",Datetime, FromUser, Text);
        }
    }
}
