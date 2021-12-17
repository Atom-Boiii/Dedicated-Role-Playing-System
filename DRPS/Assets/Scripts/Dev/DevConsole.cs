using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DevConsole : MonoBehaviour
{
    public string keybind;
    public GameObject view;

    public Scrollbar scrollBar;
    public TMP_InputField commandLine;

    public Transform contentObject;
    public GameObject debugTextObject;

    [SerializeField] private string LOG_PREFIX = "Message";
    [SerializeField] private string ERROR_PREFIX = "ERROR";

    public bool isOpened;

    public static DevConsole instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(keybind != "")
        {
            if (Input.GetKeyDown(keybind))
            {
                view.SetActive(!view.activeSelf);
                isOpened = !isOpened;
            }
        }
        else
        {
            view.SetActive(true);
            ErrorLog("No keybind assigned for Dev Console! Please assign it in the configuration!");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string[] line = commandLine.text.Split(' ');

            #region Message command
            if (line[0] == "message")
            {
                string message = "";

                for (int i = 1; i < line.Length; i++)
                {
                    message += line[i] + " ";
                }

                Log(message);
            }
            #endregion

            #region Error command
            if (line[0] == "error_message")
            {
                string message = "";

                for (int i = 1; i < line.Length; i++)
                {
                    message += line[i] + " ";
                }

                ErrorLog(message);
            }
            #endregion

            #region start
            if(line[0] == "start")
            {
                // Find the mentioned module and activate it
            }
            #endregion
        }
    }

    public void Log(string message)
    {
        GameObject textOBJ = Instantiate(debugTextObject, contentObject);

        string finalMessage = "[" + System.DateTime.Now + "] " + LOG_PREFIX + ": " + message;
        textOBJ.GetComponent<TMP_Text>().text = finalMessage;
        Debug.Log(finalMessage);

        scrollBar.value = 0;
    }

    public void ErrorLog(string message)
    {
        GameObject textOBJ = Instantiate(debugTextObject, contentObject);

        textOBJ.GetComponent<TMP_Text>().color = Color.red;

        string finalMessage = "[" + System.DateTime.Now + "] " + ERROR_PREFIX + ": " + message;
        textOBJ.GetComponent<TMP_Text>().text = finalMessage;
        Debug.LogError(finalMessage);

        scrollBar.value = 0;
    }
}
