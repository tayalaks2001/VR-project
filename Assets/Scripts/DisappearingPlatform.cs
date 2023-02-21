using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    public Material newMaterial;

    // private bool platformActivated = false;

    void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject == player)
    	{
    		// GetComponent<MeshRenderer>().enabled = false;
    		platform.GetComponent<MovingPlatform>().moving = true;
    		GetComponent<Renderer>().material.color = new Color(0,255,255);
    	}
    }

}
