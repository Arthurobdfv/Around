using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_movementSpeed;
    private Rigidbody m_thisRigidbody;
    public bool m_isActive;
    // Start is called before the first frame update
    void Start()
    {
        m_thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_isActive) MovePlayer();
    }

    void MovePlayer(){
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f){
            Vector3 force = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
            m_thisRigidbody.MovePosition(transform.position + force * Time.deltaTime * m_movementSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(force,Vector3.up),.9f);
        }
    }
}
