using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private Pin pin_class;
    private float holdTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDown = Time.time - holdTime;
            pin_class.Launch(CalculateHoldDownForce(holdDown));
        }
        if (Input.GetMouseButton(0))
        {
            float holdDown = Time.time - holdTime;
        }
    }
    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormal = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormal * pin_class.MAX_FORCE;
        return force;
    }



}
