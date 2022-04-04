using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CertificateIntro : MonoBehaviour
{
    public GameObject FrontStuff;
    public GameObject CertB;
    public GameObject CertA;
    public Texture CertATex;
    public AudioSource flipSnd;
    public AudioSource bleepNo;
    public AudioSource bleepYes;
    public bool isFront = true;
    public Material transMat;
    public Text text;
    public void Flip()
    {
        flipSnd.Play();

        if (isFront == true)
        {
            FrontStuff.SetActive(false);
            CertB.SetActive(true);
            isFront = false;
            Color color = transMat.color;
            color.a = 0;
            transMat.color = color;
        }

        else
        {
            FrontStuff.SetActive(true);
            CertB.SetActive(false);
            isFront = true;
            Color color = transMat.color;
            color.a = 1;
            transMat.color = color;
        }
    }

    public void UpdateName()
    {
        var playerinfo = GameObject.Find("PlayerInfo");

        playerinfo.GetComponent<PlayerInfo>().playerName = text.text;

        if(text.text != "")
        {
            bleepYes.Play();
            Debug.Log(NameCase());
        }
    }

    public string NameCase()
    {
        switch (text.text)
        {
            case "Curtis":
                return "This is going to get confusing.\nProceed anyways?";

            case "Hakkuman":
                return "By the power of greasy hair and fedoras!\nAre you okay with this?";

            case "03012018":
                return "You don't know what you're getting yourself into.\nProceed at your own risk.";

            case "Blu":
                return "Cool, like Blu.\nLet's rock?";

            case "Godfrey":
                return "You'd better run.\nYou'd better take cover.";

            default:
                return $"\"{text.text}\".\nIs this correct?";
        }
    }
}
