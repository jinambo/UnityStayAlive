using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    // public Array<String> Bonus = new string[] { "Health", "Damage", "Speed" };

    // Start is called before the first frame update
    void Start() { }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
             print("Player opened the case.");
             PlayerController player = collider.GetComponent<PlayerController>();

            if (player != null) {
                // Generate random Bonus from the enum
                // Bonus randomBonus = GenerateRandomBonus();
                // player.OpenChest();
                print("MRDK");
            }
        }
    }
}
