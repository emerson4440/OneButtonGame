using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool m_Pause;

    private void Start()
    {
        m_Pause = false;
    }

    void Update()
    {
        if (m_Pause == false)
        {
            float zRtation = Mathf.PingPong(Time.time * 100, 90f);
            transform.localRotation = Quaternion.Euler(0, 0, zRtation);
        }

    }
}
