using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParkerPlan.Site.Data
{
    public class FiltersService
    {
        public void Insert(string path, Dictionary<string, bool> filters)
        {
            if (!Directory.Exists("filters"))
            {
                Directory.CreateDirectory("filters");
            }

            Directory.CreateDirectory("filters\\" + path);

            foreach (var (name, value) in filters)
            {
                File.WriteAllText($@"filters\{ path}\{name}", value.ToString());
            }
        }

        public void Update(string path, Dictionary<string, bool> filters)
        {
            foreach (var (name, value) in filters)
            {
                File.WriteAllText($@"filters\{path}\{name}", value.ToString());
            }
        }

        public Dictionary<string, bool> GetAll(string path)
        {
            KeyValuePair<string, bool> Selector(string x)
            {
                return new (x.Remove(0, ("filters\\" + path).Length + 1), bool.Parse(File.ReadAllText(x)));
            }

            var result = new Dictionary<string, bool>(Directory.GetFiles("filters\\" + path).Select(Selector));

            return result;
        }
    }
}