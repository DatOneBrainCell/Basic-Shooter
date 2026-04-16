using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform bulletShotPosition;

    [Header("Particles")]
    [SerializeField] private ParticleSystem bulletHitParticle;
    [SerializeField] private ParticleSystem bulletShotParticle;

    [Header("Values")]
    [SerializeField] private int damageAmt;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float maxDistance;

    [SerializeField] private LayerMask enemyLayer;

    private RaycastHit enemyHit;
    private Stats enemyStats;

    private float attackTimeCounter = 0f;

    private void Update() {
        
        bool canShootVar = CanShoot();

        if(Input.GetKeyDown(KeyCode.Mouse0) && canShootVar) {

            //gunAnimator.Play(shoot_animation);
            gunAnimator.SetBool("Shot", true);
            Shoot();
            attackTimeCounter = 0f;
        }
    }

    private void Shoot() {

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out enemyHit, maxDistance, enemyLayer)) {

            Instantiate(bulletShotParticle, bulletShotPosition);
            Instantiate(bulletHitParticle, enemyHit.point, enemyHit.transform.rotation);
            enemyStats = enemyHit.transform.GetComponent<Stats>();

            enemyStats.Damage(damageAmt);
        }
    }

    private bool CanShoot() {

        if(attackTimeCounter >= attackCooldown) {

            gunAnimator.SetBool("Shot", false);
            return true;
        }
        attackTimeCounter += Time.deltaTime;
        return false;
    }

    private void OnDrawGizmos() {
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * maxDistance);
    }

}
