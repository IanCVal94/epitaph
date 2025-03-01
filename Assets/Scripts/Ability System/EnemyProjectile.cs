using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    [SerializeField] private GameObject target;
    private Enemy enemy;
    private EntityStats stats;
    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        Vector3 rotation = transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot+60);
        enemy = parent.GetComponent<Enemy>();
        stats = enemy.EntityStats;
    }

    protected override void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
            Player player = other.gameObject.GetComponent<Player>();
            enemy.DealDamage(player.GetComponent<Player>(), stats.GetStatValue(StatEnum.ATTACK));
            // Uncomment this to add in status effects when the projectile hits the player
            //var statusEffectManager = player.GetComponent<StatusEffectManager>();
            //    statusEffectManager?.ApplyEffects(_statusEffects);
        }
    }
}
