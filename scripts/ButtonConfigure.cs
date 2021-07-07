using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonConfigure : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Touch()
    {
        PlayerPrefs.SetString("Dokunmak", "evet");
    }
    public void Gyro()
    {
        PlayerPrefs.SetString("Dokunmak", "hayýr");
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
