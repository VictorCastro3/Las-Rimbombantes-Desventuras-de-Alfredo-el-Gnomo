using UnityEngine;
using UnityEngine.UI;


public class Subtitles : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Text sub;
    [SerializeField] private UIManager ui;
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
    private bool first = true;
   


    private System.Random rnd = new System.Random();
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        ui= FindObjectOfType<UIManager>();  
        audioSource = gameObject.AddComponent<AudioSource>();
        if (ui.PlayFirst())
        {
            PlayLine(false);
        }
       
       
    }

  
   
    public void PlayLine(bool death)
    {
        if (Lv1)
        {
            if (!death)
            {
                PlayAudioClip(0);
                SetSubtitleText("Este es Alfredo el gnomo. Hay dos cosas que deber�as saber de �l. Primero, Alfredo es muy tonto. Segundo, le encanta la tarta. Su objetivo es conseguir la tarta definitiva");
            }
            else
            {
                deathSub = rnd.Next(1, 4);
                if (deathSub == 1 && !chosen1)
                {
                    PlayAudioClip(1);
                    SetSubtitleText("Parece que la estupidez de Alfredo es contagiosa, querido jugador");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    /*PlayAudioClip(2);
                    SetSubtitleText("Cu�ntas veces vas a fallar este nivel, Alcornoque?");
                    chosen2 = true;*/
                }
                else if (deathSub == 3 && !chosen3)
                {
                    /*PlayAudioClip(3);
                    SetSubtitleText("Ramas y centauros");
                    chosen3 = true;*/
                }
            }
        }
        else if (Lv2)
        {
            if (!death)
            {
                PlayAudioClip(4);
                SetSubtitleText("Hola Alfredo! Soy el b�ho protector de este bosque. Vengo a decirte que te vayas de mi maldito hogar, est�s disturbando la paz");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    PlayAudioClip(5);
                    SetSubtitleText("Tengo una ramada de �rboles militares esperando al momento en el que salgas de aqu�");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    PlayAudioClip(6);
                    SetSubtitleText("En un lugar de las ramas cuyo nombre no quiero recordar, vivi� Don Alfredo y Sancho tarta");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    PlayAudioClip(7);
                    SetSubtitleText("Hola, soy Plantonio Lorrama. �Quieres saber cu�nto vale tu seta?");
                    chosen3 = true;
                }
                else if (deathSub == 4 && !chosen4)
                {
                    PlayAudioClip(8);
                    SetSubtitleText("T� t� t�����La casa de las ramas?");
                    chosen4 = true;
                }
            }
        }
        else if (Lv3)
        {
            if (!death)
            {
                PlayAudioClip(9);
                SetSubtitleText("Has llegado tan lejos. Tras haberte pasado el gran n�mero de 2 niveles, �Parece que Alfredo por fin divisa la tarta definitiva!");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    PlayAudioClip(10);
                    SetSubtitleText("A pesar de todos tus fallos, sigues intentando conseguir esta tarta. Se podr�a decir que tienes mucha determinaci�n");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    PlayAudioClip(11);
                    SetSubtitleText("La soluci�n no es tan dif�cil. Te est�s llendo por las ramas");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    PlayAudioClip(12);
                    SetSubtitleText("No sabes el palo que me da seguir comentando este nivel");
                    chosen3 = true;
                }
                else if (deathSub == 4 && !chosen4)
                {
                    PlayAudioClip(13);
                    SetSubtitleText("Espera un momento. �Es ese Facundo, la mascota de la asociaci�n de la facultad de inform�tica de la universidad complutense de Madrid LAG? �Es incre�ble! Si solo lo pudieras ver");
                    chosen4 = true;
                }
            }



        }
        else if (end)
        {
            PlayAudioClip(14);
            SetSubtitleText("Tras finalmente conseguir la tarta definitiva, Alfredo se la come y experimenta un estado de placer gastron�mico que nunca se ha alcanzado y nunca se volver� a alcanzar. Despu�s, vuelve a casa y contin�a con su vida");
        }
    }

    public void SetSubtitleText(string newText)
    {
        sub.text = newText;
    }
    private void PlayAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
}


