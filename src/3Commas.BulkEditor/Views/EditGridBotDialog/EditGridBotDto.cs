namespace _3Commas.BulkEditor.Views.EditGridBotDialog
{
    public class EditGridBotDto
    {
        public bool? IsEnabled { get; set; }
        public decimal? QuantityPerGrid { get; set; }
        public decimal? UpperLimitPrice { get; set; }
        public decimal? LowerLimitPrice { get; set; }
        public int? GridsQuantity { get; set; }
    }
}
