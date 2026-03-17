using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectGetAxis : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f; // Hareket hýzýný buradan ayarlayabilirsin

    void FixedUpdate() 
    {
        // Yatay (A-D) ve Dikey (W-S) giriþleri al (-1 ile 1 arasý deðer döner)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket yönünü belirle
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Karakteri hareket ettir (Kuvvet uygulayarak)
        rb.AddForce(movement * moveSpeed);
    }
}