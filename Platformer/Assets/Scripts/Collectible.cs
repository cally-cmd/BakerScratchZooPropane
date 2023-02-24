using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectible;

    public GameObject sparkles;

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
            GameObject part = Instantiate(sparkles);
            part.transform.position = transform.position;
            GameManager.Instance.collection += 1;
        }
        if (GameManager.Instance.collection == 5) {
            print("The table has been unlocked!");
        }
        if (collectible.tag == "Knife") {
            GameManager.Instance.knifeCollected = true;
        }
        if (collectible.tag == "BakingSheet") {
            GameManager.Instance.bakingCollected = true;
        }
    }
}
