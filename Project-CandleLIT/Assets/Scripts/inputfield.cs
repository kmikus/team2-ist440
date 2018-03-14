using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfield : MonoBehaviour {

    public InputField Gname;
    public Text fText;

    public void setget()
    {
        fText.text = "Name: " + Gname.text + " Score: " + Scoring.score;
    }
}
