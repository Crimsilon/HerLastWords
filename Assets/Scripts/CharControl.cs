using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CharControl : MonoBehaviour
{
    Vector3 tempDes;
    public int actorNum = 1;
    public LayerMask unwalkableMask;
    public Vector3 playerPosition;
    private char choice;
    public Vector3 destination;
    public Grid grid;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public TurnController turnControl;
    public bool canAct;

    /*1 disable turns from taking an action
     * 2 on direction click check for an enemy entity if present do an attack
     * 
     * Update the grid to contain the players position.
     * 
     * 
     */
    private void Start()
    {
        grid.NodeFromWorldPoint(transform.position).setOccupied(true);

        canAct = true;

        destination = transform.position;
    }

    void Update()
    {

        isTurn();

        move();
    }


    public void action()
    {


        //Move right increment x in positive
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.rotation.eulerAngles.y == 90)
            {

                Vector3 temp = new Vector3(8, 0, 0);
                //temporary destination used to check if thelocation is occupied
               

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if occupied
                    if (grid.NodeFromWorldPoint(tempDes).getPiece().tag == "Enemy")
                    {
                        attack(tempDes);
                    }
                }
                else
                {
                    // runs if space is unoccupied 

                    destination = transform.position + temp;
                }

            }
            else
            {
                Quaternion temp = new Quaternion(0, 0, 0, 0);
                temp = Quaternion.Euler(0, 90, 0);
                transform.rotation = temp;
                action();
            }
        }

        // left
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (transform.rotation.eulerAngles.y == 270)
            {
                Vector3 temp = new Vector3(-8, 0, 0);
                //temporary destination used to check if thelocation is occupied
                

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                print(grid.NodeFromWorldPoint(tempDes).occupied());

                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if occupied
                    if (grid.NodeFromWorldPoint(tempDes).getPiece().tag == "Enemy")
                    {
                        attack(tempDes);
                    }
                }
                else
                {
                    // runs if space is unoccupied 
                    
                    destination = transform.position + temp;
                }

            }
            else
            {
                Quaternion temp = new Quaternion(0, 270, 0, 0);
                temp = Quaternion.Euler(0, 270, 0);
                transform.rotation = temp;
                action();
            }
        }

        // Move Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                Vector3 temp = new Vector3(0, 0, 8);

              

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if unoccupied
                    if (grid.NodeFromWorldPoint(tempDes).getPiece().tag == "Enemy")
                    {
                        print("attack");
                        attack(tempDes);
                    }
                }
                else
                {
                    // runs if space is unoccupied, movement 
                    destination = transform.position + temp;
                }

            }
            else
            {
                Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
                newRotation = Quaternion.Euler(0, 0, 0); // this add a -90 degrees Y rotation
                transform.rotation = newRotation;
                action();
            }

        }


        //Move Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (transform.rotation.eulerAngles.y == 180)
            {
                Vector3 temp = new Vector3(0, 0, -8);
                //temporary destination used to check if thelocation is occupied
                

                tempDes = transform.position + temp;

                
                    //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if occupied
                    if (grid.NodeFromWorldPoint(tempDes).getPiece().tag == "Enemy")
                    {
                        attack(tempDes);
                    }
                }
                else
                {
                    // runs if space is unoccupied 

                    destination = transform.position + temp;
                }

            }
            else
            {

                Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
                newRotation = Quaternion.Euler(0, 180, 0); // this add a 90 degrees Y rotation
                transform.rotation = newRotation;
                action();
            }
        }
        canAct = false;

        grid.NodeFromWorldPoint(transform.position).setOccupied(true);

        grid.NodeFromWorldPoint(transform.position).setPiece(null);

        grid.NodeFromWorldPoint(destination).setOccupied(false);

        grid.NodeFromWorldPoint(destination).setPiece(gameObject);

        StartCoroutine("updateAct");
    }



    public void isTurn()
    {
        if (actorNum == TurnController.getCurActor())
        {
            if (Input.anyKeyDown && transform.position == destination && canAct)
            {

                action();

                
                TurnController.round();
                
            }

        }

    }
    public void attack(Vector3 location)
    {
        print("we atk");
        grid.NodeFromWorldPoint(location).getPiece().GetComponent<characterStats>().TakeDamage(gameObject.GetComponent<characterStats>().damage.GetValue());
    }

    public void move()
    {
        if (transform.position != destination)
        {

            
            transform.position = Vector3.MoveTowards(transform.position, destination, smoothTime * Time.deltaTime);
        }
    }

    public void actUpdate()
    {
        print("this line runs");
        canAct = true;
       
    }


    //controls the speed at which player can input commands

    public IEnumerator updateAct()
    {
        yield return new WaitForSeconds(.3f);

        canAct = true;
    }

    
}


