using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;

    private bool hasHit;

    GameObject anchor;

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
            if(rb.velocity != Vector3.zero)
            transform.forward = rb.velocity;
        }
        else
        {
            transform.position = anchor.transform.position;
            transform.rotation = anchor.transform.rotation;
        }
    }

    private void StickToTarget(Transform target)
    {
        rb.isKinematic = true;
        collider.enabled = false;
        anchor = new GameObject("Anchor");
        anchor.transform.SetPositionAndRotation(transform.position, transform.rotation);
        anchor.transform.SetParent(target);
    }
}
