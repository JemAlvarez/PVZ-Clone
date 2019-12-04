using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float dmg = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var zombie = otherCollider.GetComponent<Zombie>();

        if (zombie && health)
        {
            health.DealDmg(dmg);
            Destroy(gameObject);
        }
    }
}
