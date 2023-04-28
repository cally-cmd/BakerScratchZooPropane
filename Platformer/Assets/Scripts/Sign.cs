using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

  public string text;

  void OnTriggerEnter2D(Collider2D col) {
    print("Enter sign!");
    if (col.gameObject.CompareTag("Player")) {
      GameManager.Instance.DialogShow(text);
      print(text);
    }
  }

  void OnTriggerExit2D(Collider2D col) {
    print("Exit sign!");
    if (col.gameObject.CompareTag("Player")) {
      GameManager.Instance.DialogHide();
      print(text);
    }
  }

}
