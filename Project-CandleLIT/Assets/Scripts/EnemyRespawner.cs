using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour {

    public Transform[] enemies;
    public List<int> disabledIndexes;
    private float[] t;
    private bool atLeastOneEnemyDisabled = false;

    public bool respawningOn = true;
    public float respawnTimer = 20f;

	// Use this for initialization
	void Start () {

        t = new float[enemies.Length];

        for (int i = 0; i < enemies.Length; i++) {
            Debug.Log(enemies[i].gameObject.ToString());
            t[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!respawningOn) {
            return;
        }

        if (!atLeastOneEnemyDisabled) {
            return;
        }

        foreach (int index in disabledIndexes) {
            t[index] += Time.deltaTime;
            if (t[index] > respawnTimer) {
                enableEnemyAtIndex(index);
            }
            disabledIndexes.Remove(index);
        }
	}

    public int getIndexOfEnemy(GameObject enemy) {
        for (int i = 0; i < enemies.Length; i++) {
            if (enemy == enemies[i]) {
                return i;
            }
        }

        //return -1 if no enemy is found
        return -1;
    }

    public void disableEnemyAtIndex(int index) {
        if (index > -1 && index < enemies.Length)
        {
            enemies[index].gameObject.SetActive(false);
            atLeastOneEnemyDisabled = true;
            disabledIndexes.Add(index);
        }
        else
        {
            Debug.LogError("Failed to enable enemy: index out of range- " + index);
        }
    }

    public void enableEnemyAtIndex(int index) {
        if (index > -1 && index < enemies.Length)
        {
            enemies[index].gameObject.SetActive(true);
        } else {
            Debug.LogError("Failed to enable enemy: index out of range- " + index);
        }
    }

    public bool areAllEnemiesEnabled() {
        foreach (Transform enemy in enemies) {
            if (!enemy.gameObject.activeSelf) {
                return false;
            }
        }

        return true;
    }
}
