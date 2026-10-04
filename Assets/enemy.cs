

using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        detect();
        attack();
    }

    void detect()
    {
        enemies = null;
        float closestDistance = Mathf.Infinity;

        Rigidbody[] objects = FindObjectsByType<Rigidbody>(FindObjectsSortMode.None);

        foreach (Rigidbody rb in objects)
        {
            if (rb.CompareTag("Player") || rb.CompareTag("Enemy"))
                continue;

            float velocity = rb.linearVelocity.magnitude;

            if (velocity >= speed)
            {
                float distance = Vector3.Distance(transform.position, rb.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    enemies = rb.transform;
                }
            }
        }
    }

    void attack()
    {
        
        if(enemies != null)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            rb.MovePosition
            (Vector3.MoveTowards(
            rb.position,
            enemies.position,
            speed * Time.deltaTime
            ));
        }
        else
            GetComponent<MeshRenderer>().material.color = Color.white;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.health -= 20;
        }
    }
}
