using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawnAmmount = 3;
    public GameObject spawnObject;
    public bool reverse;

    // Start is called before the first frame update
    // TODO: REFACTOR!
    void Start()
    {
        int counter = spawnAmmount - 1;
        var board = GameObject.FindGameObjectWithTag("Board");
        if (board != null)
        {
            foreach (Transform row in board.transform)
            {
                if (!row.name.ToUpper().Contains("ROW")) continue;
                foreach (Transform tile in row)
                {
                    if (counter < 0) break;
                    if (tile.name.ToUpper().Contains("LAND"))
                    {
                        var asdf = Instantiate(spawnObject, tile.position, Quaternion.identity);
                        asdf.name = $"{spawnObject.tag} {spawnAmmount - counter}";
                        if (spawnObject.tag == "Player")
                        {
                            asdf.tag = counter > 0 ? "Player" : "Selected";
                            if (asdf.tag == "Selected")
                            {
                                var camera = GameObject.FindGameObjectWithTag("MainCamera");
                                camera.transform.position = tile.position + new Vector3(0, 10, -15);
                                camera.transform.eulerAngles = new Vector3(20f, 0, 0);
                            }
                        }
                        else if (spawnObject.tag == "Enemy")
                        {
                            asdf.tag = spawnObject.tag;
                        }
                        else asdf.tag = spawnObject.tag;
                        asdf.transform.parent = transform;
                        counter--;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
