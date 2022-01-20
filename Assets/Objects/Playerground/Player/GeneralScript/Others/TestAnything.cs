using UnityEngine;

public class TestAnything : MonoBehaviour
{
    private HealthController healthController;
    // Start is called before the first frame update
    // private int objectGUID = 0;
    void Start()
    {
        healthController = GetComponent<HealthController>();
    }

    void Update()
    {
        // MouseDetection();
        TouchDetection();
    }

    private void MouseDetection(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed primary button.");
            healthController.TakeDamage(10);
        }
    }

    private void TouchDetection(){
        if (Input.touchCount > 0){
            Touch[] touches = Input.touches;
            foreach (Touch touch in touches){
                if (touch.phase == TouchPhase.Began){
                    Debug.Log("Touch");
                    healthController.TakeDamage(10);
                }
            }
        }
    }
}
