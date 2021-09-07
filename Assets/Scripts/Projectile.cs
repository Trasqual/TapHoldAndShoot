using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;

    private bool hasHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHit)
        {
            hasHit = true;
            StickToTarget(collision.transform);
        }
    }

    void Update()
    {
        if (!hasHit)
        {
            transform.forward = rb.velocity;
        }
    }

    private void StickToTarget(Transform target)
    {
        rb.isKinematic = true;
        collider.enabled = false;
        transform.parent = target;
    }
}
