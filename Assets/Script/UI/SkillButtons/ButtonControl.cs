using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
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

    [SerializeField]protected GameObject flashEffect;
    private GameObject inactive, cooldownText, banned;
    private Text cdText;
    void Start(){
        inactive = FindGameObject("inactive");
        cooldownText = FindGameObject("cooldownText");
        banned = FindGameObject("bannedSymbol");
        cdText = cooldownText.GetComponent<Text>();
    }

    GameObject FindGameObject(string objectName){
        Transform result = transform.Find(objectName);
        if (result == null){
            Debug.LogError("Could not find object '" + objectName + "';");
            return null;
        }
        else return result.gameObject;
    }

    public void ActiveButton(){
        Vector3 convertPos = Camera.main.ScreenToWorldPoint(transform.position);
        convertPos = transform.position;
        GameObject flashEffInstance = Instantiate(flashEffect, convertPos, Quaternion.identity);
        Destroy(flashEffInstance, 1.5f);

        inactive.SetActive(false);
        Enable();
    }

    public void DisableButton(){
        inactive.SetActive(true);
        Disable();
    }

    internal void BannedOn(float time){
        if (bannedTime <= 0){
            bannedTime = time;
            banned.SetActive(true);
            DisableButton();
        }
        else {
            bannedTime += time;
        }
    }

    public void Update(){
        if (bannedTime > 0){
            bannedTime -= Time.deltaTime;
            if (bannedTime <= 0){
                BannedOff();
            }
        };
        if (cooldownTime > 0){
            cooldownTime -= Time.deltaTime;
        };
    }

    private void BannedOff(){
        banned.SetActive(false);
        if (cooldownTime <= 0){
            ActiveButton();
        }
    }

    internal void CooldownEffectStart(float time){
        cooldownTime = time;
        cooldownText.SetActive(true);
        DisableButton();
    }

    internal void CooldownEffectEnd(){
        cooldownText.SetActive(false);
        if (bannedTime <= 0){
            ActiveButton();
        }
    }

    internal void UpdateCooldownText(float time, string format){
        cdText.text = time.ToString(format);
    }

    public void Disable(){
        GetComponent<Button>().enabled = false;
        print("Button disable");
    }
    public void Enable(){
        GetComponent<Button>().enabled = true;
        print("Button enable");
    }
}
