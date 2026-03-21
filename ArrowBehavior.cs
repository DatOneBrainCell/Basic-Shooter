using Unity.VisualScripting;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    [SerializeField] private float moveSpeed;

    private Collider bulletCollider;

    private void Awake() {
        bulletCollider = GetComponent<Collider>();
    }

    private void Update() {

        Shoot();
    }

    private void Shoot() {

        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);

        //if(bulletCollider.)
    }
}
