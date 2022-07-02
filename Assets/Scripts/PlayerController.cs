using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public GameObject laserBullet;
    GameManager gameManager;
    float speed = 20.0f;
    public static float xBound = 5.3f;
    float playerHealth = 2;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        Fire();
        MovePlayer();
        PlayerRestriction();
    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector3(moveHorizontal * speed, 0, 0);
    }
    void PlayerRestriction()
    {
        if (transform.position.x > xBound)
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        if (transform.position.x < -xBound)
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
    }
    void Fire()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(laserBullet, transform.position, laserBullet.transform.rotation);
    }
    void OnTriggerEnter(Collider ship)
    {
        if (ship.gameObject.CompareTag("enemy"))
        {
            playerHealth -= 1;
            gameManager.UpdatePlayerHealth(playerHealth);
            Destroy(ship.gameObject);
            if (playerHealth == 0)
            {
                Destroy(gameObject);
                gameManager.GameOver();
            }

        }
        if (ship.gameObject.CompareTag("big enemy"))
        {
            playerHealth -= 2;
            gameManager.UpdatePlayerHealth(playerHealth);
            Destroy(ship.gameObject);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}