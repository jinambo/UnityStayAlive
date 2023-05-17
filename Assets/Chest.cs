using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus {
  public string Name { get; set; }
  public int Value { get; set; }

  public Bonus(string name, int value) {
    Name = name;
    Value = value;
  }

  public void PrintBonus() {
    Debug.Log($"Bonus: {Name} -> {Value}");
  }
}

public class Chest : MonoBehaviour {
    Animator animator;
    public Bonus ChestBonus { get; set; }
    private string[] bonuses = new string[] { "HP", "Damage", "Speed" };

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    public void GenerateBonus() {
        string name = bonuses[UnityEngine.Random.Range(0, bonuses.Length)];
        int value = UnityEngine.Random.Range(1, 100);

        ChestBonus = new Bonus(name, value);
    }

    public void OpenChest() {
        animator.SetTrigger("open");
    }

    public void DestroyChest() {
        Destroy(gameObject);
    }

}
