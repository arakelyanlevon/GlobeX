using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  public Camera cam;
  Vector2 cameraMetrics;
  Vector2 carMetrics;

  void Start() {
    cameraMetrics = new Vector2(2f * cam.orthographicSize * cam.aspect, 2f * cam.orthographicSize);
    carMetrics = GetComponent<Renderer>().bounds.size;
  }

  void Update() {
    move();
  }

  void move(){
    Vector3 carPos = transform.position;
    Vector3 camPos = cam.transform.position;
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    // Borders: left -> right -> top -> down
    if(carPos.x - carMetrics.x / 2 - 1 < camPos.x - cameraMetrics.x / 2) {
      if(horizontal < 0) {
        horizontal = 0f;
      }
    }

    if(carPos.x + carMetrics.x / 2 + 0.9 > camPos.x + cameraMetrics.x / 2) {
      if(horizontal > 0) {
        horizontal = 0f;
      }
    }
    
    if(carPos.y + carMetrics.y / 2 > camPos.y + cameraMetrics.y / 2) {
      if(vertical > 0) {
        vertical = 0f;
      }
    }

    if(carPos.y - carMetrics.y / 2 < camPos.y - cameraMetrics.y / 2) {
      if(vertical < 0) {
        vertical = 0f;
      }
    } 
	
    transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * 7f;
  }
}
