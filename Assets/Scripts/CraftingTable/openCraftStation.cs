﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCraftStation : MonoBehaviour
{
    public GameObject craftInterface;
    public static bool isCraftInterfaceOpen = false;

    public delegate void OnUpdateUIDelegate();
    public static OnUpdateUIDelegate updateUIDelegate;


    public static openCraftStation instance;
    #region singleton


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("plus d'une instance de sam trouvé");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        craftInterface.SetActive(false);
    }
    #endregion


    private void Update()
    {
        if ((Input.GetButtonDown("Close") || Input.GetKeyDown("z") || Input.GetKeyDown("s") || Input.GetKeyDown("q") || Input.GetKeyDown("d"))
             && isCraftInterfaceOpen)
        {
            closeInterface();
        }
    }

    public void openInterface()
    {
        craftInterface.SetActive(true);
        isCraftInterfaceOpen = true;
        updateUIDelegate();
    }

    public void closeInterface()
    {
        craftInterface.SetActive(false);
        isCraftInterfaceOpen = false; 
    }
}
