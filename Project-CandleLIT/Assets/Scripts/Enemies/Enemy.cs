using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

    private GameObject enemyGameObject;
    private float respawnTimer;

    public Enemy(GameObject enemyGameObject) {
        this.enemyGameObject = enemyGameObject;
        this.respawnTimer = 0f;
    }

    public void increaseTimer(float t) {
        respawnTimer += t;
    }

    public void resetTimer() {
        respawnTimer = 0f;
    }

    public GameObject getEnemyGameObject() {
        return this.enemyGameObject;
    }

    public float getRespawnTimer() {
        return this.respawnTimer;
    }
}
