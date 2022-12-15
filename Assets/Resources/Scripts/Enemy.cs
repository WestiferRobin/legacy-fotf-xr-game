using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        //var playerObj = GameObject.FindGameObjectWithTag("Selected");
        //var asdf = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //asdf.name = "Fire";
        //asdf.tag = "Fire";
        //asdf.AddComponent<Rigidbody>();
        //asdf.GetComponent<Rigidbody>().useGravity = false;
        //Physics.IgnoreCollision(playerObj.GetComponent<Collider>(), asdf.GetComponent<Collider>());
        //asdf.transform.position = playerObj.transform.position + new Vector3(1, 5, 0);
        //asdf.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //playerObj.transform.LookAt(transform);
        //asdf.GetComponent<Rigidbody>().AddForce((transform.position - asdf.transform.position) * 0.5f);
        ////Physics.IgnoreCollision(GetComponent<Collider>(), asdf.GetComponent<Collider>());
        ////asdf.GetComponent<Rigidbody>().velocity = transform.TransformDirection(transform.position);
        //asdf.AddComponent(typeof(DebugFire));


        // FIGURE OUT HOW TO FIRE SHIT CORRECTLY!!!!!!
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
