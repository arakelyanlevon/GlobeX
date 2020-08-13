using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
  GameObject[] roads;
  Camera mainCamera;
  Vector2 cameraMetrics;
  Vector2 roadMetrics;

  const float speed = 0.05f;
  const string roadTag = "Road";

  void Start() {
    mainCamera = GetComponent<Camera>();
    roads = GameObject.FindGameObjectsWithTag(roadTag);

    cameraMetrics = new Vector2(2f * mainCamera.orthographicSize * mainCamera.aspect, 2f * mainCamera.orthographicSize);
    roadMetrics = roads[0].GetComponent<Renderer>().bounds.size;
  }

  void Update() {
    ChangeRoadsPosition();
  }

  void ChangeRoadsPosition() {
    Vector2 cameraPos = transform.position;
    for(int i = 0; i < roads.Length; i++) {
      Vector2 roadPos = roads[i].transform.position;
      if(roadPos.y + roadMetrics.y / 2 <= cameraPos.y - cameraMetrics.y / 2) {
        roads[i].transform.position = new Vector2(roadPos.x, cameraPos.y + cameraMetrics.y / 2 + roadMetrics.y / 2);
      } else {
        roads[i].transform.position = new Vector2(roadPos.x, roadPos.y - speed);
      }
    }
  }
}
