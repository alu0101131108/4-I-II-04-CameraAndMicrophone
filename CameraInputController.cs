using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputController : MonoBehaviour
{
  static WebCamTexture webcam;
  private Texture defaultTexture;
  
  void Start()
  {
    WebCamTexture webcamTexture = new WebCamTexture();
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.mainTexture = webcamTexture;
    webcamTexture.Play();
  }
}
