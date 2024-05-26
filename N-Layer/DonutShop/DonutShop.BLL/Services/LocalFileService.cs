using DonutShop.BLL.Contracts;
using Microsoft.Extensions.Hosting;

namespace DonutShop.BLL.Services;

public class LocalFileService : IFileService
{
    private readonly IHostEnvironment _hostEnvironment;

    public LocalFileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public Task CreateAsync(string path, byte[] bytes, CancellationToken cancellationToken)
    {
        var fullPath = GetPath(path);
        var directoryPath = Path.GetDirectoryName(fullPath);
        
        Directory.CreateDirectory(directoryPath);
        
        return File.WriteAllBytesAsync(GetPath(path), bytes, cancellationToken);
    }
    
    public Task<byte[]> GetAsync(string path, CancellationToken cancellationToken) => 
        File.ReadAllBytesAsync(GetPath(path), cancellationToken);
    
    public ValueTask<Stream> OpenReadAsync(string path, CancellationToken cancellationToken) => 
        ValueTask.FromResult((Stream)File.OpenRead(GetPath(path)));
    
    private string GetPath(string path) =>  Path.Join(_hostEnvironment.ContentRootPath, "Files", path);
}