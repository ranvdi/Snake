using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Themes")]
    public GameObject Horror;
    public GameObject Fantasy;

    [Header("Menus")]
    public GameObject MainMenu;
    public GameObject ThemeMenu;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject CredistMenu;
    public GameObject HowToMenu;

    public void Start()
    {
        //Time.timeScale= 0f;
    }
    public void StartGame()
    {
        MainMenu.SetActive(false);
        ThemeMenu.SetActive(true);
    }
    public void HorrorTheme()
    {
        ThemeMenu.SetActive(false);
        Horror.SetActive(true);
        GameObject.FindObjectOfType<AudioManager>().playsong("Background2");
        Time.timeScale = 1f;
    }
    public void FantasyTheme() 
    { 
        Fantasy.SetActive(true);
        ThemeMenu.SetActive(false);
        GameObject.FindObjectOfType<AudioManager>().playsong("Background1");
        Time.timeScale = 1f;
    }
    public void OptionsOpen()
    { 
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public void Credist() 
    {
        MainMenu.SetActive(false);
        CredistMenu.SetActive(true);
    }
    public void HowTo() 
    {
        MainMenu.SetActive(false);
        HowToMenu.SetActive(true);
    }
    public void ReturnMenu() 
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CredistMenu.SetActive(false);
        HowToMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void PauseGame() 
    {
            PauseMenu.SetActive(true);
    }
    public void ResumeGame() 
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }




}
