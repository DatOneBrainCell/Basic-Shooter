using Unity.VisualScripting;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    //[SerializeField] private GameObject arrow;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;

    private const string ENEMY = "Enemy";

    private void Update() {

        Shoot();
    }

    private void Shoot() {

        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == ENEMY) {

            Debug.Log("Destroyed " + collision.gameObject + " and " + gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
