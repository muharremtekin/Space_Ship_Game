using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    public static float score = 0f;
    float speed = 2;
    public float Health;
    public float Point;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        MoveDown();
        DestroyFleeingEnemy();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LaserBullet"))
        {
            Destroy(other.gameObject);
            if (gameObject.CompareTag("enemy"))
            {
                Health -= 5;
                if (Health == 0)
                {
                    Destroy(gameObject);
                    gameManager.updateScore(Point);
                }
            }
            else if (gameObject.CompareTag("big enemy"))
            {
                Health -= 5;
                if (Health == 0)
                {
                    gameManager.updateScore(Point);
                    Destroy(gameObject);
                }
            }
        }
    }
    void DestroyFleeingEnemy()
    {
        if (transform.position.y < -1.0f)
            Destroy(gameObject);
    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
