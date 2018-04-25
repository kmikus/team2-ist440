using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnEnable : MonoBehaviour {

    public Button button;

	private void OnEnable()
    {
        button.Select();
        button.OnSelect(null);
    }
}
