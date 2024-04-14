using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource Src;
    public AudioClip game_Impact, game_AddHealthPoints, game_PlusPoints;

    public void GameImpactSFX() 
    {
        Src.clip = game_Impact;
        Src.Play();
    }
    public void GameAddHealthPointsSFX()
    {
        Src.clip = game_AddHealthPoints;
        Src.Play();
    }
    public void GamePlusPointsSFX()
    {
        Src.clip = game_PlusPoints;
        Src.Play();
    }
}
