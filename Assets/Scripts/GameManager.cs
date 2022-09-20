using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    public int maxPlayers;
    public List<PlayerController> activePlayers = new List<PlayerController>();

    public GameObject playerSpawnEffect;

    private void Awake() 
    {
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

    public void AddPlayer(PlayerController newPlayer)
    {
        if(activePlayers.Count < maxPlayers)
        {
            activePlayers.Add(newPlayer);
            Instantiate(playerSpawnEffect, newPlayer.transform.position, newPlayer.transform.rotation);
        } 
        else 
        {
            Destroy(newPlayer.gameObject);
        }
    }
    
    public void ActivatePlayers()
    {
        foreach(PlayerController player in activePlayers)
        {
            player.gameObject.SetActive(true);
            player.GetComponent<PlayerHealthController>().fillHealth();
        }
    }


    public int CheckActivePlayers()
    {
        int playerAliveCount = 0;

        for(int i = 0; i < activePlayers.Count; i++)
        {
            if(activePlayers[i].gameObject.activeInHierarchy)
            {
                playerAliveCount++;
            }
        }

        return playerAliveCount;
    }

    public void GoToNextArena()
    {

    }
}
