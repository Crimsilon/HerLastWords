using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private int rotation = 0;
    // Use this for initialization
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;
    }
    
       
    void LateUpdate()
    {
        //transform.Translate(transform.position.x, transform.position.y + 1, transform.position.z - 1);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("fuck me up");
            setLeft();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            setBehind();
        }
        transform.position = player.transform.position + offset;

    }

    private void setBehind()
    {
        transform.position = player.transform.position + offset;
        transform.Translate(transform.position.x, transform.position.y + 120, transform.position.z - 70);
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
        newRotation = Quaternion.Euler(55, 0, 0); // this add a 0 degrees Y rotation
        transform.rotation = newRotation;
    }
    private void setInfront()
    {

    }
    private void setLeft()
    {
        transform.position = player.transform.position + offset;
        transform.Translate(transform.position.x, transform.position.y + 120, transform.position.z - 70);
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
        newRotation = Quaternion.Euler(55, 90, 0); // this add a 0 degrees Y rotation
        transform.rotation = newRotation;
    }
    private void setRight()
    {

    }
}
