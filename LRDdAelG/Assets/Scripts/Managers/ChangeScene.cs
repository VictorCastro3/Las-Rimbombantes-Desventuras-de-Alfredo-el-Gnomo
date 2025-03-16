using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
       NextScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene(int currentScene)
    {
        if (currentScene < 5)
        {
            currentScene++;
        }
        else if (currentScene >= 5)
        {
            currentScene = 1;
        }
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
    }
}
