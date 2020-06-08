using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace PhoneStore.Infra.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string _connectionString;
        public BlobStorageService(string conn)
        {
            _connectionString = conn;
        }

        public async Task<byte[]> Get(string name)
        {
            var cloudBlobClient = GetClient();
            var cloudBlobContainer = cloudBlobClient.GetContainerReference("store");
            var blockBlob = cloudBlobContainer.GetBlockBlobReference(name);
            blockBlob.FetchAttributes();
            byte[] byteArray = new byte[blockBlob.Properties.Length];
            await blockBlob.DownloadToByteArrayAsync(byteArray, 0);

            return byteArray;
        }

        public async Task<string> Save(string fileBase64)
        {
            var cloudBlobClient = GetClient();

            var cloudBlobContainer = cloudBlobClient.GetContainerReference("store");

            var name = $"{Guid.NewGuid()}";
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(name);       
            var file = Convert.FromBase64String(fileBase64);
            await cloudBlockBlob.UploadFromByteArrayAsync(file, 0, file.Length);

            return name;
        }

        private CloudBlobClient GetClient()
        {
            CloudStorageAccount storageAccount;

            if (CloudStorageAccount.TryParse(_connectionString, out storageAccount))
            {

            }

            return storageAccount.CreateCloudBlobClient();
        }
    }
}
