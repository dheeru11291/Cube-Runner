using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float forwordForce;
    public float speed;
    public float maxX;
    bool gameOver = false;
    public Text scoreText;
    int score = 0;
    public GameController gameController;
    public AudioSource collection;
    public AudioSource gameOverSound;
    public GameObject youWin;

    private void Update()
    {
        if (gameOver == false)
        {
            PlayerMOvement();
        }
      
    }
    private void FixedUpdate()
    {
        if (!gameOver)
        {
            ForwordMove();
        }


    }
    void PlayerMOvement()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
        transform.position = pos;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }

    }
    void ForwordMove()
    {
        transform.Translate(0, 0, forwordForce * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="collectable")
        {
            Destroy(other.gameObject);
            IncreamentScore();
            collection.Play();
        }
         else if(other.gameObject.tag == "Finish")
        {
            gameOver = true;
            youWin.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            gameOver = true;
            gameController.GameOver();
            gameOverSound.Play();
        }
    }
    
    void IncreamentScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
