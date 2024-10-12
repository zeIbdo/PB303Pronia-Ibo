namespace PB303Pronia.ViewModels.SliderViewModels
{
    public class SliderUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DiscountTitle { get; set; } = null!;
        public IFormFile? SliderImage { get; set; }
        public string? ImagePath { get; set; }
    }
}
