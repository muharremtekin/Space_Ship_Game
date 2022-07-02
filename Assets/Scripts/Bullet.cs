using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speedLaserBullet = 15.0f;
    void Update()
    {
        MoveBullet();
        DestroyBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speedLaserBullet);
    }
    void DestroyBullet()
    {
        if (transform.position.y > 9)
            Destroy(gameObject);
    }
}