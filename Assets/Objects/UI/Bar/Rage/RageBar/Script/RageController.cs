using UnityEngine;
using UnityEngine.UI;

public class RageController : MonoBehaviour
{
private float maxRage = 100;
    private float crrRage = 0;
    public RageBar rageBar;

    public GameObject rageBarFill;
    private Animator rageBarAnim;

    public GameObject[] rageFires;

    void Start()
    {
        maxRage = 100;
        crrRage = 0;
        rageBar.SetMaxRage(maxRage);
        rageBar.SetCurrentRage(crrRage);

        rageBarAnim = rageBarFill.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (crrRage >= 100){
            RageFullyEvent();
        }
        else {
            DisableRageFullyEffects();
        }
    }

    private void DisableRageFullyEffects(){
        if (rageFires.Length > 0){
            for (int i = 0; i < rageFires.Length; i++){
                rageFires[i].SetActive(false);
            }
        }
    }

    private void RageFullyEvent(){
        if (rageFires.Length > 0){
            for (int i = 0; i < rageFires.Length; i++){
                rageFires[i].SetActive(true);
            }
        }
    }

    public void RageUp(float amount){
        crrRage += amount;
        if (crrRage > 100){
            crrRage = 100;
        }
        rageBar.SetCurrentRage(crrRage);
        rageBarAnim.SetBool("onRageUp", true);
    }

    public bool CheckingRage(int rage){
        if (crrRage >= rage){
            return true;
        }
        return false;
    }

    public void RageDown(float amount){
        crrRage -= amount;
        if (crrRage <= 0){
            crrRage = 0;
        }
        rageBar.SetCurrentRage(crrRage);
    }

    public float getCurrentRagePofloat(){
        return crrRage;
    }

    public float GetMaxRage(){
        return maxRage;
    }
}
