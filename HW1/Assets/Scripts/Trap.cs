using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float activeDuration = 2f;
    public float inactiveDuration = 2f;

    // Alt objelerin hepsini kontrol etmek için listeler
    private MeshRenderer[] allRenderers;
    private Collider[] allColliders;

    void Awake()
    {
        // Objeye ve içindeki tüm çocuklara ait bileþenleri bulur
        allRenderers = GetComponentsInChildren<MeshRenderer>();
        allColliders = GetComponentsInChildren<Collider>();
    }

    void Start()
    {
        StartCoroutine(TrapCycle());
    }

    IEnumerator TrapCycle()
    {
        while (true)
        {
            SetTrapState(false);
            yield return new WaitForSeconds(inactiveDuration);

            SetTrapState(true);
            yield return new WaitForSeconds(activeDuration);
        }
    }

    void SetTrapState(bool state)
    {
        foreach (var r in allRenderers) r.enabled = state;
        foreach (var c in allColliders) c.enabled = state;
    }
  
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {
      
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}