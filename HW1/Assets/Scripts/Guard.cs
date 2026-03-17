using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guard : MonoBehaviour
{
    public Transform pointA; // Ýlk durak
    public Transform pointB; // Ýkinci durak
    public float speed = 3f; // Yürüme hýzý

    void Start()
    {
        // ÖDEV ÞARTI: Periyodik hareket için Coroutine baþlatýyoruz
        if (pointA != null && pointB != null)
        {
            StartCoroutine(PatrolRoutine());
        }
    }

    IEnumerator PatrolRoutine()
    {
        Vector3 target = pointB.position;

        while (true)
        {
            // Hedefe doðru ilerle
            while (Vector3.Distance(transform.position, target) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                
                yield return null; 
            }

            // Hedefe varýnca 1 saniye bekle (Daha doðal görünür)
            yield return new WaitForSeconds(1f);

            // Hedefi deðiþtir (B'deyse A'ya, A'daysa B'ye)
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    // Oyuncuya çarparsa öldürür
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
