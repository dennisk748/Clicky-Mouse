using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    [SerializeField] private float initialSpeed;
    [SerializeField] private float initialSpeed2;
    [SerializeField] private float torqueRange;
    [SerializeField] private float yPos;
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosion;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        AddForce();
        AddTorque();
        transform.position = SetPosition();
    }

    private void Update()
    {
        if(transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }

    void AddForce()
    {
        rb.AddForce(Vector3.up * Random.Range(initialSpeed, initialSpeed2), ForceMode.Impulse);
    }
    void AddTorque()
    {
        rb.AddTorque(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), 
                    Random.Range(-torqueRange, -torqueRange), ForceMode.Impulse);
    }
    Vector3 SetPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-yPos,yPos), -6);
        return pos;
    }

    private void OnMouseDown()
    {

        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bomb"))
            {
                int value  = gameManager.life - 1;
                gameManager.UpdateLives(value);
                Debug.Log("You clicked a bomb");
            }
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        
    }

}
