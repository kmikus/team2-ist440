using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(selectedObject);
    }
}
