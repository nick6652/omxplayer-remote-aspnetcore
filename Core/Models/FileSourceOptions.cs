using System.Collections.Generic;

namespace Core.Models
{
    public class FileSourceOptions
    {
        public string Path { get; set; }
        public IEnumerable<string> Extensions { get; set; }
    }
}