using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPlayersChecker : MonoBehaviour {

    public static int numOfPlayers = 1;

    public static void setNumPlayers(int num) {
        Debug.Log(num + " Player mode selected");
        numOfPlayers = num;
    }

    public void startSinglePlayer() {
        setNumPlayers(1);
    }

    public void startTwoPlayer() {
        setNumPlayers(2);
    }

}
