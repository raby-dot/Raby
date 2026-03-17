using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guard : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 3f; 

    void Start()
    {
        
        if (pointA != null && pointB != null)
        {
            StartCoroutine(GuardRoutine());
        }
    }

    IEnumerator GuardRoutine()
    {
        Vector3 target = pointB.position;

        while (true)
        {
       
            while (Vector3.Distance(transform.position, target) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                
                yield return null; 
            }

         
            yield return new WaitForSeconds(1f);

            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
