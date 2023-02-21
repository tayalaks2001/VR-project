using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

// public class PlayerController : MonoBehaviour
// {
//     public SteamVR_Action_Vector2 input;
//     public float speed = 2;
//     public Transform cameraTransform;
//     private CharacterController characterController;
//     private CapsuleCollider capsuleCollider;
//     // Start is called before the first frame update
//     void Start()
//     {
//         // characterController = GetComponent<CharacterController>();
//         capsuleCollider = GetComponent<CapsuleCollider>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
//         transform.position+=(Vector3.ProjectOnPlane(Time.deltaTime*direction * speed, Vector3.up));

//         float distanceFromFloor = Vector3.Dot(cameraTransform.localPosition, Vector3.up);
//         capsuleCollider.height = Mathf.Max(capsuleCollider.radius, distanceFromFloor);

//         capsuleCollider.center = cameraTransform.localPosition - 0.5f * distanceFromFloor * Vector3.up;
//         // characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0,9.81f,0)*Time.deltaTime);
//     }
// }


public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 2;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0,9.81f,0)*Time.deltaTime);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        /*if (hit.transform.tag == "wall")
        {

        }*/

        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
           {
            rb.velocity = hit.moveDirection * 4.0f;
        }
    }
}
