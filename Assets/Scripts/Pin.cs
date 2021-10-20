using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 1f; 
    float timeLeft = 0.5f;
    public bool flip;
    public float MAX_FORCE = 500f;

    void Update()
    {
        if (flip)
        {
            transform.Rotate(0, 0, speed );
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                flip = false;
                timeLeft = 0.5f;
            }
        }

        Vector2 dir = (GetMouseWorldPosition() - transform.position).normalized;
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    public void Launch(float force)
    {
        Vector2 dir = (GetMouseWorldPosition() - transform.position).normalized * -1f;
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

}
