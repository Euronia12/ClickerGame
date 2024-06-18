using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action CallbackUIUpdate;
    public event Action CallbackAutoClick;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUIUpdate()
    {
        CallbackUIUpdate?.Invoke();
    }

    public void OnAutoClick()
    {
        CallbackAutoClick?.Invoke();
    }
}
