using UnityEngine;

public class CameraPin : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.y = Mathf.Lerp(v3.y, target.position.y, Time.deltaTime * speed);
        transform.position = v3;
    }

}