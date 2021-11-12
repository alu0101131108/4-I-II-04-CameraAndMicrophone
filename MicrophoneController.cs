using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneController : MonoBehaviour {
  private AudioSource audioSource;
  private string device;
  public float Volume;

  void Start() {
    audioSource = GetComponent<AudioSource>();
    device = Microphone.devices[0];
    GetComponent<AudioSource>().clip = Microphone.Start(device, true, 999, 44100);
    while (!(Microphone.GetPosition(device) > 0))
    {} GetComponent<AudioSource>().Play();
  }

  void Update() {
    float[] data = new float[735];
    GetComponent<AudioSource>().GetOutputData(data, 0);

    //take the median of the recorded samples
    ArrayList outputDataValues = new ArrayList();
    foreach (float value in data)
    {
      outputDataValues.Add(Mathf.Abs(value));
    }
    outputDataValues.Sort();
    Volume = (float)outputDataValues[735 / 2];
  }
}