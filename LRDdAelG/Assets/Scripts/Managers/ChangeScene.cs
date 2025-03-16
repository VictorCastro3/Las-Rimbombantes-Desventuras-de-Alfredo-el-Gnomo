using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int levelToLoad = 0;

    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collision collision)
    {
        playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>() != null)
            {
                if (levelToLoad == 2)
                {
                    SceneManager.LoadScene("LEVEL 2");
                }
                else if (levelToLoad == 3)
                {
                    SceneManager.LoadScene("LEVEL 3");
                }
                else if (levelToLoad == 4)
                {
                    SceneManager.LoadScene("END");
                }
            }
        }
    }
}
