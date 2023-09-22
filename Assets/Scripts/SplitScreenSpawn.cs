using System;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenSpawn : MonoBehaviour
{

    public List<PlayerSpawn> spawnsPlayer = new List<PlayerSpawn>();

    [Serializable]
    public struct PlayerSpawn
    {
        public GameObject PlayerPrefab;
        public Transform SpawnTransform;
    }
        
        // Start is called before the first frame update
    void Start()
    {
        foreach(PlayerSpawn playerSpawn in spawnsPlayer)
        {
            Instantiate(playerSpawn.PlayerPrefab, playerSpawn.SpawnTransform.position, playerSpawn.SpawnTransform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
