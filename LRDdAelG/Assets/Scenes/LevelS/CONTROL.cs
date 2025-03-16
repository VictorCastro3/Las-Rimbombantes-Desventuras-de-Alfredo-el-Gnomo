using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CONTROL : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MENU");
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
