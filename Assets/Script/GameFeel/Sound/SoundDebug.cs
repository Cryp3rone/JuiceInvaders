using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDebug : MonoBehaviour
{
  
    public string soundH;
    public string soundJ;
    public string soundK;

    // Update is called once per frame

   

    void Update()
    {


        if(Input.GetKeyDown("h"))
        {
            MasterSoundManager.instance.Play(soundH);

        }

        if(Input.GetKeyDown("j"))
        {
            MasterSoundManager.instance.Play(soundJ);

        }

        if(Input.GetKeyDown("k"))
        {
            MasterSoundManager.instance.Play(soundK);

        }
    }
}
