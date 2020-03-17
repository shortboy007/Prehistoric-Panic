using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCharacters : MonoBehaviour
{

    /*public GameObject[] characterPrefab;
    public GameObject[] spawnPoints;
    public int maxCharactersOnScreen;
    public int totalCharacters;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int charactersPerSpawn;
    private int charactersOnScreen = 0;
    private float generatedSpawnTime = 0;
    private float currentSpawnTime = 0;

    void Start()
    {
        Invoke("characterSpawn", 2f);
    }
    void characterSpawn()
    {
        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (charactersPerSpawn > 0 && charactersOnScreen < totalCharacters)
            {
                List<int> previousSpawnLocations = new List<int>();
                if (charactersPerSpawn > spawnPoints.Length)
                {
                    charactersPerSpawn = spawnPoints.Length - 1;
                }
                charactersPerSpawn = (charactersPerSpawn > totalCharacters) ? charactersPerSpawn -
                totalCharacters : charactersPerSpawn;
                for (int i = 0; i < charactersPerSpawn; i++)
                {
                    if (charactersOnScreen < charactersOnScreen)
                    {
                        charactersOnScreen += 1;

                        int spawnPoint = -1;

                        while (spawnPoint == -1)
                        {

                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);

                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }

                        GameObject spawnLocation = spawnPoints[spawnPoint];
                        //GameObject character = character[characterPrefab];
                        GameObject characters = Instantiate(character) as GameObject;
                        characters.transform.position = spawnLocation.transform.position;
                    }
                }
            }
        }
    }*/
}
