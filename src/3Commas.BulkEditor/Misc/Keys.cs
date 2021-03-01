namespace _3Commas.BulkEditor.Misc
{
    public class Keys
    {
        public string ApiKey3Commas { get; set; }
        public string Secret3Commas { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(ApiKey3Commas) || string.IsNullOrWhiteSpace(Secret3Commas);
        }
    }
}