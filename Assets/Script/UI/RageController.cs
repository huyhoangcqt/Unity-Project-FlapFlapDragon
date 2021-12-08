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
    public GameObject flameThrowButton;
    // Start is called before the first frame update
    void Start()
    {
        maxRage = 100;
        crrRage = 0;
        rageBar.SetMaxRage(maxRage);
        rageBar.SetCurrentRage(crrRage);

        rageBarAnim = rageBarFill.gameObject.GetComponent<Animator>();

        // rageFires = GameObject.Find("RageFire");
    }

    // Update is called once per frame
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

        flameThrowButton.GetComponent<FlameThrowButton>().SetActive(false);
    }

    private void RageFullyEvent(){
        //Fire active
        if (rageFires.Length > 0){
            for (int i = 0; i < rageFires.Length; i++){
                rageFires[i].SetActive(true);
            }
        }
        //Special skill active
        flameThrowButton.GetComponent<FlameThrowButton>().SetActive(true);
    }

    public void RageUp(float amount){
        crrRage += amount;
        if (crrRage > 100){
            crrRage = 100;
        }
        rageBar.SetCurrentRage(crrRage);
        rageBarAnim.SetBool("onRageUp", true);
        // Debug.Log("Target Dmg: " + dmg);
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
