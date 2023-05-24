using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cinemachine;
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed;
        transform.eulerAngles = new Vector3(0,Camera.main.transform.eulerAngles.y,0);
    }
}
