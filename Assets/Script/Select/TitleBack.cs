using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBack : MonoBehaviour
{
   public bool isButtonPush = false;


    public void PushTitleBackButton()
    {
        if (isButtonPush == true)
        {
            return;
        }
        isButtonPush = true;
        SceneManager.LoadScene("TitleScene");

    }
}