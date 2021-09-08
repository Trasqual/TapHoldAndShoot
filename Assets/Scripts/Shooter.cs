using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject objectToShoot;

    [SerializeField] float maxY = 5f;
    [SerializeField] float maxZ = 8f;
    [SerializeField] float aimSpeed = 10f;
    [SerializeField] float shootPower = 2f;

    ShootTrajectory trajectory;

    private Vector3 shootVector;

    float lerpAmount = 0f;

    private void Start()
    {
        trajectory = GetComponent<ShootTrajectory>();
    }

    public void Aim()
    {
        lerpAmount += Time.deltaTime * aimSpeed;
        var newY = Mathf.Lerp(1f, maxY, lerpAmount);
        var newZ = Mathf.Lerp(1f, maxZ, lerpAmount);
        shootVector.y = newY;
        shootVector.z = newZ;
        trajectory.DrawTrajectory(shootVector * shootPower);
    }

    public void Shoot()
    {
        var shotObject = Instantiate(objectToShoot, transform.position, Quaternion.identity,null);
        var shotRb = shotObject.GetComponent<Rigidbody>();
        shotRb.velocity = shootVector * shootPower;
        shootVector = Vector3.zero;
        trajectory.ResetTrajectory();
        lerpAmount = 0f;
    }
}
