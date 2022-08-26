using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  // mouseX: left and right value of mouse
  // mouseY: up and down value of mouse
  private float mouseX, mouseY;
  private float mouseSensitivity = 200;
  public Transform player;

  private float xRotation;
  // private float yRotation;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  // Update is called once per frame
  void Update()
  {
    mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    player = GameObject.FindGameObjectWithTag("Player").transform;
    player.Rotate(Vector3.up * mouseX);
    xRotation -= mouseY;
    // yRotation += mouseX;

    // set rotation limit
    xRotation = Mathf.Clamp(xRotation, -60f, 60f);
    // yRotation = Mathf.Clamp(yRotation, -60f, 60f);
    // transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
    transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
  }
}
