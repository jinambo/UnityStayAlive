using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class BonusText : MonoBehaviour {
    public float timeToLive = 2f;
    public float elapsedTime = 0.0f;
    public float floatSpeed = 0.5f;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshPro textMesh;
    RectTransform rTransform;

    // Start is called before the first frame update
    void Start() {
        textMesh = GetComponent<TextMeshPro>();
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        rTransform.localScale = new Vector3(1, 1, 1);
        // rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        if (elapsedTime > timeToLive) Destroy(gameObject);
    }
}
