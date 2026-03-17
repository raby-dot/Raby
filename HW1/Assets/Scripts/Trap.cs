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
            // 1. ADIM: TUZAÐI KAPAT (Her þeyi gizle ve çarpýþmayý kes)
            SetTrapState(false);
            yield return new WaitForSeconds(inactiveDuration);

            // 2. ADIM: TUZAÐI AÇ (Her þeyi göster ve çarpýþmayý aç)
            SetTrapState(true);
            yield return new WaitForSeconds(activeDuration);
        }
    }

    void SetTrapState(bool state)
    {
        foreach (var r in allRenderers) r.enabled = state;
        foreach (var c in allColliders) c.enabled = state;
    }
    // Bu fonksiyonu Trap scriptinin en altýna, ama en son süslü parantezin içine ekle
    private void OnCollisionEnter(Collision collision)
    {
    // Eðer çarpan nesnenin etiketi (Tag) "Player" ise
        if (collision.gameObject.CompareTag("Player"))
        {
        // Oyuncunun Die fonksiyonunu çalýþtýr
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}