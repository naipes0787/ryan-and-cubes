using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    // Rota un objeto continuamente
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * 2 * Time.deltaTime);
	}
}
