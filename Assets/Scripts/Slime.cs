using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    private Grid grid;
    //the cur location is the location that the slime is currently taking up this value is set after the value for a new location is chosen but before the movement has begun
    public Vector3 curLocation;
    public Vector3 prevLocation;
    public Vector3 destination;
    public int smoothTime;
    private GameObject player;
    public bool checkEnd;
    private List<Node> neighbors;

    /*Current objectives
     * 1 notice the world around them not walk through walls
     * update the grid with their position before moving
     * 
     * 2 check the four cardinal directions for the player if present perfrom an "attack"
     * 
     * 
     * 
     * 
     */

    void Start()
    {
        checkEnd = false;
        destination = transform.position;
        curLocation = transform.position;
        prevLocation = transform.position;
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        grid.NodeFromWorldPoint(transform.position).setOccupied(true);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {

        move();

        if (transform.position==destination && checkEnd == true)
        {
            player.GetComponent<CharControl>().canAct = true;
            EventManager.LastAction();
            checkEnd = false;
        }

  

        

    }
    /*Current to do 
     * 
     * 
     * 
     * 
     * 
     */ 



    public void action()
    {
        neighbors = grid.GetNeighbours(grid.NodeFromWorldPoint(transform.position));
        //generate a random number 0-3 ( 4 choices) to represent the 4 possible directrions
        float act;
        Vector3 temp = new Vector3(0, 0, 0);

        bool notFound = true;
        int confirmAct = 4;

        foreach ( Node element in neighbors)
        {
            if(element.getPiece() != null)
            {
                if(element.getPiece().tag == "Player")
                {
                    confirmAct = 4; 
                    notFound = false;
                }
               
            }

          
        }
        /*
         * Confirm Act Key
         * 0-up
         * 1-down
         * 2-left
         * 3-
         * * 4- do nothing
         */

        //confirm act is the chosen action choice for the slime option 4 is the null option resulting in no movement or action
       

        //check the location of the generated number for an empty space

        //do a little check for the player in a cardinal direction
       // if(grid.NodeFromWorldPoint(transform.position+new Vector3(0,0,-8)).getPiece().tag =="Player")



        //do a little loop to try to find an open spot
        for (int i = 0; i < 20; i++)
        {
            act  = Random.Range(0, 4);

            if (act == 0 && notFound)
            {
                if (!grid.NodeFromWorldPoint(transform.position + new Vector3(0, 0, -8)).occupied())
                {
                    confirmAct = 0;
                    notFound = false;
                }
            }

            if (act == 1 && notFound)
            {
                if (!grid.NodeFromWorldPoint(transform.position + new Vector3(0, 0, 8)).occupied())
                {
                    confirmAct = 1;
                    notFound = false;
                }
            }

            if (act == 2 && notFound)
            {
                if (!grid.NodeFromWorldPoint(transform.position + new Vector3(-8, 0, 0)).occupied())
                {
                    confirmAct = 2;
                    notFound = false;
                }
            }

            if (act == 3 && notFound)
            {
                if (!grid.NodeFromWorldPoint(transform.position + new Vector3(8, 0, 0)).occupied())
                {
                    confirmAct = 3;
                    notFound = false;
                }
            }
        }
        //reset our condition of finding a suitab
        notFound = true;

        //begin executing upon choice here


        if (confirmAct == 0)
        {

            //if ()
            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 180, 0); // this add a 180 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, -8);
            destination = transform.position + temp;
        }
        if (confirmAct == 1)
        {

            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 0, 0); // this add a 0 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, 8);
            destination = transform.position + temp;
        }
        if (confirmAct == 2)
        {

            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 270, 0);
            transform.rotation = newRot;
            temp = new Vector3(-8.0f, 0, 0);
            destination = transform.position + temp;
        }
        if (confirmAct == 3)
        {

            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 0, 0);
            transform.rotation = newRot;
            temp = new Vector3(8.0f, 0, 0);
            destination = transform.position + temp;
        }
        prevLocation = transform.position;
        grid.NodeFromWorldPoint(prevLocation).setPiece(null);
        curLocation = transform.position + temp;
        grid.NodeFromWorldPoint(curLocation).setPiece(gameObject);

       
        updateGrid();
    }

    public void move()
    {
        if (transform.position != destination)
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, smoothTime * Time.deltaTime);
        }
    }

    // is used to signal to the creature that it should check if its movement is done and if so update the player so it can move again
    
    public void theSignal()
    {

        checkEnd = true;
   
    }

    public void updateGrid()
    {
        if (destination != transform.position)
        {
            //for some reason its the oppisite of what it logically should be.
            grid.NodeFromWorldPoint(curLocation).setOccupied(false);

            grid.NodeFromWorldPoint(prevLocation).setOccupied(true);

        }




    }
}
