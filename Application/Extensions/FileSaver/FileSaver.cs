using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Application.Extensions.NameGenerator;
using System.IO;
using System.Threading.Tasks;

public class FileSaver
{
    private readonly IHostingEnvironment _webHostEnvironment;

    public FileSaver(IHostingEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null;

        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

        var uniqueFileName = NameGenerator.GenerateUniqCode() + file.FileName;

        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        return uniqueFileName;
    }
}
