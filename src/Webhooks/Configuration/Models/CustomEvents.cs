using System.Collections.Generic;

namespace Webhooks.Configuration.Models
{
    public class CustomEvent
    {
        public string SenderName { get; set; }

        public string Event { get; set; }

        public string webhookLink { get; set; }

        public string Response { get; set; }
    }
}

