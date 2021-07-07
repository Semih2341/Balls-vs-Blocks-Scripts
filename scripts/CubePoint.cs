using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CubePoint : MonoBehaviour
{
    int x,c;
    public TMP_Text CubeScore;
    public GameObject KutuPatlama;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("eskiskor")<10&&PlayerPrefs.GetInt("eskiskor")>=0)
        {
            x = Random.Range(1, 11);
        }
        else if (PlayerPrefs.GetInt("eskiskor") < 50 && PlayerPrefs.GetInt("eskiskor") > 10){
            x = Random.Range(10, 51);
        }
        else
        {
            x = Random.Range(50, 101);
        }
        CubeScore.text = x.ToString();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            c = PlayerPrefs.GetInt("eskiskor") - x;
            FindObjectOfType<gameManager>().YeniDeger(c);
            while (x>0)
            {
                Debug.Log("çarpýyor");
                FindObjectOfType<gyro>().CarpmaTrue();
                StartCoroutine(loopDelay());

            }
        Debug.Log("puan0aindi");
        Destroy(gameObject);
            Instantiate(KutuPatlama, transform.position, Quaternion.identity);
            FindObjectOfType<gyro>().CarpmaFalse();
        }

    }
    IEnumerator loopDelay ()
    {
        x -= 1;
        
        yield return new WaitForSeconds(10);
    }
}
