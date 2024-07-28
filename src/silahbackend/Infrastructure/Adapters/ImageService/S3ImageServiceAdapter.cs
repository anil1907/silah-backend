using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Application.Services.ImageService;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Infrastructure.Adapters.ImageService
{
    public class S3ImageServiceAdapter : ImageServiceBase
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3ImageServiceAdapter(IConfiguration configuration, IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
            _bucketName = configuration.GetValue<string>("S3BucketName");
        }

        public override async Task<string> UploadAsync(IFormFile formFile)
        {
            await FileMustBeInImageFormat(formFile);

            var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
            var putRequest = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = formFile.OpenReadStream(),
                ContentType = formFile.ContentType
            };

            await _s3Client.PutObjectAsync(putRequest);
            return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
        }

        public override async Task DeleteAsync(string imageUrl)
        {
            var fileKey = GetFileKey(imageUrl);
            var deleteRequest = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileKey
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }

        private string GetFileKey(string imageUrl)
        {
            var uri = new Uri(imageUrl);
            return uri.AbsolutePath.TrimStart('/');
        }

    }
}
