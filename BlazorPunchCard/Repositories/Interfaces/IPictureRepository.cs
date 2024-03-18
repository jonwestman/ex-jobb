using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces.GenericInterface;

namespace BlazorPunchCard.Repositories.Interfaces
{
    public interface IPictureRepository : IGenericRepository<Picture, int>
    {
        Task<string> UploadPictureFileAsync(string fileName, string contentType, Stream fileStream);
        Task<bool> DeletePictureFileAsync(string fileName);
        Task<List<Picture?>> GetUserPictureAsync(string userId);
        Task<Picture?> GetByPictureId(int pictureId);
        Task<List<Picture>> GetByIds(int pictureId, string userId);
	}
}
