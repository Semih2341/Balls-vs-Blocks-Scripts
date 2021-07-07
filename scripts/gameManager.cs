using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    new Color color;
    public Text NewScore;
    public Text BestScore;
    public Text Score, Total;
    public GameObject pausemenu;
    public GameObject puan;
    public GameObject PauseButton;
    public GameObject deathmenu;
    public GameObject settings;
    int eskiskor = 0, yeniskor;

    void Start()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gyro.Menüde = false;
        puan.SetActive(true);
        PlayerPrefs.DeleteKey("eskiskor");
        Score.text = 0.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        Score.text = PlayerPrefs.GetInt("eskiskor").ToString();
        if (PlayerPrefs.GetInt("eskiskor") < 0)
        {
            FindObjectOfType<gyro>().TopuPatlat();
            RenderSettings.fogColor = color;
        }
        
    }

    public void Puan(int ballpoint)
    {
        eskiskor=PlayerPrefs.GetInt("eskiskor");
        yeniskor = eskiskor + ballpoint;
        Score.text = yeniskor.ToString();
        YeniDeger(yeniskor);
        
    }
    public void YeniDeger(int a)
    { PlayerPrefs.SetInt("eskiskor", a);
        
    }
    public void pause()
    {
        pausemenu.SetActive(true);
        puan.SetActive(false);
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        gyro.Menüde = true;

    }
    public void Resume()
    {   
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gyro.Menüde = false;
        puan.SetActive(true);
        PauseButton.SetActive(true);

    }
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gyro.Menüde = true;
        puan.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void bitisegidis()
    {
        Invoke("DeathMenu", 0.6f);
    }
    public void ArkaPlan()
    {
        color = new Color(Random.Range(1, 256), Random.Range(1, 256), Random.Range(1, 256));
    }
    public void SettingsMenu()
    {
        pausemenu.SetActive(false);
        settings.SetActive(true);

    }
    public void Back()
    {
        pausemenu.SetActive(true);
        settings.SetActive(false);


    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void DeathMenu()
    {
        deathmenu.SetActive(true);
        PauseButton.SetActive(false);
        NewScore.text = "New Score:"+PlayerPrefs.GetFloat("YeniSkor").ToString("0");
        BestScore.text = "Best Score:"+PlayerPrefs.GetFloat("EskiSkor",0).ToString("0");
    }

}
