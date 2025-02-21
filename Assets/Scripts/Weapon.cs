using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] int damage;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damage);
        }

        starterAssetsInputs.ShootInput(false);
    }
}
