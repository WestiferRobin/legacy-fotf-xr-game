using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    [Range(0f, 100f)] public float movementSpeed;
    [Range(0f, 100f)] public float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    //private void TransformSetup()
    //{
    //    var pieceObject = GetPlayerObject();
    //    if (pieceObject != null)
    //    {
    //        transform.position = pieceObject.transform.position;
    //            //+ new Vector3(0, 10, -15);
    //        transform.eulerAngles = new Vector3(20f, 0, 0);
    //    }
    //}

    private GameObject GetPlayerObject()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Selected");
        if (playerObject == null)
        {
            var board = GameObject.FindGameObjectWithTag("Board");
            if (board != null)
            {
                // hacky but works
                foreach (Transform row in board.transform)
                {
                    foreach (Transform tile in row)
                    {
                        return tile.gameObject;
                    }
                }
            }
        }
        return playerObject;
    }

    private void Rotate()
    {
        var playerObject = GetPlayerObject();
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(playerObject.transform.position,
                Vector3.up, Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(playerObject.transform.position,
                Vector3.down, Time.deltaTime * movementSpeed);
        }

        var x = playerObject.transform.position.x
            - transform.position.x;
        var y = playerObject.transform.position.y
            - transform.position.y;
        var z = playerObject.transform.position.z
            - transform.position.z;
        var offset = Time.deltaTime * (zoomSpeed/100) * new Vector3(x, y, z);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += offset;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= offset;
        }
    }

    // TODO: Fix the following: Zoom character, set selected, and rotate character
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            //SceneManager.LoadScene("SampleScene");

            var asdf = Resources.Load("Prefabs/SandBlock") as GameObject;
            Instantiate(asdf, transform.position, transform.rotation);
            var fdsa = Resources.Load("Prefabs/Player") as GameObject;
        }

        // TODO: Fix the cameraobject and instead I need to mess with position and rotation.
        Rotate();
    }
}
