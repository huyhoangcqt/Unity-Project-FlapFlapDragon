using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public struct Condition{
    public int rage;
    public int mana;
} 

public class ButtonController : MonoBehaviour
{
    private float _bannedTime, _cooldownTime;
    public float bannedTime{ 
        get { return _bannedTime; }
        set { _bannedTime = value; }
    }
    public float cooldownTime{ 
        get { return _cooldownTime; }
        set { _cooldownTime = value; }
    }
    private bool isBanned, isCooldown, _isActive, _isEnoughEnergy;//energy/ rage
    public bool isActive{
        get { return _isActive; }
        set { _isActive = value; }
    }
    public bool isEnoughEnergy{
        get { return _isEnoughEnergy; }
        set { _isEnoughEnergy = value; }
    }

    protected GameObject flashEffect;
    protected ParticleController particleController;
    protected GameObject inactive, cooldownText, banned;
    private Text cdText;
    [SerializeField] private Condition condition;
    [SerializeField] private ManaController mpController;
    [SerializeField] private RageController rageController;

    void Start(){
        inactive = FindGameObject("inactive");
        cooldownText = FindGameObject("cooldownText");
        banned = FindGameObject("bannedSymbol");
        flashEffect = FindGameObject("flashEffect");
        particleController = flashEffect.GetComponent<ParticleController>();
        cdText = cooldownText.GetComponent<Text>();
        isBanned = false; isCooldown = false; isActive = true; isEnoughEnergy = true;
    }

       private bool CheckingEnergy(){
        if (!mpController.CheckingMana(condition.mana)){
            return false;
        }
        if (!rageController.CheckingRage(condition.rage)){
            return false;
        }
        return true;
    }

    GameObject FindGameObject(string objectName){
        Transform result = transform.Find(objectName);
        if (result == null){
            Debug.LogError("Could not find object '" + objectName + "';");
            return null;
        }
        else return result.gameObject;
    }

    /**
     * *Require to active: @ActiveButton() function
     * 1. No cooldown
     * 2. No banned
     * Enough energy/ rage point
    */
    public virtual void ActiveButton(){
       //print("ActiveButton");
        flashEffect.SetActive(true);
        particleController.Play();
        HideFlashEffect(1f);

        isActive = true;
        inactive.SetActive(false);
        Enable();
    }

    IEnumerator HideFlashEffect(float time){
        yield return new WaitForSeconds(time);
        flashEffect.SetActive(false);
    }

    public void DisableButton(){
        isActive = false;
        inactive.SetActive(true);
        Disable();
    }

    internal void BannedOn(float time){
        if (bannedTime <= 0){
            bannedTime = time;
            banned.SetActive(true);
            isBanned = true;
            DisableButton();
        }
        else {
            bannedTime = Math.Max(bannedTime, time);
        }
    }

    private int temp = 0;
    public void Update(){
        isEnoughEnergy = CheckingEnergy();
        if (bannedTime > 0){
            bannedTime -= Time.deltaTime;
            if (bannedTime <= 0){
                BannedOff();
            }
        };
        if (cooldownTime > 0){
            cooldownTime -= Time.deltaTime;
            if (cooldownTime <= 0){
                CooldownEffectEnd();
            }
        };
        if (!isActive){
            if (temp < 3){
                temp++;
            }
            if (!isCooldown && !isBanned && isEnoughEnergy){
                ActiveButton();
            }
        }
        if (isActive && !isEnoughEnergy){
            print("Disable Button");
            DisableButton();
        }
    }

    private void BannedOff(){
        banned.SetActive(false);
        isBanned = false;
    }

    internal void CooldownEffectStart(float time){
        cooldownTime = time;
        cooldownText.SetActive(true);
        isCooldown = true;
        DisableButton();
    }

    internal void CooldownEffectEnd(){
        cooldownText.SetActive(false);
        isCooldown = false;
    }

    internal void UpdateCooldownText(float time, string format){
        cdText.text = time.ToString(format);
    }

    public void Disable(){
        GetComponent<Button>().enabled = false;
       ////print("Button disable");
    }
    public void Enable(){
        GetComponent<Button>().enabled = true;
       ////print("Button enable");
    }
}
