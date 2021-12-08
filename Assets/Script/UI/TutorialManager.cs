using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    private int INDEX = -1;
    public GameObject canvas; //StepParent;
    private int childCount;
    // Start is called before the first frame update
    void Start()
    {
        childCount = canvas.transform.childCount;
        if ( childCount < 0){
            Debug.LogWarning("Don't have any tutorial step!");
        }
        else {
            for (int idx = 0; idx < childCount; idx++){
                canvas.transform.GetChild(idx).gameObject.SetActive(false);
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {   
        // childCount = canvas.transform.childCount;
        if (0 <= INDEX && INDEX < childCount){
            canvas.transform.GetChild(INDEX).gameObject.SetActive(true);
        }
    }

    public void SetIndex(int index){
        if (index != INDEX){
            OnChangeIndex(INDEX, index);
        }
    }

    private void OnChangeIndex(int oldIdx, int newIdx){
        if (AvailableIndex(oldIdx)){
            canvas.transform.GetChild(oldIdx).gameObject.SetActive(false);
        }
        if (AvailableIndex(newIdx)){
            canvas.transform.GetChild(newIdx).gameObject.SetActive(true);
        }
        INDEX = newIdx;
    }

    private bool AvailableIndex(int index){
        if (index < 0){
            return false;
        }
        if (index >= canvas.transform.childCount) {
            return false;
        }
        return true;
    }
}
