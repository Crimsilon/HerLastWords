using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CharControl : MonoBehaviour
{
    public int actorNum = 1;
    public LayerMask unwalkableMask;
    public Vector3 playerPosition;
    private char choice;
    public Vector3 destination;
    public Grid grid;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
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
                Vector3 tempDes = new Vector3();

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if unoccupied
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

            }
        }

        // left
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (transform.rotation.eulerAngles.y == 270)
            {
                Vector3 temp = new Vector3(-8, 0, 0);
                //temporary destination used to check if thelocation is occupied
                Vector3 tempDes = new Vector3();

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if unoccupied
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
            }
        }

        // Move Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                Vector3 temp = new Vector3(0, 0, 8);

                Vector3 tempDes = new Vector3();

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if unoccupied

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

            }

        }


        //Move Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (transform.rotation.eulerAngles.y == 180)
            {
                Vector3 temp = new Vector3(0, 0, -8);
                //temporary destination used to check if thelocation is occupied
                Vector3 tempDes = new Vector3();

                tempDes = transform.position + temp;
                //checking the grid square of the block up for vacancy
                if (grid.NodeFromWorldPoint(tempDes).occupied())
                {
                    //runs if unoccupied
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

            }
        }

    }



    public void isTurn()
    {
        if (actorNum == TurnController.getCurActor())
        {
            if (Input.anyKeyDown)
            {

                action();

                Debug.Log(TurnController.getCurActor());

                Debug.Log("action performed");

                print(actorNum);

                TurnController.incrementActor();

                print(actorNum);

                TurnController.lastActor();

                print(actorNum);

            }

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

}
