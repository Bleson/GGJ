using UnityEngine;
using System.Collections;

public class PopMovement : MonoBehaviour {

    float addedHorizontalForce = 50.0f;
    float addedVerticalForce = 20.0f;
    public float minVerticalForce = 20.0f;
    public float maxVerticalForce = 20.0f;
    public float minHorizontalForce = 50.0f;
    public float maxBonusHorizontalForce = 50.0f;
    public float rotationSpeed = 2f;
    public float lifeTime = 0.5f;
    public float scale = 1f;

    void Start()
    {
        Invoke("Destroy", lifeTime);
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        //Trying to set it on the top
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);

        //Calculating forces
        addedVerticalForce = Random.Range(minVerticalForce, maxVerticalForce);
        addedHorizontalForce = Random.Range(-maxBonusHorizontalForce, maxBonusHorizontalForce);
        if (addedHorizontalForce > 0)
        {
            addedHorizontalForce += minHorizontalForce;
        }
        else
            addedHorizontalForce -= minHorizontalForce;
        //Adding Forces
        rb.AddForce(transform.right * addedHorizontalForce);
        rb.AddForce(transform.up * addedVerticalForce);
    }

    void Update()
    {
        if (addedHorizontalForce > 0)
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (transform.position.y < -40.0f)
        {
            Destroy(gameObject);
        }

    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
