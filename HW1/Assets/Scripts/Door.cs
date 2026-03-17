using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    private void OnCollisionEnter(Collision collision) 
    {
        // Konsola kimin çarptýðýný yazdýr (Hata ayýklama için)
        Debug.Log("Kapýya çarpan: " + collision.gameObject.name);

        // Kontrol 1: Çarpan obje anahtar mý?
        // Kontrol 2: Çarpan objenin (Player) içinde/üzerinde anahtar var mý?
        bool holdsKey = collision.gameObject.CompareTag("Key") || 
                        collision.gameObject.GetComponentInChildren<Key>() != null;

        if (holdsKey) 
        {
            Debug.Log("ZAFER: Anahtar kapýya ulaþtý!");
            Time.timeScale = 0f; 

            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowEndScreen(true);
            }
        }
    }
}