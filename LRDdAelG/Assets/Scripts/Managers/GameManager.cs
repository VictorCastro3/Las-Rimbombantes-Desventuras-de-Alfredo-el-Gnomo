using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Atributos privados
    private GameManager instance;
    private GameObject Player;
    #endregion

    #region Métodos MonoBehaviour
    protected void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    protected void OnDestroy()
    {
        if(this == instance)
        {
            instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Métodos públicos
    public void GivePlayer(GameObject player)
    {
        Player = player;
    }

    public GameObject GetPlayer()
    {
        return Player;
    }
    #endregion
}
