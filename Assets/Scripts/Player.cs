using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    private float movingSideways;
    private float speed;
    private float tilt;

	// Use this for initialization
	void Start () 
    {

	}

    void FixedUpdate() // Naudojama viskam kas susiije su fizika
    {
        if(gameObject.transform.GetComponentInChildren<Ship>() != null)
        {
            speed = gameObject.transform.GetComponentInChildren<Ship>().speed;
            tilt = gameObject.transform.GetComponentInChildren<Ship>().tilt;
        }

        float horizontalMovement = Input.GetAxis("Horizontal"); // Gaunama reiksme, jei spaudzia i kaire nueina iki -1 jei i desine iki 1
        float verticalMovement = Input.GetAxis("Vertical");

        //transform.position += new Vector3(horizontalMovement * speed * Time.deltaTime, verticalMovement * speed * Time.deltaTime, transform.position.z);

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);
        transform.GetComponent<Rigidbody>().velocity = movement * speed;

        if (horizontalMovement < 0 && movingSideways > -10) movingSideways--; // Cia reikalinga del pasisukimo kai judama i kuria nors puse
        else if (horizontalMovement > 0 && movingSideways < 10) movingSideways++;
        else if (movingSideways < 0 && horizontalMovement == 0) movingSideways++;
        else if (movingSideways > 0 && horizontalMovement == 0) movingSideways--;
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, movingSideways * -tilt, 0.0f);


        GetComponent<Rigidbody>().position = new Vector3 // Cia yra nustatomos ribos, kad negaletu isskristi uz ekrano
        (
            Mathf.Clamp(transform.position.x, -8f, 8f), // Nustato kad laivas negaletu palikt ribu
            Mathf.Clamp(transform.position.y, -3.5f, 5f),
            transform.position.z
        );

    }
}
