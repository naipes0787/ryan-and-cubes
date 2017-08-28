using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MixamoController : MonoBehaviour {

	static Animator animator;
	public float velocidadCaminar = 10.0f;
	public float velocidadRotacion = 100.0f;
	private int life;
	private int points;
	public Text pointsText;
	public Text lifeText;
	public Text finalText;

	void Start () {
		animator = GetComponent<Animator> ();
		this.life = 100;
		this.points = 0;
		this.SetPointsText();
		this.SetLifeText();
		this.finalText.text = "";
	}

	public int GetLife(){
		return this.life;
	}

	void SetPointsText()
	{
		this.pointsText.text = "Points: " + this.points;
		if (this.points == 80)
		{
			this.finalText.text = "You Win! Now Ryan has all his cubes, he can... Eeemm... Well, I don't know what he is going to do with them";
			this.StartCoroutine ("WaitFiveSeconds");
		}
	}

	void SetLifeText()
	{
		this.lifeText.text = "Life: " + this.life;
		if (this.life == 0)
		{
			this.SetFinalText("You lose! Now Ryan can't do that really important thing with his cubes!");
			this.StartCoroutine ("WaitFiveSeconds");
		}
	}

	private void SetFinalText(string text){
		this.finalText.text = text;
	}

	IEnumerator WaitFiveSeconds(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene("Menu");
	}

	public void ApplyDamage (int damage){
		this.life -= damage;
	}

	public void ApplyLife (int lifeParameter){
		this.life += lifeParameter;
	}

	void Update() {
		if(life > 0){
			float traslacion = Input.GetAxis("Vertical") * velocidadCaminar;
			float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion;
			transform.Translate(0, 0, traslacion * Time.deltaTime);
			transform.Rotate(0, rotacion * Time.deltaTime, 0);
			/*if (Input.GetButtonDown("Jump")) {
				animator.SetTrigger("isJump");
			}*/
			if (traslacion != 0)
			{
				animator.SetBool("isWalking", true);
				animator.SetBool("isIdle", false);
			}
			else
			{
				animator.SetBool("isWalking", false);
				animator.SetBool("isIdle", true);
			}
		}
	}

	void OnTriggerEnter(Collider otherObject)
	{
		if (life > 0) {
			if (otherObject.gameObject.CompareTag ("Collectable")) {
				otherObject.gameObject.SetActive (false);
				this.points += 20;
				this.SetPointsText ();
			} else {
				if (otherObject.gameObject.CompareTag ("Enemy")) {
					this.life -= 50;
					if (this.life <= 0) {
						this.life = 0;
					}
					this.SetLifeText ();
				}
			}
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (life > 0) {
			if (collision.gameObject.CompareTag ("Enemy")) {
				this.life -= 50;
				if (this.life <= 0) {
					this.life = 0;
					this.gameObject.SetActive (false);
				}
				this.SetLifeText ();
			}
		}
	}

}
