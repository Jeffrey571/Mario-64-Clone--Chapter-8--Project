using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KeyManager km = other.gameObject.GetComponent<KeyManager>();
            if (km != null)
            {
                km.GetAKey();
                Destroy(this.gameObject);
            }
        }
    }
}
