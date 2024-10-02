namespace PB303Pronia.ViewModels.SliderViewModels
{
    public class SliderUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DiscountTitle { get; set; }
        public IFormFile? SliderImage { get; set; }
        public string? ImagePath { get; set; }
    }
}
