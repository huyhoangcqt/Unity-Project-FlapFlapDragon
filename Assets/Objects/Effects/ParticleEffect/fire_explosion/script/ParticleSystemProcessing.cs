using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemProcessing : MonoBehaviour
{
    [SerializeField] private Collider2D col;

    private void Start() {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }
    private void OnParticleSystemStopped() {
        //print("Particle system stopped");
        col.enabled = true;
    }
}
