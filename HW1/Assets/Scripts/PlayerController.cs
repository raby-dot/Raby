using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float rotationSpeed = 2f;
    
    [Header("References")]
    public Camera playerCamera;
    public Transform holdPoint;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private bool isDead = false;
    private GameObject carriedKey;

    void Awake() {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (isDead) return;

        HandleMovement();
        HandleRotation();
    }

    void HandleMovement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void HandleRotation() {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotationSpeed);
        
        verticalRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        playerCamera.transform.localEulerAngles = Vector3.right * verticalRotation;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Key") && carriedKey == null) GrabKey(hit.gameObject);
    }

    void GrabKey(GameObject keyObj) {
        carriedKey = keyObj;
        
        if (keyObj.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.isKinematic = true;
        keyObj.transform.SetParent(this.transform);

        if (holdPoint != null) {
            keyObj.transform.SetPositionAndRotation(holdPoint.position, holdPoint.rotation);
        }
    }

    public void Die() {
        if (isDead) return;
        isDead = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (UIManager.Instance != null) UIManager.Instance.ShowEndScreen(false);
    }
}