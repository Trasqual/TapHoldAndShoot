using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject objectToShoot;

    public void Shoot(Vector3 shootVector, float power)
    {
        var shotObject = Instantiate(objectToShoot, transform.position, Quaternion.identity,null);
        var shotRb = shotObject.GetComponent<Rigidbody>();
        shotRb.AddForce(shootVector * power, ForceMode.Impulse);
    }
}
