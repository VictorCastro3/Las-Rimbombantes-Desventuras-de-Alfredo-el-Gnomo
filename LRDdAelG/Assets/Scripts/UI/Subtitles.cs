using UnityEngine;
using UnityEngine.UI;


public class Subtitles : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
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
   

    private System.Random rnd = new System.Random();
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayLine(false);
    }

    // Update is called once per frame
   
    public void PlayLine(bool death)
    {
        if (Lv1)
        {
            if (!death)
            {
                PlayAudioClip(0);
                SetSubtitleText("Este es Alfredo el gnomo. Hay dos cosas que deberías saber de él. Primero, Alfredo es muy tonto. Segundo, le encanta la tarta. Su objetivo es conseguir la tarta definitiva");
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
                    SetSubtitleText("Cuántas veces vas a fallar este nivel, Alcornoque?");
                    chosen2 = true;*/
                }
                else if (deathSub == 3 && !chosen3)
                {
                    PlayAudioClip(3);
                    SetSubtitleText("Ramas y centauros");
                    chosen3 = true;
                }
            }
        }
        else if (Lv2)
        {
            if (!death)
            {
                PlayAudioClip(4);
                SetSubtitleText("Hola Alfredo! Soy el búho protector de este bosque. Vengo a decirte que te vayas de mi maldito hogar, estás disturbando la paz");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    PlayAudioClip(5);
                    SetSubtitleText("Tengo una ramada de árboles militares esperando al momento en el que salgas de aquí");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    PlayAudioClip(6);
                    SetSubtitleText("En un lugar de las ramas cuyo nombre no quiero recordar, vivió Don Alfredo y Sancho tarta");
                    chosen2 = true;
                }
                else if (deathSub == 3 && !chosen3)
                {
                    PlayAudioClip(7);
                    SetSubtitleText("Hola, soy Plantonio Lorrama. ¿Quieres saber cuánto vale tu seta?");
                    chosen3 = true;
                }
                else if (deathSub == 4 && !chosen4)
                {
                    PlayAudioClip(8);
                    SetSubtitleText("Tú tú tú………¿La casa de las ramas?");
                    chosen4 = true;
                }
            }
        }
        else if (Lv3)
        {
            if (!death)
            {
                PlayAudioClip(9);
                SetSubtitleText("Has llegado tan lejos. Tras haberte pasado el gran número de 2 niveles, ¡Parece que Alfredo por fin divisa la tarta definitiva!");
            }
            else
            {
                deathSub = rnd.Next(1, 6);
                if (deathSub == 1 && !chosen1)
                {
                    PlayAudioClip(10);
                    SetSubtitleText("A pesar de todos tus fallos, sigues intentando conseguir esta tarta. Se podría decir que tienes mucha determinación");
                    chosen1 = true;
                }
                else if (deathSub == 2 && !chosen2)
                {
                    PlayAudioClip(11);
                    SetSubtitleText("La solución no es tan difícil. Te estás llendo por las ramas");
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
                    SetSubtitleText("Espera un momento. ¿Es ese Facundo, la mascota de la asociación de la facultad de informática de la universidad complutense de Madrid LAG? ¡Es increíble! Si solo lo pudieras ver");
                    chosen4 = true;
                }
            }



        }
        else if (end)
        {
            PlayAudioClip(14);
            SetSubtitleText("Tras finalmente conseguir la tarta definitiva, Alfredo se la come y experimenta un estado de placer gastronómico que nunca se ha alcanzado y nunca se volverá a alcanzar. Después, vuelve a casa y continúa con su vida");
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


