using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Unit unit = new Unit();
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionStay(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.tag == "Fire")
        {
            Physics.IgnoreCollision(obj.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
