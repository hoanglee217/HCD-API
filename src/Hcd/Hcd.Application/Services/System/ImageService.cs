using Hcd.Common.Models;
using Hcd.Data.Instances;
using Hcd.Common.Exceptions;
using Hcd.Common.Requests.System.Images;
using Hcd.Application.Managers.System;
using Hcd.Data.Entities.System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Hcd.Common;
using System.Security.Cryptography;
using System.Text;

namespace Hcd.Application.Services.System;

public class ImageService(IServiceProvider serviceProvider, IHostEnvironment environment) : ApplicationService(serviceProvider)
{
    private ImageManager ImageManager => GetService<ImageManager>();

    private readonly string _uploadPath = Path.Combine(environment.ContentRootPath, "wwwroot", "uploads", DateTime.UtcNow.Year.ToString(), DateTime.UtcNow.Month.ToString());
    public async Task<GetAllImagesResponse> GetAllImages(GetAllImagesRequest request)
    {
        var images = ImageManager.GetAll();

        var paginationResponse = await PaginationResponse<Image>.Create(
            images,
            request
        );

        return Mapper.Map<GetAllImagesResponse>(paginationResponse);
    }

    public async Task<GetDetailImageResponse> GetDetailImage(GetDetailImageRequest request)
    {
        var image = await ImageManager.FindAsync(request.Id);

        if (image == null)
        {
            throw new NotFoundException($"Image with ID {request.Id} not found!");
        }

        return Mapper.Map<GetDetailImageResponse>(image);
    }

    public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
    {
        var image = await ImageManager.FirstOrDefaultAsync(o => o.Id == request.Id);

        if (image == null)
        {
            throw new NotFoundException($"Image with ID {request.Id} not found!");
        }

        // TODO: Update image properties

        var updatedImage = ImageManager.Update(image);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<UpdateImageResponse>(updatedImage);
    }

    public async Task DeleteImage(DeleteImageRequest request)
    {
        ImageManager.Delete(request.Id);
        await UnitOfWork.SaveChangesAsync();
    }

    /// <summary>
    /// Lưu file ảnh vào thư mục gốc (wwwroot/uploads) và database
    /// </summary>
    public async Task<UploadImageResponse> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new BadHttpRequestException("Invalid file upload request.");
        }
        if (!Directory.Exists(_uploadPath))
        {
            Directory.CreateDirectory(_uploadPath);
        }

        string originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
        string extension = Path.GetExtension(file.FileName);
        string slug = SlugGenerator.ToSlug(originalFileName);

        // Mã hóa tên file dựa trên GUID và slug
        string guid = Guid.NewGuid().ToString();
        string inputForHash = $"{guid}-{slug}";
        string hashedFileName = GenerateHashedFileName(inputForHash, EnvGlobal.ApiKey);

        // Thêm số thứ tự nếu trùng tên
        string baseFileName = hashedFileName;
        string fileName = $"{baseFileName}{extension}";
        string filePath = Path.Combine(_uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var image = new Image
        {
            Url = $"{EnvGlobal.ApiBaseUrl}/uploads/{DateTime.UtcNow.Year.ToString()}/{DateTime.UtcNow.Month.ToString()}/{fileName}",
            FileName = fileName,
            Size = file.Length,
            Format = extension.TrimStart('.'),
            Title = originalFileName
        };

        await ImageManager.AddAsync(image);
        await UnitOfWork.SaveChangesAsync();

        return new UploadImageResponse { Url = image.Url, FileName = image.FileName };
    }

    // Hàm mã hóa tên file
    private string GenerateHashedFileName(string input, string secretKey)
    {
        // Tạo một HMAC với secret key
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
        {
            // Tính toán hash
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Chuyển đổi hash thành chuỗi base64 URL-safe
            string base64Hash = Convert.ToBase64String(hashBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");

            // Lấy một phần của hash (ví dụ: 16 ký tự đầu) để tên file không quá dài
            string shortHash = base64Hash.Substring(0, Math.Min(16, base64Hash.Length));

            return shortHash;
        }
    }
}