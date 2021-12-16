using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{

    public GameObject[] decorationObject = new GameObject[10];

    public void Awake() {
        if (PlayerPrefs.HasKey("cnt")) {
            int cnt = PlayerPrefs.GetInt("cnt");

            for(int i = 0; i < cnt; i++) {
                decorationObject[i].SetActive(true);
            }

            decorateButton.cnt = cnt;
        }
    }
}
