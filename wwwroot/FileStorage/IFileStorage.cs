using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwroot.FileStorage
{
    public interface IFileStorage
    {
        //Task<bool> Save(Guid id, FileStream stream);
        Task<Result> Save(Guid id, FileStream stream);
        //Task<FileStream> Get(Guid id);
        Task<Result<FileStream>> Get(Guid id);

    }
}
