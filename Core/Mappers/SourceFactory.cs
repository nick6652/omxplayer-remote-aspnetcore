using System.IO;
using Core.Models;

namespace Core.Mappers
{
    public class SourceFactory
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