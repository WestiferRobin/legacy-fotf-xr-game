using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private TileBoard tileBoard;
    private Material Land;
    private Material Water;

    public int ChunkSize = 3;
    public int MaxChunkElevation = 5;
    public int Height = 1;
    public int Width = 1;
    [Range(0f, 100f)] public float HillFrequency;
    [Range(0f, 100f)] public float WallFrequency;
    [Range(0f, 100f)] public float LiquidFrequency;

    public void InitTileBoard()
    {
        var boardBiome = new Biome(
            "Default",
            ChunkSize,
            MaxChunkElevation,
            HillFrequency,
            WallFrequency,
            LiquidFrequency
        );

        this.tileBoard = new TileBoard(boardBiome, this.Height, this.Width);
    }

    public void DrawBoard()
    {
        var board = this.tileBoard.GetBoard();
        int x = 0;
        int z = 0;
        foreach (var key in board.Keys)
        {
            var row = board[key];
            var rowGameObject = new GameObject($"Row {key}");
            foreach (var item in row)
            {
                if (item == 0)
                {
                    var asdf = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    asdf.name = "Water Tile";
                    asdf.tag = "Tile";
                    asdf.AddComponent<Rigidbody>();
                    asdf.GetComponent<Rigidbody>().useGravity = false;
                    asdf.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    asdf.transform.position = new Vector3(x, -0.25f, z);
                    asdf.transform.localScale = new Vector3(5, 0.5f, 5);
                    asdf.GetComponent<MeshRenderer>().material = Water;
                    asdf.transform.parent = rowGameObject.transform;
                }
                else
                {
                    var y = item;
                    var fdsa = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    fdsa.name = "Land Tile";
                    fdsa.tag = "Tile";
                    fdsa.AddComponent<Rigidbody>();
                    fdsa.GetComponent<Rigidbody>().useGravity = false;
                    fdsa.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    var yp = (float)((0.5 * y) - 0.5);
                    fdsa.transform.position = new Vector3(x, yp, z);
                    fdsa.transform.localScale = new Vector3(5, y, 5);
                    fdsa.GetComponent<MeshRenderer>().material = Land;
                    fdsa.AddComponent(typeof(Tile));
                    fdsa.transform.parent = rowGameObject.transform;
                }
                x += 5;
            }
            rowGameObject.transform.parent = transform;
            z += 5;
            x = 0;
        }
    }

    public void Reset()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        InitTileBoard();
        DrawBoard();
    }

    // Start is called before the first frame update
    void Awake()
    {
        Land = GetComponent<Renderer>().materials[0];
        Water = GetComponent<Renderer>().materials[1];
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
