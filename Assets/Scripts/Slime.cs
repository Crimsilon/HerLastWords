using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public int actorNum = 1;
    private Grid grid;
    public Vector3 curLocation;
    public Vector3 prevLocation;
    public Vector3 destination;
    public int smoothTime;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        destination = transform.position;
        curLocation = transform.position;
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        grid.NodeFromWorldPoint(transform.position).setOccupied(true);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        move();


    }
    /*Current to do 
     * 1.Before movement check if that spot is unoccupied if so confirm move else redraw for a move
     * 2. Update the pervious location to non oncupied and current location to ocupied upon completion of the move
     * 
     * 
     * 
     * 
     */ 



    public void action()
    {
        float act = Random.Range(0, 4);
        Vector3 temp = new Vector3(0, 0, 0);
        Debug.Log(act);


        if (act == 0)
        {

            //if ()
            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 180, 0); // this add a 180 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, -8);
            destination = transform.position + temp;
        }
        if (act == 1)
        {

            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 0, 0); // this add a 0 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, 8);
            destination = transform.position + temp;
        }
        if (act == 2)
        {

            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 270, 0);
            transform.rotation = newRot;
            temp = new Vector3(-8.0f, 0, 0);
            destination = transform.position + temp;
        }
        if (act == 3)
        {

            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 0, 0);
            transform.rotation = newRot;
            temp = new Vector3(8.0f, 0, 0);
            destination = transform.position + temp;
        }

        
    }

    public void move()
    {
        if (transform.position != destination)
        {

            print("wub");
            transform.position = Vector3.MoveTowards(transform.position, destination, smoothTime * Time.deltaTime);
        }
    }

    // is used to signal to the player that their action can be performed again, This should be moved to an event manager 
    public void theSignal()
    {
        
            if (transform.position == destination)
            {
               
                    player.GetComponent<CharControl>().actUpdate();
                    
            }
        
        
    }
}
