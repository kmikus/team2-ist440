using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : MonoBehaviour {

    public TimeManager tm;

    public float levelCompletionBonus = 1000f;
    public float timeLeftBonusMultiplier = 3f;

    public void addLevelCompletionBonus() {
        Scoring.increaseScore(levelCompletionBonus);
    }

    public void addRemainingTimeBonus() {
        var startTime = GetComponent<LevelTimer>().amountOfTime;
        var elapsedTime = tm.TimeElapsed;

        var remainingTime = startTime - elapsedTime;

        Scoring.increaseScore(Mathf.Round(timeLeftBonusMultiplier * remainingTime));
    }
}
