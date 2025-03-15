using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
   
    [SerializeField] private Vector4[] waypoints;


   

    //Indica el momento en el que empezaste a moverte hacia el waypoint n / acabaste de moverte hacia el waypoint n-1.
    private float _lastWaypointTime;

    //Indica el waypoint hacia el que me estoy moviendo la plataforma.
    private int _n = 0;
    private Vector2[] speeds;
    //Pos ini de la plataforma


   
    private void Awake()
    {
        //autocompleta las velocidades y/o los tiempos de los waypoints;
        speeds = new Vector2[waypoints.Length];
        AutocompleteWaypoint(waypoints.Length - 1, 0);

        for (int i = 1; i < waypoints.Length; i++)
        {
            AutocompleteWaypoint(i - 1, i);
        }

        ResetPlatform();


    }
    private void FixedUpdate()
    {
        if (waypoints[_n].w == 0)
        {
            transform.position = new Vector2(waypoints[_n].x, waypoints[_n].y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[_n], Time.fixedDeltaTime * waypoints[_n].w);
        }
        if (Time.fixedTime > _lastWaypointTime + waypoints[_n].z)
        {
            if (_n + 1 < waypoints.Length) _n++;
            else _n = 0;
            _lastWaypointTime = Time.fixedTime;
        }

    }

   
    public Vector2 getVel()
    {
        return speeds[_n];
    }
    //reinicia la plataforma a su posición inicial.
    public void ResetPlatform()
    {
        _n = 0;

        //Va al waypoint inicial
        transform.position = waypoints[0];
        /*
          Hace que el momento en el que hayas acabado de moverte hacia el waypoint inicial sea el actual => 
          => en el siguiente FixedUpdate empezará a moverse al siguiente waypoint (el número 1) 
        */
        _lastWaypointTime = Time.fixedTime;
        //Suma 1 a n para que se empiece a mover hacia el waypoint 1;
        if (waypoints.Length > 1) _n++;
    }
   



    
    
    private void AutocompleteWaypoint(int posPrev, int pos)
    {
        if (waypoints[pos].z == 0)
        {
            if (waypoints[pos].w != 0)
            {
                waypoints[pos].z = Vector2.Distance(waypoints[posPrev], waypoints[pos]) / waypoints[pos].w; // tiempo = espacio / velocidad
            }
        }
        else
        {

            waypoints[pos].w = Vector2.Distance(waypoints[posPrev], waypoints[pos]) / waypoints[pos].z; // velocidad = espacio / tiempo


            if (waypoints[pos].w != 0) Debug.Log("Cuidado: Tiempo(z) y Velocidad(w) de la plataforma móvil no deben ser manipuladas a la vez");

        }
        speeds[pos].x = (waypoints[pos].x - waypoints[posPrev].x) / waypoints[pos].z;
        speeds[pos].y = (waypoints[pos].y - waypoints[posPrev].y) / waypoints[pos].z;


    }
    
}
