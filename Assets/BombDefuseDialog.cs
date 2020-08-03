using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombDefuseDialog : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;
    public GameObject window;

    private bool isOn;

    public void Update()
    {
        if(!isOn)
        {
            return;
        }

        if(this.text.GetComponent<TextMeshProUGUI>().text.Equals(GlobalVariables.KeyCode))
        {
            CameraFadeout.Instance.FadeOut();
            PlayerSingleton.Instance.CanPlayerMove = false;
            GameObject.FindGameObjectWithTag("UI_JESPER").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("DialogueCanvas").gameObject.SetActive(false);
        }

        if (PlayerSingleton.Instance.gameObjectInstance.GetComponent<PlayerMovement>().wew.magnitude > 0.1f)
        {
            this.isOn = false;
            text.SetActive(false);
            text2.SetActive(false);
            window.SetActive(false);
            this.text.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            this.text.GetComponent<TextMeshProUGUI>().text = this.text.GetComponent<TextMeshProUGUI>().text.Substring(0, this.text.GetComponent<TextMeshProUGUI>().text.Length - 1);
        }

        if (this.text.GetComponent<TextMeshProUGUI>().text.Length >= 8)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "0";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "1";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "2";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "3";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "4";
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "5";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "6";
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "7";
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "8";
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            this.text.GetComponent<TextMeshProUGUI>().text += "9";
        }
    }

    public void OnActivate()
    {
        this.isOn = true;
        text.SetActive(true);
        text2.SetActive(true);
        window.SetActive(true);
    }
}
