using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Grid
{
    public static Biome GridBiome { get; set; }
    public List<List<Chunk>> ChunkGrid { get; set; }
    public Grid(Biome biome)
    {
        Grid.GridBiome = biome;
        InitGrid();
    }

    private static List<List<int>> InitOutline()
    {
        var outline = new List<List<int>>();
        foreach (int _ in Enumerable.Range(1, Grid.GridBiome.ChunkSize))
        {
            var row = new List<int>();
            foreach (int __ in Enumerable.Range(1, Grid.GridBiome.ChunkSize))
            {
                row.Add(1);
            }
            outline.Add(row);
        }
        return outline;
    }

    private static List<List<int>> GetOutline(float liquidPercent)
    {
        var outline = InitOutline();
        for (int index = 0; index < outline.Count; index++)
        {
            for (int subIndex = 0; subIndex < outline.Count; subIndex++)
            {
                float percent = Random.Range(0.0f, 100.0f);
                if (percent <= liquidPercent)
                {
                    outline[index][subIndex] = 0;
                }
            }
        }
        return outline;
    }

    private void InitGrid()
    {
        var outline = GetOutline(Grid.GridBiome.LiquidFrequency);
        this.ChunkGrid = new List<List<Chunk>>();
        for (int index = 0; index < outline.Count; index++)
        {
            List<Chunk> row = new List<Chunk>();
            for (int subIndex = 0; subIndex < outline[index].Count; subIndex++)
            {
                bool isNull = outline[index][subIndex] <= 0;
                var chunk = new Chunk(GridBiome, isNull);
                row.Add(chunk);
            }
            this.ChunkGrid.Add(row);
        }
    }

    public void GetGrid(Dictionary<int, List<int>> dict)
    {
        int offset = 0;
        foreach (var row in this.ChunkGrid)
        {
            foreach (var chunk in row)
            {
                chunk.GetChunk(offset, dict);
            }
            offset = dict.Keys.Count;
        }
    }
}
