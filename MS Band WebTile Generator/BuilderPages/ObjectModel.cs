using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Band_WebTile_Generator.PostBuildPages
{
    internal class ObjectModel
    {
        public int ManifestVersion { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public string VersionString { get; set; }
        public string Author { get; set; }
        public string Organization { get; set; }
        public string ContactEmail { get; set; }
        public Dictionary<int, string> TileIcon { get; set; }
        public Dictionary<int, string> BadgeIcon { get; set; }
        public List<string>? Icons { get; set; }
        public int RefreshIntervalMinutes { get; set; }
        public List<string> Resources { get; set; }
        public List<string> Pages { get; set; }
    }
}