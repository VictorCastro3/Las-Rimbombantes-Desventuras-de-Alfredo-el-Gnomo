using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Atributos privados
    private static GameManager _instance;
    private GameObject Player;
    #endregion

    #region Métodos MonoBehaviour
    protected void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        } // if-else somos instancia nueva o no.
    }

    protected void OnDestroy()
    {
        if(this == _instance)
        {
            _instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Instance == null) Debug.Log("LA INSTANCIA\nES FUCKING NULLLLLL");
    }
    #endregion
    public static GameManager Instance
    {
        get
        {
            Debug.Assert(_instance != null);
            return _instance;
        }
    }

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
