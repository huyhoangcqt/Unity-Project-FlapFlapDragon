using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTiming());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyTiming(){
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
