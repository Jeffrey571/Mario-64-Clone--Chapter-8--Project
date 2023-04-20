using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool IsLocked = true;
    public Vector3 DoorOpenOffset = Vector3.up * 5;

    public void OpenDoor()
    {
        IsLocked = false;
        transform.position += DoorOpenOffset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KeyManager km = other.gameObject.GetComponent<KeyManager>();
            if (km != null)
            {
                if (IsLocked && km.HasKey())
                {
                    km.UseKey();
                    OpenDoor();
                }
            }
        }
    }
}
