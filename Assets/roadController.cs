using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadController : MonoBehaviour
{

	public GameObject[] RoadPieces = new GameObject[2];
	public const float RoadLength = 100f; //length of roads

	public float RoadSpeed = 5f; //speed to scroll roads at
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    public GameObject obstaclePrefab4;
    bool isPaused = false;

    bool first = true;


    // Start is called before the first frame update
    void Start()
    {
    	DontDestroyOnLoad(this.gameObject);
        for(int i =10 ; i < 70; i+=10){
               spawnObstacles(i);
            }
     }

    // Update is called once per frame
    void Update()
    {

     foreach (GameObject road in RoadPieces)
    {
        Vector3 newRoadPos = road.transform.position;
        
        newRoadPos.z -= RoadSpeed * Time.deltaTime;
        if (newRoadPos.z < -RoadLength * 0.8f)
        {
            newRoadPos.z += RoadLength*0.8f;
            for(int i =10 ; i < 70; i+=10){
               spawnObstacles(i);
            }
            
            
        }
        road.transform.position = newRoadPos;
    }

    if (Input.GetKeyDown(KeyCode.Escape))
        {
        	if(isPaused){
        		ResumeGame();
        		isPaused = false;
        	}
        	else{
        		 PauseGame();
        		 isPaused = true;
        	}
           

        }
 
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    public void spawnObstacles(int i){
        float [] lrdirections = {-4.0f,0f,3.89f};
        int zdirection = Random.Range(0,50);
        int obstacleSwapindex = Random.Range(20,29);
        int xIndex = Random.Range(0,2);
        int index2 = Random.Range(21,24);
        Transform  spawnPoint = transform.GetChild(obstacleSwapindex).transform;
        GameObject x = Instantiate(transform.GetChild(obstacleSwapindex).gameObject, spawnPoint.position, Quaternion.identity,transform);
        x.transform.position += Vector3.forward * i ;
          }
}
