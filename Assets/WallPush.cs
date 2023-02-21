using UnityEngine;

public class WallPush : MonoBehaviour
{
    public float pushForce = 100.0f;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            pushDirection = -pushDirection.normalized;
            rigidBody.AddForce(pushDirection * pushForce);
        }
    }
}