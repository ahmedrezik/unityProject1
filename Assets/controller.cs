using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class controller : MonoBehaviour
{
   public Rigidbody rb;
   public float jumpAmount = 10;
   public float steerSpeed = 4;
   bool isInvincible = false;
   public GameObject coinAudio;
   public GameObject explosionAudio;
   public GameObject obstacleAudio;
   public GameObject shieldAudio;
   public int score =0;
   int coinsCount=0;
   int ballsCount = 0;
   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI coinsText;
   public TextMeshProUGUI ballsText;
   public GameObject street;
   float timeRemainingInvincible = 5.0f;
   float timeRemainingfast = 0.0f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
    	 if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * steerSpeed);

        }
         if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * steerSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
    }

    if(coinsCount%3==0 && coinsCount > 0){
        isInvincible = true;
        shieldAudio.GetComponent<AudioSource>().Play();
      
    }

    if(isInvincible){
          if (timeRemainingInvincible > 0)
        {
            timeRemainingInvincible -= Time.deltaTime;
            Debug.Log(timeRemainingInvincible);

        }
        if(timeRemainingInvincible <= 0){
            isInvincible = false;
            timeRemainingInvincible = 5.0f;
            shieldAudio.GetComponent<AudioSource>().Pause();
        }

    }
    if(ballsCount%7 == 0 && ballsCount >0){
        roadController speed = street.GetComponent<roadController>();
        speed.RoadSpeed = 15;
        timeRemainingfast = 7.0f;
        
    }  	
     if (timeRemainingfast > 0)
        {
            timeRemainingfast -= Time.deltaTime;
        }
        if(timeRemainingfast <= 0){
        roadController speed = street.GetComponent<roadController>();
        speed.RoadSpeed = 5;
        timeRemainingfast = 0.0f;
        }
}
     private void OnCollisionEnter(Collision colInfo){
        // Bomb Collison
           if(colInfo.collider.CompareTag("IronBalls")){
          obstacleAudio.GetComponent<AudioSource>().Play();
            Debug.Log("Iron Balls");
            Destroy(colInfo.collider.gameObject);
            if(!isInvincible){ 
            score -= 10;
            scoreText.text = ("Score:" + score.ToString());
                }
            
          }

          if(colInfo.collider.CompareTag("Bombs")){
            explosionAudio.GetComponent<AudioSource>().Play();
            if(!isInvincible){
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
          }
          
          else{
            Destroy(colInfo.collider.gameObject);
          }
        }
      
          //Iron Coliiison
         
            if(colInfo.collider.CompareTag("Coins")){
                Debug.Log("Coins");
                Destroy(colInfo.collider.gameObject);
                coinAudio.GetComponent<AudioSource>().Play();
                coinsCount +=1;
                coinsText.text = "Coins:" + coinsCount.ToString();
                score+=15;
                scoreText.text = ("Score:" + score.ToString());         
          }


            if(colInfo.collider.CompareTag("Blue balls")){
                Debug.Log("Blue Balls");
                Destroy(colInfo.collider.gameObject);
                coinAudio.GetComponent<AudioSource>().Play();
                ballsCount +=1;
                ballsText.text = "Blue Balls: " + ballsCount.ToString();
                score += 10;
                scoreText.text = ("Score:" + score.ToString());
          }


          }

        }
          
        

 


