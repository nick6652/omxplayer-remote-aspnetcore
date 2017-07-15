using Core.Models;
using System;

namespace Core.Mappers
{
    public class UrlSourceFactory: ISourceFactory
    {
        public Source CreateSource(string path)
        {
            string title;
            try
            {
                title = new Uri(path).GetComponents(UriComponents.Path, UriFormat.Unescaped);
            }
            catch (Exception)
            {
                title = path;
            }

            return new Source
            {
                Path = path,
                Title = title
            };
        }
    }
}