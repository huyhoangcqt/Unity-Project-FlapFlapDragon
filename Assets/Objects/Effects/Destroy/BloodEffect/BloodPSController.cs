using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPSController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTiming());
    }

    IEnumerator DestroyTiming(){
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
