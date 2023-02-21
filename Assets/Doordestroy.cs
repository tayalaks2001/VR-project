using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doordestroy : MonoBehaviour
{
    public GameObject door;  // The door that can be destroyed

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == door)
        {
            Destroy(door);
        }
    }
}
