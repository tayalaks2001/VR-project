using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowAndStick : MonoBehaviour
{

    const float WALL_X_POSITION = -7;
    private Vector3 TEST_VELOCITY = new Vector3(-15, 3.2f, 6);
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    bool IsThrowing()
    {
        return Input.GetKeyDown("t");
    }

    void Throw(Vector3 velocity)
    {
        body.velocity = velocity;
    }

    void Update()
    {
        if (IsThrowing())
        {
            Throw(TEST_VELOCITY);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = collision.transform.position;

        if(!eequal(pos.x, WALL_X_POSITION)) {
            return;
        }
        
        body.velocity = new Vector3(0, 0, 0);
        body.isKinematic = true;
        body.rotation = Quaternion.identity;

        /*float y = selfPos.y;
        float z = selfPos.z;

        Destroy(gameObject);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Instantiate(cube, new Vector3(-7, y, z), Quaternion.identity);*/
    }

    private bool eequal(float a, float b) {
        return Math.Abs(a-b) < 1e-3;
    }
}
