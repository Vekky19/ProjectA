using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSprintFOV : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cam;

    [SerializeField] float ogFov, sprintFov;

    private void Start()
    {
        ogFov = cam.m_Lens.FieldOfView;
        sprintFov = ogFov + 5f;
    }

    void Update()
    {
        if (Input.GetKey(KeybindManager.Instance.Sprint))
        {
            cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, sprintFov, 5f * Time.deltaTime);
        }
        else
        {
            cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, ogFov, 5f * Time.deltaTime);
        }
    }
}
