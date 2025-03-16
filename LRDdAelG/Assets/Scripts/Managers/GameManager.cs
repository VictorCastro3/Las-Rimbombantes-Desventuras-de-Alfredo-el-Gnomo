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
    private GameObject uimanager;
    private Subtitles sub;
    #endregion

    #region M�todos MonoBehaviour
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
            sub=FindObjectOfType<Subtitles>();
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

    #region M�todos p�blicos
    public void GivePlayer(GameObject player)
    {
        Player = player;
    }
    public ParticleSystem GetPlayerParticleSystem()
    {
        if (Player != null)
        {
            return Player.GetComponent<PlayerMovement>()?.particlesystem;
        }
        Debug.LogWarning("Player no está asignado o no tiene el componente PlayerMovement.");
        return null;
    }


    public GameObject GetPlayer()
    {
        return Player;
    }

    public void GiveUI(GameObject UIManager)
    {
        uimanager = UIManager;
    }

    public GameObject GetUI()
    {
        return uimanager;
    }
    #endregion
    public void RespawnPlayer()
    {
        PlayerSpawn spawnPoint = FindObjectOfType<PlayerSpawn>();
        if (spawnPoint != null && Player != null)
        {
            Player.transform.position = spawnPoint.transform.position;
            Player.transform.rotation = spawnPoint.transform.rotation;
        }
        StopSign[] stopSigns = FindObjectsOfType<StopSign>();
        foreach (StopSign stopSign in stopSigns)
        {
            stopSign.Restart();
        }
        TurnSign[] TurnSigns = FindObjectsOfType<TurnSign>();
        foreach (TurnSign turnSign in TurnSigns)
        {
            turnSign.Reactivate();
        }
        GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Custom");
        foreach (GameObject ground in groundObjects)
        {
            Destroy(ground);
        }
        sub.PlayLine(true);
    }
}
