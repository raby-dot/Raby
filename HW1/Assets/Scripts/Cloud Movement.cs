using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.5f;          // Hareket hýzý
    public float leftLimit = -10f;     // En sol nokta
    public float rightLimit = 10f;     // En sað nokta

    private int direction = 1;          // 1: Saða, -1: Sola

    void Start()
    {
        // ÖDEV ÞARTI: Periyodik hareket için Coroutine
        StartCoroutine(PingPongMove());
    }

    IEnumerator PingPongMove()
    {
        while (true)
        {
            // Bulutu mevcut yöne doðru hareket ettir
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            // Sað sýnýra ulaþtýysa sola dön
            if (transform.position.x >= rightLimit)
            {
                direction = -1;
            }
            // Sol sýnýra ulaþtýysa saða dön
            if (transform.position.x <= leftLimit)
            {
                direction = 1;
            }

            yield return null; // Her frame'de çalýþmaya devam et
        }
    }
}