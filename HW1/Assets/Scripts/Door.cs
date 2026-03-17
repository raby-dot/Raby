using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    private void OnCollisionEnter(Collision collision) 
    {
        
        Debug.Log("Who hit the door:" + collision.gameObject.name);

        
        bool holdsKey = collision.gameObject.CompareTag("Key") || 
                        collision.gameObject.GetComponentInChildren<Key>() != null;

        if (holdsKey) 
        {
            Debug.Log("Key arrived !");
            Time.timeScale = 0f; 

            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowEndScreen(true);
            }
        }
    }
}