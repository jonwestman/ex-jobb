using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;
using Shared.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlazorPunchCard.Repositories
{
	public class PictureRepository : IPictureRepository
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger _logger;
		private readonly ApplicationDbContext _dbContext;
		string blobStorageconnection = string.Empty;
		private string blobContainerName = "blobpunchcard";

		public PictureRepository(IConfiguration configuration, ILogger<PictureRepository> logger, ApplicationDbContext dbContext)
		{
			_configuration = configuration;
			_logger = logger;
			_dbContext = dbContext;
			blobStorageconnection = _configuration.GetConnectionString("blobStorage");
		}

		public async Task<Picture?> GetById(string id) => throw new NotImplementedException();
		public Task Add(Picture entity) => throw new NotImplementedException();
		public Task Delete(Picture entity) => throw new NotImplementedException();
		public Task<IEnumerable<Picture>> GetAll() => throw new NotImplementedException();
		public Task<Picture?> GetById(int id) => throw new NotImplementedException();

		public async Task SaveAsync() 
		{
			await _dbContext.SaveChangesAsync();
		}

		public Task Update(Picture entity) => throw new NotImplementedException();

		public async Task<Picture?> GetByPictureId(int pictureId)
		{
			var picture = _dbContext.Pictures.FirstOrDefaultAsync(p => p.PictureId == pictureId);
			return await picture;
		}

		public async Task<string> UploadPictureFileAsync(string fileName, string contentType, Stream fileStream)
		{
			try
			{
				var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
				var createResponse = await container.CreateIfNotExistsAsync();
				if (createResponse != null && createResponse.GetRawResponse().Status == 201)
					await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
				var blob = container.GetBlobClient(fileName);
				await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
				await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
				var urlString = blob.Uri.ToString();
				return urlString;
			}
			catch (Exception ex)
			{
				_logger?.LogError(ex.ToString());
				throw;
			}
		}
		public async Task<bool> DeletePictureFileAsync(string fileName)
		{
			try
			{
				var container = new BlobContainerClient(blobStorageconnection, blobContainerName);
				var createResponse = await container.CreateIfNotExistsAsync();
				if (createResponse != null && createResponse.GetRawResponse().Status == 201)
					await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
				var blob = container.GetBlobClient(fileName);
				await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
				return true;
			}
			catch (Exception ex)
			{
				_logger?.LogError(ex.ToString());
				throw;
			}
		}

		public async Task<List<Picture?>> GetUserPictureAsync(string userId)
		{
			var picture = await _dbContext.Pictures
				.Where(u => u.FK_ApplicationUserId == userId)
				.Include(u => u.ApplicationUsers)
				.ToListAsync();

			return picture;
		}

		public async Task<List<Picture>> GetByIds(int pictureId, string userId)
		{
			var pictures = await _dbContext.Pictures
				.Where(p => p.PictureId == pictureId && p.FK_ApplicationUserId == userId)
				.ToListAsync();

			return pictures;
		}

		Task<List<Picture>> IGenericRepository<Picture, int>.GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task DeleteByIdAsync(int id)
		{
			var picture = await GetByPictureId(id);

			if (picture != null)
			{
				 _dbContext.Pictures.Remove(picture);
				await SaveAsync();
			}
		}
	}
}
