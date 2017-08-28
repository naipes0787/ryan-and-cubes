using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    static Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    void Update () {
		float traslacion = (speed*Time.deltaTime);
		transform.Translate(new Vector3(0, 0, traslacion));
		if (traslacion != 0) {
			animator.SetBool("isWalking", true);
		} else {
			animator.SetBool("isWalking", false);
		}
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
			transform.Rotate(0, 180, 0);
        }
    }

    public void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Wall"))
        {
			transform.Rotate(0, 180, 0);
        }
    }


}
