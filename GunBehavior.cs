using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    //[SerializeField] private GameObject arrow;

    [SerializeField] private int damageAmt;
    [SerializeField] private float attackInterval;
    [SerializeField] private float maxDistance;

    [SerializeField] private LayerMask enemyLayer;

    private RaycastHit enemyHit;
    private Stats enemyStats;

    private const string ENEMY = "Enemy";

    private void Start() {

        StartCoroutine(nameof(ShootCoroutine));
    }

    private IEnumerator ShootCoroutine() {

        Debug.Log("Pew0");
        for(int i = 0; i <= 15; i++) {

            Debug.Log("Pew1");

            if (Input.GetKeyDown(KeyCode.Mouse0)) {

                Debug.Log("Pew2");
                Shoot();
                yield return new WaitForSeconds(attackInterval); //YIELD RETURN DOESNT GIVE TIME FOR US TO INPUT ANYTHING
            }
        }
    }

    private void Shoot() {

        Debug.Log("Pew");

        if(Physics.Raycast(transform.position, transform.forward, out enemyHit, maxDistance, enemyLayer)) {

            enemyStats = enemyHit.transform.GetComponent<Stats>();

            enemyStats.Damage(damageAmt);
        }
        
    }
    void OnDrawGizmos() {
        Debug.DrawRay(transform.position, transform.forward * maxDistance);
    }
    //private void Shoot() {

    //    transform.Translate(transform.forward * moveSpeed * Time.deltaTime);

    //    if(transform.position.z > maxDistance) {
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnCollisionEnter(Collision collision) {

    //    if (collision.gameObject.tag == ENEMY) {

    //        Debug.Log("Destroyed " + collision.gameObject + " and " + gameObject);
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}

}
