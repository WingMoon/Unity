using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text achievementText;
    public Text gameoverText;
    public Text LifePointText;
    public Text scoreText;
    private Rigidbody rb;
    private int count;
    private int LifePoint;
    private int score;
    private int TotalCount;
    private int TotalLifePoint;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();  
        count = 0;
        LifePoint = 10;
        SetCountText();
        SetLifePointText();
        winText.text = "";
        achievementText.text = "";
        gameoverText.text = "";
        scoreText.text = "";
    }
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;           
            SetCountText();
        }
        if (other.gameObject.CompareTag("Blue"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            LifePoint = LifePoint + 1;
            SetCountText();
            SetLifePointText();
        }
        if (other.gameObject.CompareTag("Final Collection"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            LifePoint = LifePoint + 1;
            SetCountText();
            SetLifePointText();
            SetscoreText();
            winText.text = "VICTORY";            
            speed = 0;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Garbage"))
        {   
            LifePoint = LifePoint - 1;            
            SetLifePointText();            
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count;
        if (count >= 70)
        {
            achievementText.text = "You Got An Achievement!";
        }
    }
    void SetLifePointText()
    {
        LifePointText.text = "Life Point: " + LifePoint;
        if (LifePoint == 0)
        {
            gameoverText.text = "o(QAQ)o Game Over o(QAQ)o";
            SetscoreText();
        }
    }
    void SetscoreText()
    {
        TotalCount = count * 100;
        TotalLifePoint = LifePoint * 1000;
        score = TotalCount+ TotalLifePoint;
        scoreText.text = "Score: " + score;
    }
}