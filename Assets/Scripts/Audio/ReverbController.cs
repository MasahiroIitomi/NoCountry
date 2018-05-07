using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ReverbController : MonoBehaviour
{

    public AudioMixer mixer;
    public AudioMixerSnapshot[] snapshots;
    public float[] weights;

    // Use this for initialization
    void Start()
    {
        weights[0] = 0.0f;
        weights[1] = 1.0f;
        mixer.TransitionToSnapshots(snapshots, weights, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
