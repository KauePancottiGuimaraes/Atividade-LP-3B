using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{   
    private bool roundOver;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.ActivatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.CheckActivePlayers() == 1 && !roundOver)
        {
            roundOver = true;

            GameManager.instance.GoToNextArena();
        }
    }
}
