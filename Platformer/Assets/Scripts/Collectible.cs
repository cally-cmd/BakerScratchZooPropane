using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectible;

    public GameObject sparkles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D() {
        print("Collected");
        Destroy(collectible);
        GameObject part = Instantiate(sparkles);
        part.transform.position = transform.position;
        GameManager.Instance.collection += 1;
        if (GameManager.Instance.collection == 5) {
            print("The table has been unlocked!");
        }
    }
}
