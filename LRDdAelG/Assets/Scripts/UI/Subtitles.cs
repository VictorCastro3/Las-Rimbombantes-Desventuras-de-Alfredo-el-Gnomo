using UnityEngine;
using UnityEngine.UI;


public class Subtitles : MonoBehaviour
{
    [SerializeField] private Text sub;
    [SerializeField]
    private bool Lv1 = false;
    [SerializeField]
    private bool Lv2 = false;
    [SerializeField]
    private bool Lv3 = false;
    [SerializeField]
    private bool end = false;
    [SerializeField]
    private int deathSub = 0;

    private bool chosen1 = false;
    private bool chosen2 = false;
    private bool chosen3 = false;
    private bool chosen4 = false;
    private bool chosen5 = false;

    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        PlayLine(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayLine(bool death)
    {
        if (Lv1)
        {
            if (!death)
            {
                //play audio
                SetSubtitleText("Este es Alfredo el gnomo. Hay dos cosas que deber�as saber de �l. Primero, Alfredo es muy tonto. Segundo, le encanta la tarta. Su objetivo es conseguir la tarta definitiva");
            }
            else
            {
                deathSub = rnd.Next(1, 4);
                if (deathSub == 1 && !chosen1)
                {
                    //play audio
                    SetSubtitleText("Parece que la estupidez de Alfredo es contagiosa, querido jugador");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    //play audio
                    SetSubtitleText("Cu�ntas veces vas a fallar este nivel, Alcornoque?");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    //play audio
                    SetSubtitleText("Ramas y centauros");
                    chosen3 = true;
                }
            }
        }
        else if (Lv2)
        {
            if (!death)
            {
                //play audio
                SetSubtitleText("Hola Alfredo! Soy el b�ho, protector de este bosque. Vengo a decirte que te vayas de mi maldito hogar, est�s disturbando la paz");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    //play audio
                    SetSubtitleText("Tengo una ramada de �rboles militares esperando el momento que salgas de aqu�");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    //play audio
                    SetSubtitleText("Por las barbas de- *Suena un golpe con un bate* -Otra persona: (en gallego) �C�mo puede ser posible que seas tan malo en esto? He visto cabras pensar m�s que t�!");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    //play audio
                    SetSubtitleText("He tra�do a tu madre para convencerte de que te vayas. *Sonidos de gnomo variados*");
                    chosen3 = true;
                }
                else if (deathSub == 4 && !chosen4)
                {
                    //play audio
                    SetSubtitleText("En un lugar de las ramas cuyo nombre no quiero recordar, vivi� Don Alfredo y Sancho tarta");
                    chosen4 = true;
                }
                else if (deathSub == 5 && !chosen5)
                {
                    //play audio
                    SetSubtitleText("Hola, soy Antonio Lorrama. �Quieres saber cu�nto vale tu seta?");
                    chosen5 = true;
                }
            }
        }
        else if (Lv3)
        {
            if (!death)
            {
                //play audio
                SetSubtitleText("Has llegado tan lejos. Tras haberte pasado el gran n�mero de (voz rob�tica) �2�(voz narrador) niveles, �Parece ser que Alfredo ha conseguido encontrar por fin la tarta definitiva!");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    //play audio
                    SetSubtitleText("Marge, �Qu� hago aqu�?�D�nde est� mi cerveza? �Mosquis!");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    //play audio
                    SetSubtitleText("T� t� t�����La casa de las ramas?");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    //play audio
                    SetSubtitleText("A pesar de todos tus fallos, sigues intentando conseguir esta tarta. Se podr�a decir que tienes mucha �determinaci�n� *R�e como sans�");
                    chosen3 = true;
                }
                else if (deathSub == 4 && !chosen4)
                {
                    //play audio
                    SetSubtitleText("Mira la belleza de la artesan�a pastelera que se encuentra a tus vistas. Que pena que nunca podr�s probarlo. S� s�lo no se te fuera tanto de las ramas�");
                    chosen4 = true;
                }
                else if (deathSub == 5 && !chosen5)
                {
                    //play audio
                    SetSubtitleText("Espera un momento. �Es ese Facundo, la mascota de la asociaci�n de la facultad de inform�tica de la universidad complutense de Madrid LAG? �Es incre�ble! Si solo lo pudieras ver");
                    chosen5 = true;
                }
            }



        }
        else if (end)
        {
            //play audio
            SetSubtitleText("Tras finalmente conseguir la tarta definitiva, Alfredo se la come y experimenta un estado de placer gastron�mico que nunca se ha alcanzado y nunca se volver� a alcanzar. Despu�s, vuelve a casa y contin�a con su vida");
        }
    }

    public void SetSubtitleText(string newText)
    {
        sub.text = newText;
    }
}


