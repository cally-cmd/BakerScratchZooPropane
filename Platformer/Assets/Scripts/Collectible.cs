using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectible;

    public string text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        print("Collected");
        if (col.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogShow(text);
            print(text);
            Destroy(collectible);
            GameManager.Instance.collection += 1;
        }
    }
}
