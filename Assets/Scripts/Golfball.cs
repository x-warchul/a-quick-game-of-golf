using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using System.Linq.Expressions;
using UnityEngine.SceneManagement;

public class Golfball : MonoBehaviour
{
    private Rigidbody rb;               //golfball's rb
    public float force = 0f;            //force applied to shot
    public Transform PlayerTransform;   //camera transform
    public Transform ArrowScale;        //arrow scale
    private Vector3 forceDirection;     //direction of the shot
    public float forceAcc = 300f;       //rate at which power accumulates for shot
    private Arrow arrow;                //reference to the Arrow
    public bool keyHeld = false;        //bool to determine if shot is being charged
    private Vector3 ScaleChange = new Vector3(0.2f, 0f, 0f);    //rate at which the direction arrow grows based on shot power
    public float stopThreshold = 0.5f;  //float to determine when ball needs to come to absolute stop
    public GameObject Arrow;            //reference to the Arrow GameObject
    public bool ableToShoot = true;     //bool to determine if play can shoot (ball isn't moving)
    public AudioSource golfHit;         //reference to golf ball audiosource

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb is fetched and arrow is given value for scaling purposes
        rb = GetComponent<Rigidbody>();
        arrow = ArrowScale.gameObject.GetComponent<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {

        // Calculate vector the represents the movement from the camera to the ball
        forceDirection = transform.position - PlayerTransform.position;

        // Set the Y value to zero so the arrow is at the same height as the ball
        forceDirection.y = 0f;

        // Normalize (set the length to 1) the vector so we can perform math operations on it
        forceDirection.Normalize();
        if (Input.GetKey(KeyCode.Space))
        {
            //if space is held, shot power grows and the arrow grows to show
            keyHeld = true;
            force += forceAcc * Time.deltaTime;
            arrow.transform.localScale += ScaleChange * Time.deltaTime;
            arrow.DistanceFromBall += 0.1f*Time.deltaTime;
        }

        //if statement to remove arrow while ball is in motion
        if(rb.linearVelocity.magnitude > 0.1f)
        {
           Arrow.SetActive(false);
        }
        else
        {
            Arrow.SetActive(true);
        }

        //if the key is released and the player is able to shoot(ball not moving), then stroke counter goes up and force is applied to the ball
        if (Input.GetKeyUp(KeyCode.Space) && ableToShoot == true)
        {
            golfHit.Play();
            ableToShoot = false;
            keyHeld = false;
            ScoreManager.addStroke();
            rb.AddForce(forceDirection * force);
            force = 0;
        }
        //arrow values are reset as well for the next shot
        if (keyHeld == false)
        {
            arrow.DistanceFromBall = 0.2f;
            arrow.transform.localScale = new Vector3(0.4f, 0.3f, 1);
        }

    }

    public void FixedUpdate()
    {
        //determines when ball needs to come to complete stop
        if(rb.linearVelocity.magnitude < stopThreshold)
        {
            rb.linearVelocity = Vector3.zero;
            ableToShoot = true;
        }
    }

    public Vector3 GetForceDirection()
    {
        return forceDirection;
    }

    void OnTriggerEnter(Collider other)
    {
        //if ball collides with flagpole, plays flagpole's audiosource, moves it out of player view and destroys it once the clip plays
        if (other.CompareTag("Flagpole"))
        {
            other.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(other.GetComponent<AudioSource>());
            other.transform.Translate(0, 100, 0);
            Destroy(other, GetComponent<AudioSource>().clip.length);
            
            //additionally, loads next level or menu if on Level3
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                GoToMainMenu();
            }
            else
            {
                LoadNextLevel();
            }

            ScoreManager.resetStroke();
        }
    }

    void GoToMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
