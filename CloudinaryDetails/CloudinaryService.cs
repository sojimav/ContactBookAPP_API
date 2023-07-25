using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;

namespace ContactBookAPP.CloudinaryDetails
{
	public class CloudinaryService
	{
		private readonly Cloudinary _cloudinary;

		public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings)
		{
			var cloudinaryConfig = new Account(
				cloudinarySettings.Value.CloudName,
				cloudinarySettings.Value.ApiKey,
				cloudinarySettings.Value.ApiSecret
			);

			_cloudinary = new Cloudinary(cloudinaryConfig);
		}

		public string UploadPhoto(byte[] photoData, string publicId)
		{
			var uploadParams = new ImageUploadParams
			{
				PublicId = publicId,
				File = new FileDescription(publicId, new MemoryStream(photoData))
			};

			var uploadResult = _cloudinary.Upload(uploadParams); 

			return uploadResult.SecureUrl.AbsoluteUri;
		}

		public bool DeletePhoto(string publicId)
		{
			var deletionParams = new DeletionParams(publicId);

			var result = _cloudinary.Destroy(deletionParams); 

			return result.Result == "ok";
		}
	}

}
