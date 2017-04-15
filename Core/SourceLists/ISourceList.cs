using System.Collections.Generic;
using Core.Models;

namespace Core.SourceLists
{
    public interface ISourceList
    {
        IEnumerable<Source> Get();
    }
}