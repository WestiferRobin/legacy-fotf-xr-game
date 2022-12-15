using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Biome
{
    public string Name { get; }
    public int ChunkSize { get; }
    public int MaxChunkElevation { get; } 
    public float HillFrequency { get; }
    public float WallFrequency { get; }
    public float LiquidFrequency { get; }

    public Biome(string name = "Default",
        int chunkSize = 3,
        int maxChunkElevation = 5,
        float hillFrequency = 100f,
        float wallFrequency = 0f,
        float liquidFrequency = 95f
        )
    {
        this.Name = name;
        this.ChunkSize = chunkSize;
        this.MaxChunkElevation = maxChunkElevation;
        this.HillFrequency = hillFrequency;
        this.WallFrequency = wallFrequency;
        this.LiquidFrequency = liquidFrequency;
    }
}
