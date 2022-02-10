using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameThrowButton : MonoBehaviour
{
    private bool isActive = false;
    private Animator anim;
    private Button btn;
    private bool isThrowing = false;
    private GameObject player;

    public void SetActive(bool status){
        isActive = status;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        btn = GetComponent<Button>();

        player = GameObject.Find("BabyDragon");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isActive", isActive);

		btn.onClick.AddListener(OnButtonClick);

        isThrowing = player.GetComponent<Animator>().GetBool("isThrowing");
    }

    private void OnButtonClick(){
        if (isActive && !isThrowing){
            StartThrowing();
        };
    }

    private void StartThrowing(){
        isThrowing = true;
        player.GetComponent<Animator>().SetBool("isThrowing", true);
    }
}
