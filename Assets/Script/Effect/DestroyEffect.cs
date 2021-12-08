using System.Collections;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SurvivalTiming());
    }

    IEnumerator SurvivalTiming(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
