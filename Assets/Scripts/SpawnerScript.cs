using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{ 
    public float[] xPositions; //predefined positions where objects will be spawned
    public SpawnWave[] wave;  //creates an array to set amount of objects spawned at a go
    public GameObject[] spawns; //creates an array to place game objects
    public float currentTime;   //current time of the game
    public List<float> remainingPosition = new List<float>();  //Positions that haven't been spawned to
    //public List<float> deletedSpawnPosition = new List<float>();  //used to check the position of the game object on the y axis
    public List<GameObject> toBeDeletedSpawns = new List<GameObject>(); //List of objects to be deleted
    public int waveIndex;
    public float startPosition = 0.67f; //where spawning starts from
    public int rand; //random number
    public GameObject go;
    
    
    void Update()
    {
        currentTime -= Time.deltaTime; //This is a self starting variable. Like a self destruct or self spawn
        if (currentTime <= 0) /*the self spawning starts*/
        {
            SelectWave(); //start spawning game object
        }
        else if (currentTime >= 1.2) /*When the currentTime gets to specified time, spawned objects should be deleted. Standard = 1.2*/
        {
            if (go.transform.position.y == 7)   /*This condition is set to 7 since it is the constant position at y for the spawned objects*/
            {
                for (int i = 0; i < 2; i++)       /*For loop is set so that a maximum amount of objects are deleted from the list at a go*/
                {
                    DeleteSpawns();
                    remainingPosition.RemoveAt(rand);
                }
            }
        }
        else if (toBeDeletedSpawns.Count >= 20) /*When the tobedeletedspawns list is greater than 20, spawned objects should be deleted*/
        {
            if (go.transform.position.y == 7)
            {
                for (int i = 0; i < 12; i++)
                {
                    DeleteSpawns();
                    remainingPosition.RemoveAt(rand);
                }
            }
        }
    }

    void SpawnEnemy(float startPosition) /* Starts the spawning of the cells and viruses*/
    {
        int numbGen = Random.Range(0, 2); // rand generation between the two types of spawns
        go = Instantiate(spawns[numbGen], new Vector2(startPosition, transform.position.y), Quaternion.identity); //when rand number is generated,the instantiation generates with the array no at the start position on x with no effect on y or rotation
        if (true)
        {
            toBeDeletedSpawns.Add(go); //Adding spawned objects to a list
            //deletedSpawnPosition.Add(go.transform.position.y); //Adds the position on the y axis of the spawned object to the list
        }

    }

    public void SelectWave() /*Function at update that allows spawning with each frame rate*/
    {
       remainingPosition.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length); //random generation of numbers between the length of the wave of spawns

        currentTime = wave[waveIndex].spawnTime; //the value of array@i spawn time

        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            SpawnEnemy(startPosition);
            rand = Random.Range(0, remainingPosition.Count);
            startPosition = remainingPosition[rand];
            remainingPosition.RemoveAt(rand); //prevents a position from being repeated  
        }
    }

    private void DeleteSpawns()
    {
        Destroy(toBeDeletedSpawns[0]); //Delete spawned object
        toBeDeletedSpawns.RemoveAt(0); //Empty list
    }
  
}


[System.Serializable] //this makes it possible to give the class exact figures
public class SpawnWave /*class was created to index spawn time and the amount spawned*/
{
    public float spawnTime;
    public float spawnAmount;
}


