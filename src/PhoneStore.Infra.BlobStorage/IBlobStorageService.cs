using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Infra.BlobStorage
{
    public interface IBlobStorageService
    {
        Task<string> Save(string fileBase64);
        Task<byte[]> Get(string name);
    }
}
