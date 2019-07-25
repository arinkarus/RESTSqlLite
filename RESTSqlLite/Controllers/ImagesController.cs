using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using RESTSqLite.BLL.Interface.Models;
using RESTSqLite.BLL.Interface.Services;
using RESTSqLite.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTSqLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class ImagesController : Controller
    {
        static CloudBlobClient blobClient;
        const string blobContainerName = "images";
        static CloudBlobContainer blobContainer;

        private readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=arinastorageaccount;AccountKey=z1R2zUPEh90ERhTKu/9dg0J5aOFa03oJfwF+TkeoyptTRnJ4Og4rXBuwSy7x4de7mHtGduviTfFj+7TxuR/ADA==;EndpointSuffix=core.windows.net";
        private readonly IFileService fileService;

        public ImagesController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> AddImageToStorage(ImageUploadRequest imageUploadRequest)
        {
            var imageData = Convert.FromBase64String(imageUploadRequest.Content);

            var storageAccount = CloudStorageAccount.Parse
                (this.storageConnectionString);

            blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference(blobContainerName);

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            CloudBlockBlob blob = blobContainer.GetBlockBlobReference("storage/fileName");
            await blob.UploadFromByteArrayAsync(imageData, 0, imageData.Length);

            return File(imageData, "image/jpeg");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = this.fileService.Get();
            return Ok();
        }

    }
}
