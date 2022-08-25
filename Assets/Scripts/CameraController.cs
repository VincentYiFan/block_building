using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float m_cameraSpeed = 7f;
    private Vector3 m_moveDirection;
    public float m_cameraRotateSensitivty = 3f;
    private Vector3 m_cameraDeltaRotation;

    void Update()
    {
        // Simulate edit camera behavior in play mode
        if (Input.GetMouseButton(1))
        {
            // Camera translation
            m_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_moveDirection = transform.TransformDirection(m_moveDirection);

            if (Input.GetKey(KeyCode.Q))
            {
                m_moveDirection -= new Vector3(0, 1, 0);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                m_moveDirection += new Vector3(0, 1, 0);
            }

            transform.position += (m_moveDirection * Time.deltaTime * m_cameraSpeed);

            // Camera rotation
            m_cameraDeltaRotation = Vector3.zero;
            float rotateSpeed = m_cameraRotateSensitivty * 90f * Time.deltaTime;
            m_cameraDeltaRotation.x += Input.GetAxis("Mouse X") * rotateSpeed;
            m_cameraDeltaRotation.y -= Input.GetAxis("Mouse Y") * rotateSpeed;

            Vector3 newLocalEulerAngles = transform.localEulerAngles + new Vector3(m_cameraDeltaRotation.y, m_cameraDeltaRotation.x, 0);
            newLocalEulerAngles.x = Mathf.Repeat(newLocalEulerAngles.x, 360);
            transform.localEulerAngles = newLocalEulerAngles;
        }
    }
}
