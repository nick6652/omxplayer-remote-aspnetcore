using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Mappers;
using Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace Core.SourceLists
{
    public class RecentSourceList : ISourceList
    {
        private const string RecentPath = ".recent";
        private readonly ISourceFactory _sourceFactory;

        public RecentSourceList(IOptions<FileSourceOptions> options, UrlSourceFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
            if (!File.Exists(RecentPath))
            {
                File.Create(RecentPath)
                    .Close();
            }
        }

        public IEnumerable<Source> Get()
        {
            return LoadRecentSources()
                .OrderByDescending(x => x.Date)
                .Select(x => _sourceFactory.CreateSource(x.Url));
        }

        public void Add(string path)
        {
            var sources = LoadRecentSources();
            var source = sources.FirstOrDefault(x => x.Url.Equals(path, StringComparison.OrdinalIgnoreCase));
            if (source == null)
            {
                source = new RecentSource { Url = path };
                sources.Add(source);
            }

            source.Date = DateTime.Now;
            File.WriteAllText(RecentPath, JsonConvert.SerializeObject(sources, Formatting.Indented));
        }

        private static ICollection<RecentSource> LoadRecentSources()
        {
            return JsonConvert.DeserializeObject<List<RecentSource>>(File.ReadAllText(RecentPath)) ?? 
                new List<RecentSource>();
        }
    }

    class RecentSource
    {
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
