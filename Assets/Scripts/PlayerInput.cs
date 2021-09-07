using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float maxY = 5f;
    [SerializeField] float maxZ = 8f;
    [SerializeField] float aimSpeed = 10f;
    [SerializeField] float autoShootTimer = 2f;
    [SerializeField] float shootPower = 2f;

    [SerializeField] Shooter shooter;
    [SerializeField] ShootTrajectory trajectory;

    private Vector3 shootVector;



    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            IncreaseShootVector();
        }

        if (Input.GetMouseButtonUp(0) || IsAutoShootTimerUp())
        {
            shooter.Shoot(shootVector, shootPower);
            shootVector = Vector3.zero;
            trajectory.ResetTrajectory();
        }
    }

    private void IncreaseShootVector()
    {
        shootVector.y = Mathf.Lerp(shootVector.y, maxY, Time.deltaTime * aimSpeed);
        shootVector.z = Mathf.Lerp(shootVector.z, maxZ, Time.deltaTime * aimSpeed);
        trajectory.DrawTrajectory(shootVector * shootPower);
    }

    private bool IsAutoShootTimerUp()
    {
        if(shootVector.y >= maxY && shootVector.z >= maxZ)
        {
            autoShootTimer -= Time.deltaTime;
        }

        if(autoShootTimer <= 0)
        {
            autoShootTimer = 3f;
            return true;
        }

        return false;
    }
}
