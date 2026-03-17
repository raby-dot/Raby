using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.5f;          
    public float leftLimit = -10f;    
    public float rightLimit = 10f;    

    private int direction = 1;        

    void Start()
    {
      
        StartCoroutine(CloudMove());
    }

    IEnumerator CloudMove()
    {
        while (true)
        {
         
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            if (transform.position.x >= rightLimit)
            {
                direction = -1;
            }
         
            if (transform.position.x <= leftLimit)
            {
                direction = 1;
            }

            yield return null; 
        }
    }
}