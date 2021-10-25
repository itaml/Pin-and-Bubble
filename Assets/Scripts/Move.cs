using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Inputs inputs_class;

    void Update()
    {
        if(inputs_class.gameOver==false && inputs_class.aim==false) gameObject.transform.Translate(0, Random.Range(0.001f, 0.002f), 0 * Time.deltaTime);
    }
}
