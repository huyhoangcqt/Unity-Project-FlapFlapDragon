using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    private void OnBecameInvisible() {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
