using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatVisible : MonoBehaviour
{
    private bool _isVisible;
    public bool isVisible { 
        get { return _isVisible;}
        set { _isVisible = value;}
    }

    public void Awake(){
        isVisible = false;
    }

    private BatController batcontroller;
    // private Component[] renderers;
    public void Start(){
        // renderers = GetComponentsInChildren<Renderer>();
        // if (renderers.Length == 0){
        //     Debug.LogError("No renderer");
        // }
        batcontroller = GetComponent<BatController>();
        if (batcontroller == null){
           Debug.LogError("No Bat Controller");
        }
    }

    public void OnBecameVisible(){
        isVisible = true;
        batcontroller.OnbecameVisible();
    }
    public void OnBecameInvisible(){
        isVisible = false;
        batcontroller.OnBecameInvisible();
    }

    public void Update(){
        // foreach (Renderer rend in renderers){
        //     if (rend.isVisible){ // true if active, false if inactive. Not my case
        //         if (!isVisible){
        //             OnBecameVisible();
        //         }
        //         isVisible = true;
        //     }
        //     if (!rend.isVisible){
        //         if (isVisible){
        //             OnBecameInvisible();
        //         }
        //         isVisible = false;
        //     }
        // }
        Vector2 rtPos = new Vector2(Screen.width, Screen.height);
        rtPos = Camera.main.ScreenToWorldPoint(rtPos);
        if (transform.position.x < rtPos.x){
            if (!isVisible){
                OnBecameVisible();
            }
            isVisible = true;
        }

        Vector2 ltPos = new Vector2(0, Screen.height);
        ltPos = Camera.main.ScreenToWorldPoint(ltPos);
        if (transform.position.x < ltPos.x){
            if (isVisible){
                OnBecameInvisible();
            }
            isVisible = false; 
        }
    }
}
