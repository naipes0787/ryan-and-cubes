using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallBehavior : MonoBehaviour
{

    public Text pointsText;
    public Text lifeText;
    public Text finalText;


    private Rigidbody rigibody;
    public float speed;
    private int life;
    private int points;

    void Start()
    {
        this.rigibody = GetComponent<Rigidbody>();
        this.life = 100;
        this.points = 0;
        this.SetPointsText();
        this.SetLifeText();
        this.finalText.text = "";
    }

    void SetPointsText()
    {
        this.pointsText.text = "Points: " + this.points;
        if (this.points == 80)
        {
            this.finalText.text = "Now Ryan has all his cubes, he can... Eeemm... Well, I don't know what he is going to do with them";
        }
    }

    void SetLifeText()
    {
        this.lifeText.text = "Life: " + this.life;
        if (this.life == 0)
        {
            this.finalText.text = "You lose! Now Ryan can't do that really important thing with his cubes!";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        this.rigibody.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Collectable"))
        {
            otherObject.gameObject.SetActive(false);
            this.points += 20;
            this.SetPointsText();
        } else
        {
            if (otherObject.gameObject.CompareTag("Enemy"))
            {
                this.life -= 50;
                if (this.life <= 0)
                {
                    this.life = 0;
                    this.gameObject.SetActive(false);
                }
                this.SetLifeText();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.life -= 50;
            if (this.life <= 0)
            {
                this.life = 0;
                this.gameObject.SetActive(false);
            }
            this.SetLifeText();
        }
    }

}
