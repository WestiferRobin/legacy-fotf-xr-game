using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color InitColor;
    public float movementSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        this.InitColor = GetComponent<MeshRenderer>().material.color;
    }

    void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = InitColor;
    }

    private void OnMouseDown()
    {
        UpdatePlayer();
        UpdateCamera();
    }

    private void UpdatePlayer()
    {
        var newPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        var body = new Vector3(newPosition.x, 0f, newPosition.z) + new Vector3(0f, transform.localScale.y - 0.5f, 0.0f);

        var selectedObj = GameObject.FindGameObjectWithTag("Selected");
        if (selectedObj != null)
        {
            selectedObj.transform.position = body;
        }
    }

    private void UpdateCamera()
    {
        var cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        //cameraObject.transform.position = transform.position + new Vector3(0, 10, -15);
        var angle = cameraObject.transform.eulerAngles.y - 360f;
        cameraObject.transform.position = transform.position + new Vector3(0, 10, -15);
        cameraObject.transform.eulerAngles = new Vector3(20f, 0, 0);
        cameraObject.transform.RotateAround(transform.position, Vector3.up, angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
