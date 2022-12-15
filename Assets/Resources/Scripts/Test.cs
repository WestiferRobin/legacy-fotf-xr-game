using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// This will be the model 
public class MeshAsset
{
    public MeshAsset()
    {
    }
}

public class AsciiMesh : MeshAsset
{
    public char token;

    public AsciiMesh(char token)
    {
        this.token = token;
    }
}

public class UnityMesh : MeshAsset
{
    public GameObject gameObject { get; set; }

    public UnityMesh(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
}

