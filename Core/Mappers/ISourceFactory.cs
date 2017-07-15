using Core.Models;

namespace Core.Mappers
{
    interface ISourceFactory
    {
        Source CreateSource(string path);
    }
}
