using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private GameObject TilePlace;
    public int row = 0;
    public int col = 0;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //var tile = GameObject.FindGameObjectWithTag("Board").transform.GetChild(col).transform.GetChild(row);
        //transform.position = new Vector3(tile.transform.position.x, tile.transform.localScale.y - 0.5f, tile.transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        var collObj = collision.gameObject;
        if (collObj.tag == "Tile")
        {
            transform.position = new Vector3(collObj.transform.position.x, collObj.transform.localScale.y - 0.5f, collObj.transform.position.z);
            TilePlace = collision.gameObject;
        }
    }

    void OnMouseDown()
    {
        if (tag == "Player")
        {
            var players = GameObject.FindGameObjectsWithTag("Selected");
            foreach (var player in players)
            {
                player.tag = "Player";
            }
            tag = "Selected";
            var cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
            cameraObject.transform.position = TilePlace.transform.position + new Vector3(0, 10, -15);
            cameraObject.transform.eulerAngles = new Vector3(20f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
