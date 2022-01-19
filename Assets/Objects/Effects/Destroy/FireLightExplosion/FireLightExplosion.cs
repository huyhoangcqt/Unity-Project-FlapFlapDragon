using System.Collections;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class FireLightExplosion : MonoBehaviour
{
    private Light2DE myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light2DE>();
        StartCoroutine(StartEffect());
    }

    IEnumerator StartEffect(){
        myLight.intensity = 1f;
        yield return new WaitForSeconds(0.1f);
        myLight.intensity = 3f;
        yield return new WaitForSeconds(0.1f);
        myLight.intensity = 5f;
        yield return new WaitForSeconds(0.2f);
        myLight.intensity = 3f;
        yield return new WaitForSeconds(0.1f);
        myLight.intensity = 1f;
        Destroy(gameObject);
    }
}
