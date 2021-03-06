﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour{
    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    public bool destroyOnDeath;

    public void TakeDamage(int amount){
        if (!isServer){
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0){
            if (destroyOnDeath){
                Destroy(gameObject);
            } else {
                currentHealth = maxHealth;

                // called on the Server, will be invoked on the Clients
                RpcRespawn();
            }
        }
    }

    void OnChangeHealth(int health){
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn(){
        if (isLocalPlayer){
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}
