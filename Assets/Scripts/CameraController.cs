using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Se inicializa el offset
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Por cada frame la cámara se va a mover de acuerdo al movimiento del player.
    // Se utiliza LateUpdate para que se ejecute luego de que todos los objetos fueron 
    // procesados.
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
