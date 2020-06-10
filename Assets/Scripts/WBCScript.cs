using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WBCScript : MonoBehaviour
{
    public bool inPlay;
    public float speed; //Speed of the cell against x axis
    public float leftScreenEdge; //Maximum limit on -x axis
    public float rightScreenEdge; // maximum limit on + x axis
    public Transform cellExplosion; //particle system of cell
    public Transform virusExplosion;    //particle system of virus
    public GameObject wbcell; //link to wbcell
    public GameManager gm;
    public float circleScale;
   
    
    void Update()
    {
         
        float horizontal = Input.GetAxis("Horizontal"); //Setting the horizontal axis to a variable
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); // Calculation for the movement of the cell

        if (transform.position.x <= leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        } //if the set position of the screen edge is less than its current position, block movement

        if (transform.position.x >= rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
        if (circleScale < 0.23f|| circleScale > 1.4f) /*When game over, stop cell from updating position*/
        {
               gm.GameOver();
        }

    }

    void OnCellHit(GameObject wbcell)
    {
        //Debug.Log("Entered onCellHit");
        circleScale += 0.10f;       //add to the current scale of the cell
        wbcell.transform.localScale = new Vector2(circleScale, circleScale); //transform the local scale of the circle
       // Debug.Log(circleScale)
    }

    void OnVirusHit(GameObject wbcell)
    {
       // Debug.Log("Entered virus hit");
        circleScale -= 0.10f; //subtract from the radius of the cell
        wbcell.transform.localScale = new Vector2(circleScale, circleScale);
        //Debug.Log(circleScale);
    }

    public void OnCollisionEnter2D(Collision2D regularcollision)
    {
        if (regularcollision.transform.CompareTag("cell"))
        {
            OnCellHit(GameObject.FindGameObjectWithTag("wb")); //enter the fxn and increase the size of the cell
            Instantiate(cellExplosion, regularcollision.transform.position, regularcollision.transform.rotation); // explosion takes place
            Destroy(regularcollision.gameObject);
              

        }
            
        if (regularcollision.transform.CompareTag("virus"))
        {
            OnVirusHit(GameObject.FindGameObjectWithTag("wb")); //enter the fxn and reduce size of cell
            Instantiate(virusExplosion, regularcollision.transform.position, regularcollision.transform.rotation);
            Destroy(regularcollision.gameObject);

        }

       
    }
}

