using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("LEVEL 1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("CREDITS");
    }
        public void LoadControls()
    {
        SceneManager.LoadScene("Controles");
    }
}
