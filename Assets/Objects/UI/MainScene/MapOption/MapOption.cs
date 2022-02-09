using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class SlideItemSetting{
    [SerializeField] Vector3 _position;
    [SerializeField] Vector3 _scale;

    public Vector3 position{
        set{ _position = value;}
        get{ return _position;}
    }
    public Vector3 scale{
        set{ _scale = value;}
        get{ return _scale;}
    }
}

public class MapOption : Singleton<MapOption>
{
    private GameObject[] slideItems;
    private int[] settingIndexes;
    public SlideItemSetting[] slideItemsSetting;
    /**
     ** default setting for slide items.
        selected item: 0
        sub visible item: left: 1, right: 2
        invisible item: left: 3, right: 4
    */
    private int count;
    [SerializeField] private int _current, scrollSpeed;
    private bool isScrolling = false;

    public int current{
        get { return _current;}
        set { _current = value;}
    }

    private GameObject notification;

    private void Start() {
        count = transform.childCount;
        slideItems = new GameObject[count];
        settingIndexes = new int[count];
        for (int i = 0; i < count; i++){
            slideItems[i] = transform.GetChild(i).gameObject;
            settingIndexes[i] = 3;
        }
        current = 0;
        notification = GameObject.Find("notification");
    }

    private void Update() {
        if (settingIndexes[current] != 0){
            ApplySettingToSlideItem(current, 0);
            if (current > 0){
                ApplySettingToSlideItem(current-1, 1);
            }
            if (current < count-1){
                ApplySettingToSlideItem(current+1, 2);
            }
            int temp = current - 2;
            while (temp >= 0){
                ApplySettingToSlideItem(temp, 3);
                temp -= 1;
            }
            temp = current + 2;
            while (temp <= count-1){
                ApplySettingToSlideItem(temp, 4);
                temp += 1;
            }
        }
    }

    private void ApplySettingToSlideItem(int idx, int settingIdx){
        if (settingIndexes[idx] != settingIdx){
            settingIndexes[idx] = settingIdx;
            StartCoroutine(TransformPositionIE(idx, settingIdx));
            StartCoroutine(TransformLocalScaleIE(idx, settingIdx));
        }
    }

    IEnumerator TransformPositionIE(int idx, int settingIdx){
        float deltaTime = 0.1f;
        Vector3 src = slideItems[idx].GetComponent<Image>().rectTransform.localPosition;
        Vector3 des = slideItemsSetting[settingIdx].position;
        float delta = des.x - src.x;
        float temp = src.x;
        if (delta != 0){
            while (des.x != temp){
                temp += delta * deltaTime * scrollSpeed;
                if (delta < 0 && temp < des.x){
                    temp = des.x;
                }
                if (delta > 0 && temp > des.x){
                    temp = des.x;
                }
                Vector3 newPos = new Vector3(temp, src.y, src.z);
                slideItems[idx].GetComponent<Image>().rectTransform.localPosition = newPos;
                yield return new WaitForSeconds(deltaTime);
            }
        }
    }

    IEnumerator TransformLocalScaleIE(int idx, int settingIdx){
        float deltaTime = 0.1f;
        Vector3 src = slideItems[idx].transform.localScale;
        Vector3 des = slideItemsSetting[settingIdx].scale;
        float delta = des.x - src.x;
        float temp = src.x;
        if (delta != 0){
            while (des.x != temp){
                temp += delta * deltaTime * 5;
                if (delta < 0 && temp < des.x){
                    temp = des.x;
                }
                if (delta > 0 && temp > des.x){
                    temp = des.x;
                }
                Vector3 newScale = new Vector3(temp, temp, 1);
                slideItems[idx].transform.localScale = newScale;
                yield return new WaitForSeconds(deltaTime);
            }
        }
    }

    public void SlideToRight(){
        if (current > 0 && !isScrolling){
            isScrolling = true;
            StartCoroutine(ActiveScrolling());
            slideItems[current].transform.Find("border_activated").gameObject.SetActive(false);
            current -= 1;
            slideItems[current].transform.SetAsLastSibling();
            slideItems[current].transform.Find("border_activated").gameObject.SetActive(true);
        }
    }

    IEnumerator ActiveScrolling(){
        yield return new WaitForSeconds(0.5f);
        isScrolling = false;
    }

    public void SlideToLeft(){
        if (current < count-1 && !isScrolling){
            isScrolling = true;
            StartCoroutine(ActiveScrolling());
            slideItems[current].transform.Find("border_activated").gameObject.SetActive(false);
            current += 1;
            slideItems[current].transform.SetAsLastSibling();
            slideItems[current].transform.Find("border_activated").gameObject.SetActive(true);
        }
    }

    IEnumerator TurnOfNotificationIE(){
        yield return new WaitForSeconds(1f);
        notification.GetComponent<Text>().enabled = false;
    }
    public void ActiveNotiicationText(){
        notification.GetComponent<Text>().enabled = true;
        StartCoroutine(TurnOfNotificationIE());
    }
}
