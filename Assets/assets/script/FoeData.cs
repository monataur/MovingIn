using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeData : MonoBehaviour
{
    public int foeID;
    public object[] foeArray = new object[99];
    public AudioClip ghostly;
    public AudioClip nights;
    public AudioSource musicSource;

    private void Start()
    {
        MusicID(foeID);
    }

    void MusicID(int id)
    {
        switch (id)
        {
            case 1:
                musicSource.clip = ghostly;
                musicSource.Play();
                break;

            case 2:
                musicSource.clip = nights;
                musicSource.Play();
                break;
        }
    }

    object[] FoeID(int id)
    {
        switch (id)
        {
            case 1:
                foeArray[1] = "Apparition";
                foeArray[2] = "An entity created by a mysterious force.";
                foeArray[3] = 1;
                return foeArray;

            default:
                foeArray[1] = "Bugged!";
                foeArray[2] = "Please report this.";
                foeArray[3] = 2;
                return foeArray;
        }
    }
}
