using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
   
   public static GameController Instance {get; private set;}
   float gameHeight = 4.25f;
   float screenWidth = 8.0f;
   public float GameHeight {get{return gameHeight;}}
   public float ScreenWidth {get{return screenWidth;}}

    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float screenOffset = 3.0f;
    public float ScreenOffset {get{return screenOffset;}}
    [SerializeField] GameObject spawnObject;
    [SerializeField] int spawnChance = 1;
    [SerializeField] int maxSpawnChance = 10000;
    int score = 0;
    bool isPlaying = false;
    [SerializeField] float gameTime = 10.0f;
    float remainingTime;


    void Awake(){
    if(Instance != null && Instance != this){
        Destroy(this);
    }
    else{
        Instance = this;

    }
    }
    void Start()
    {
        score = 0;
        remainingTime = gameTime;
        isPlaying = true;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime = remainingTime - Time.deltaTime;
        UpdateUI();
        Debug.Log("Remaining Time: " + (int)remainingTime);
        if(remainingTime<=0.0){
            isPlaying = false;
        }
       
        if(isPlaying){
            if (Random.Range(0, maxSpawnChance)< spawnChance){
            SpawnObject();
        }
        }
        
    }   

    void SpawnObject(){
        Vector3 spawnPosition = new Vector3(
            screenWidth + screenOffset,
            Random.Range(-gameHeight, gameHeight),
            0.0f
        );
        Quaternion SpawnRotation = Quaternion.identity;

        Instantiate(spawnObject, spawnPosition, SpawnRotation);
    
    
    }
    public void UpdateScore(int update){
        score = score + update;
        UpdateUI();
        //Debug.Log("Score: " + score + "Update" + update);
    }
    void UpdateUI(){
        scoreText.text = "Score: " + score.ToString();
        timeText.text = "Time: " + (int)remainingTime;
    }

}