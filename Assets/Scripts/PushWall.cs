using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushWall : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 3;
    private bool _isMoving;
    void Update()
    {
        if(_isMoving) return;

        if(Input.GetKeyDown(KeyCode.A)) Assemble(Vector3.left); 
        // if(Input.GetKeyDown(KeyCode.D)) Assemble(Vector3.right);         
        // if(Input.GetKeyDown(KeyCode.W)) Assemble(Vector3.forward); 
        // if(Input.GetKeyDown(KeyCode.S)) Assemble(Vector3.back); 

        void Assemble(Vector3 dir)
        {
            var anchor = (transform.position) + (Vector3.down + dir) * 1f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
    }

    IEnumerator Roll (Vector3 anchor, Vector3 axis) 
    {
        _isMoving = true;

        for(int i = 0; i < (90 / _rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);

        }

        _isMoving = false;


    }
}
