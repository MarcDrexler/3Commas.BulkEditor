using System;

namespace _3Commas.BulkEditor.Misc
{
    [Serializable]
    public class XCommasAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
    }
}