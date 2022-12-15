using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Chunk
{
    public Biome ChunkBiome { get; }
    public bool IsNull { get; set; }

    private List<List<int>> chunkText;
    public List<List<int>> ChunkText
    {
        get
        {
            if (this.IsNull)
                ApplyChunk();
            return chunkText;
        }
    }
    public Chunk(Biome biome, bool isNull = false)
    {
        this.ChunkBiome = biome;
        this.IsNull = isNull;
        ApplyChunk();
    }

    private void ApplyChunk()
    {
        var chunk = new List<List<int>>();
        var row = new List<int>();
        int tile = this.IsNull ? 0 : 1;
        row.Add(tile);
        chunk.Add(row);
        this.chunkText = chunk;

        if (this.IsNull) return;

        ApplyHills();
        ApplyWalls();
    }

    private void ApplyHills()
    {
        for (int index = 0; index < this.chunkText.Count; index++)
        {
            for (int subIndex = 0; subIndex < this.chunkText[index].Count; subIndex++)
            {
                float percent = Random.Range(0.0f, 100.0f);
                if (percent <= this.ChunkBiome.HillFrequency)
                {
                    int offset = Random.Range(0, this.ChunkBiome.MaxChunkElevation);
                    this.chunkText[index][subIndex] += offset;
                }
            }
        }
    }

    private void ApplyWalls()
    {
        for (int index = 0; index < this.chunkText.Count; index++)
        {
            for (int subIndex = 0; subIndex < this.chunkText[index].Count; subIndex++)
            {
                float percent = Random.Range(0.0f, 100.0f);
                if (percent <= this.ChunkBiome.WallFrequency)
                {
                    this.chunkText[index][subIndex] = 8;
                }
            }
        }
    }

    public void GetChunk(int count, Dictionary<int, List<int>> dict)
    {
        foreach (var list in ChunkText)
        {
            var asdf = new List<int>();
            foreach (var item in list)
            {
                asdf.Add(item);
            }

            if (dict.ContainsKey(count))
            {
                foreach (var item in asdf)
                {
                    dict[count].Add(item);
                }
            }
            else
            {
                dict.Add(count, asdf);
            }
            count++;
        }
    }
}