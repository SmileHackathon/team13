using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorateButton : MonoBehaviour
{

    public GameObject[] decorationObject = new GameObject[10];
    public GameObject normalEffectPrefab;
    public GameObject lastEffectPrefab;
    public GameObject collapseEffectPrefab;
    public static int cnt = 0;

    public void OnClick() {
        decorationObject[cnt].SetActive(true);

        if (cnt < 9) {
            GameObject effect = Instantiate(normalEffectPrefab, decorationObject[cnt].transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            cnt++;
            PlayerPrefs.SetInt("cnt", cnt);
        }
        else {
            GameObject effect = Instantiate(lastEffectPrefab, decorationObject[cnt].transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            
            StartCoroutine("makeNewTree");

            PlayerPrefs.SetInt("cnt", cnt);
        }
    }

    private IEnumerator makeNewTree() {
    yield return new WaitForSeconds(2.0f);
    for(int i = 0; i < 10; i++) {
        decorationObject[i].SetActive(false);
        GameObject effect = Instantiate(collapseEffectPrefab, decorationObject[i].transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }
    cnt = 0;
}
}


