using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform m_targetToFollow;
    [SerializeField] private float m_smoothness;
    private Vector3 m_offset;
    // Start is called before the first frame update
    void Start()
    {
        SetUpTargetToFollow();
        SetOffset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    void SetUpTargetToFollow(){
        if(m_targetToFollow == null){
            m_targetToFollow = FindObjectOfType<ShootScript>()?.Pointer;
        }
    }

    void SetOffset(){
        m_offset = transform.position - m_targetToFollow.position;
    }

    void FollowTarget(){
        transform.position = Vector3.Lerp(transform.position, m_targetToFollow.transform.position + m_offset,m_smoothness);
    }
}
