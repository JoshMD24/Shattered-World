using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{

    public int fiberLeft;
    public bool isPicked;
    
    void Start()
    {
        isPicked = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //what happens if the tree gets hit by a trigger tagged Player
        {
            fiberLeft--; //take away one fiber
        }
        if (fiberLeft <= 0) //what happens if there is no fiber left
        {
            picked(); //use void picked
        }
    }

    void picked() //what happens when the bush is out of fiber
    {
        Debug.Log("Bush out of fiber");
        GetComponent<MeshRenderer>().enabled = false; //disable the mesh renderer
        GetComponent<MeshCollider>().enabled = false; //disbale the mesh collider
        isPicked = true; //change the isPicked state to true
        StartCoroutine(reGrowBush()); //start the reGrowBush coroutine
    }

    IEnumerator reGrowBush() //reGrowBush corotine
    {
        yield return new WaitForSeconds(5); //wait x seconds before using the code below
        Debug.Log("Bush regrown");
        GetComponent<MeshRenderer>().enabled = true; //enable the mesh renderer
        GetComponent<MeshCollider>().enabled = true; //enable the mesh collider
        isPicked = false; //change the isPicked state to false
        fiberLeft = 12; //change the fiber left to 12
    }

}