using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    public bool moving = false;

    private int target = 0;

    void Start()
    {
    	transform.position = waypoints[waypoints.Count-1].position;
    }

    void Update()
    {
        if (moving){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, speed*Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
    	if (moving && transform.position == waypoints[target].position)
    	{
    		if (target == waypoints.Count - 1)
    		{
    			target = 0;
    		}
    		else
    		{
    			target += 1;
    		}
    	}
    }
}
