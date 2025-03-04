using StarterAssets;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem hitVFX;
    const string SHOOT = "Shoot";

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

        muzzleFlash.Play();
        starterAssetsInputs.ShootInput(false);
        animator.Play(SHOOT, 0, 0f);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.damage);

            Instantiate(hitVFX, hit.point, Quaternion.identity);        
        }
    }
}
