using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisible : MonoBehaviour
{
    private bool _isVisible;
    public bool isVisible{
        get { return _isVisible; }
        set { _isVisible = value; }
    }

    private void OnBecameVisible() {
        isVisible = true;
    }
    private void OnBecameInvisible() {
        isVisible = false;
    }

    public void Awake(){
        isVisible = false;
    }

    private Renderer _renderer;
    public void Start(){
        _renderer = GetComponent<Renderer>();
    }

    public void Update(){
        if (_renderer.isVisible && !_isVisible){
            OnBecameVisible();
        }
        else 
        if (!_renderer.isVisible && _isVisible){
            OnBecameInvisible();
        }
    }
}
