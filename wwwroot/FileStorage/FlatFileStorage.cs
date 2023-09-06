using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwroot.FileStorage
{
    internal class FlatFileStorage : IFileStorage
    {
        public string StorageDirectory  => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\CypherCrescent Ltd\Sepal Enterprise\Uploads\";

        //public Task<FileStream> Get(Guid id)
        //{
        //    throw new NotImplementedException(); 
        //}

        //// in order to copy the stream, u have to await it since its faster 
        //public async  Task<bool> Save(Guid id, FileStream stream)
        //{
        //    var filePath = Path.Combine(StorageDirectory, id.ToString());
        //    try
        //    {
        //        if (!Directory.Exists(StorageDirectory))
        //            Directory.CreateDirectory(StorageDirectory);

        //        using var fileStream = File.Create(filePath);
        //        await stream.CopyToAsync(stream);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        // first implementation with async that didnt work
        public async Task<Result<FileStream>> Get(Guid id)
        {
            FileStream stream = null!;
            try
            {
                await Task.Run(() =>
                {
                    var filePath = Path.Combine(StorageDirectory, id.ToString());
                    stream = File.OpenRead(filePath);
                });

                return Succeeded(stream);
            }
            catch (Exception)
            {
                return Failed<FileStream>("Failed to get file");
            }
        }

        //public FileStream Get(Guid id)
        //{
        //    try
        //    {
        //        var filePath = Path.Combine(StorageDirectory, id.ToString());
        //        var stream = File.OpenRead(filePath);

        //        return stream;
        //    }
        //    catch (Exception)
        //    {
        //        return FileStream("Failed to get file");
        //    }
        //}

        // in order to copy the stream, u have to await it since its faster 
        public async Task<Result> Save(Guid id, FileStream stream)
        {
            var filePath = Path.Combine(StorageDirectory, id.ToString());
            try
            {
                if (!Directory.Exists(StorageDirectory))
                    Directory.CreateDirectory(StorageDirectory);

                using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(stream);
                return Succeeded();
            }
            catch (Exception)
            {
                return Failed("Unable to save file");
            }
        }
    }
}
