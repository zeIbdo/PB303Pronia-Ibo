using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace PB303Pronia.Helpers
{
    public class CloudinaryHelper
    {
        private readonly IConfiguration _configuration;

        public CloudinaryHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> ImageCreateAsync(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            string fileName = string.Concat(Guid.NewGuid(), file.FileName.Substring(file.FileName.LastIndexOf('.')));
            var myAccount = new Account
            {
                ApiKey = _configuration["CloudinarySettings:APIKey"],
                ApiSecret = _configuration["CloudinarySettings:APISecret"],
                Cloud = _configuration["CloudinarySettings:CloudName"]
            };

            Cloudinary _cloudinary = new Cloudinary(myAccount);
            _cloudinary.Api.Secure = true;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, stream),
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            string url = uploadResult.SecureUrl.ToString();

            return url;
        }
        public string DeleteImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            var url = GetPublicIdFromUrl(fileName);
            var myAccount = new Account
            {
                ApiKey = _configuration["CloudinarySettings:APIKey"],
                ApiSecret = _configuration["CloudinarySettings:APISecret"],
                Cloud = _configuration["CloudinarySettings:CloudName"]
            };

            Cloudinary _cloudinary = new Cloudinary(myAccount);
            _cloudinary.Api.Secure = true;
            var deletionParams = new DeletionParams(url)
            {
                ResourceType = ResourceType.Image
            };

            DeletionResult deletionResult = _cloudinary.Destroy(deletionParams);
            if (deletionResult.Result == "ok")
            {
                return "Audio file deleted successfully.";
            }
            else
            {
                return $"Failed to delete audio file: {deletionResult.Result}";
            }
        }
        static string GetPublicIdFromUrl(string imageUrl)
        {
            Uri uri = new Uri(imageUrl);

            string[] segments = uri.AbsolutePath.Split('/');

            string fileName = segments[^1];

            string publicId = fileName.Substring(0, fileName.LastIndexOf('.'));

            return publicId;
        }
    }
}
