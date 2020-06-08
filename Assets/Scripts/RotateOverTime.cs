using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f,0f,m_speed * Time.deltaTime));
    }
}
