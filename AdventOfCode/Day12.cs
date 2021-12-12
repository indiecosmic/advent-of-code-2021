using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day12
    {
        public IDictionary<string, Cave> Caves { get; }
        public IList<string[]> Paths { get; } = new List<string[]>();
        private int pathCount = 0;
        public Day12(string[] input = null)
        {
            input ??= Input.ReadAllLines(GetType().Name);
            Caves = new Dictionary<string, Cave>();
            foreach (var line in input)
            {
                var parts = line.Split("-", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var sourceName = parts[0];
                var destName = parts[1];

                Cave source;
                if (Caves.ContainsKey(sourceName))
                    source = Caves[sourceName];
                else
                {
                    source = new Cave(sourceName);
                    Caves.Add(sourceName, source);
                }

                Cave dest;
                if (Caves.ContainsKey(destName))
                    dest = Caves[destName];
                else
                {
                    dest = new Cave(destName);
                    Caves.Add(destName, dest);
                }
                
                if (!source.Neighbours.Contains(dest))
                    source.Neighbours.Add(dest);
                if (!dest.Neighbours.Contains(source))
                    dest.Neighbours.Add(source);
            }

            foreach (var cave in Caves.Values)
                cave.Neighbours = cave.Neighbours.OrderBy(c => c.Name).ToList();
        }

        public int Part1()
        {
            var start = Caves["start"];
            Navigate(start, new List<string>());
            return Paths.Count;
        }

        public int Part2()
        {
            var start = Caves["start"];
            Navigate2(start, new Dictionary<string, int>());
            return pathCount;
        }

        public void Navigate(Cave cave, IList<string> history)
        {
            history.Add(cave.Name);
            if (cave.Name == "end")
            {
                Paths.Add(history.ToArray());
                return;
            }

            foreach (var neighbour in cave.Neighbours)
            {
                if (!neighbour.Big && history.Contains(neighbour.Name))
                    continue;
                Navigate(neighbour, history.ToList());
            }
        }

        public void Navigate2(Cave cave, IDictionary<string, int> history)
        {
            if (!cave.Big)
            {
                if (!history.ContainsKey(cave.Name))
                    history.Add(cave.Name, 0);
                history[cave.Name]++;
            }
            
            if (cave.Name == "end")
            {
                pathCount++;
                return;
            }

            foreach (var neighbour in cave.Neighbours)
            {
                if (!CanVisit(neighbour, history))
                    continue;
                Navigate2(neighbour, history.ToDictionary(e => e.Key, e=> e.Value));
            }
        }

        private bool CanVisit(Cave cave, IDictionary<string, int> history)
        {
            if (cave.Name == "start")
                return false;
            if (cave.Big)
                return true;
            if (!history.ContainsKey(cave.Name))
                return true;
            if (history.Any(h => h.Value == 2))
                return false;
            return true;
        }

        public class Cave
        {
            public string Name { get; }
            public bool Big => Name.All(char.IsUpper);

            public Cave(string name)
            {
                Name = name;
            }

            public IList<Cave> Neighbours { get; set; } = new List<Cave>();
        }
    }
}
