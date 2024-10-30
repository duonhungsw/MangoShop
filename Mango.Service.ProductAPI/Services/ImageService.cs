using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Mango.Service.ProductAPI.Services;

public interface IImageService
{
	Task<string> UpLoadFile(IFormFile file);
}
public class ImageService : IImageService
{
	private readonly string? _connectionString;
	public ImageService(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("AzureBlobStorage");
	}

	public async Task<string> UpLoadFile(IFormFile file)
	{
		string containerName = "product";
		BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

		BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
		await blobContainerClient.CreateIfNotExistsAsync();

		BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
		var httpHeaders = new BlobHttpHeaders
		{
			ContentType = "image/jpeg" 
		};
		using (var stream = file.OpenReadStream())
		{
			await blobClient.UploadAsync(stream, httpHeaders);
		}

		return blobClient.Uri.ToString();
	}

}
