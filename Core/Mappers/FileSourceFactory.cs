using System.IO;
using Core.Models;

namespace Core.Mappers
{
    public class FileSourceFactory: ISourceFactory
    {
        public Source CreateSource(string path)
        {
            return new Source
            {
                Path = path,
                Title = Path.GetFileNameWithoutExtension(path)
            };
        }
    }
}