namespace DonutShop.BLL.Contracts;

public interface IFileService
{
    Task CreateAsync(string path, byte[] bytes, CancellationToken cancellationToken);

    Task<byte[]> GetAsync(string path, CancellationToken cancellationToken);
    
    ValueTask<Stream> OpenReadAsync(string path, CancellationToken cancellationToken);
}