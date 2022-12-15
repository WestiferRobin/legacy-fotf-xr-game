using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TileBoard
{
    public Biome Biome { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<List<Grid>> CurrentBoard { get; set; }

    public TileBoard(Biome biome, int height = 3, int width = 3)
    {
        this.Biome = biome;
        this.Height = height;
        this.Width = width;
        this.CurrentBoard = new List<List<Grid>>();
        for (int index = 0; index < this.Height; index++)
        {
            var row = new List<Grid>();
            for (int subIndex = 0; subIndex < this.Width; subIndex++)
            {
                var item = new Grid(this.Biome);
                row.Add(item);
            }
            this.CurrentBoard.Add(row);
        }
    }

    public Dictionary<int, List<int>> GetBoard()
    {
        int offset = 0;
        var dict = new Dictionary<int, List<int>>();
        for (int height = 0; height < Height; height++)
        {
            for (int width = 0; width < Width; width++)
            {
                var subDict = new Dictionary<int, List<int>>();
                CurrentBoard[height][width].GetGrid(subDict);
                foreach (var key in subDict.Keys)
                {
                    int dicKey = offset + key;
                    if (dict.ContainsKey(dicKey))
                    {
                        foreach (var item in subDict[key])
                        {
                            dict[dicKey].Add(item);
                        }
                    }   
                    else
                    {
                        dict.Add(dicKey, subDict[key]);
                    }
                }
            }
            offset = dict.Keys.Count;
        }
        return dict;
    }
}
