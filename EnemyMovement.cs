using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float rayHitDistance;

    private Vector3 playerLookAtPosition;
    private GameObject player;

    private const string PLAYER = "Player";
    private const string ENEMY = "Enemy";

    private void Start() {
        player = GameObject.FindGameObjectWithTag(PLAYER);
    }

    private void Update() {

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer() {

        ObtainPlayerXZPosition();

        if (!AllyHitCheck()) {

            transform.LookAt(playerLookAtPosition);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if(transform.position.z <= maxDistance) {
            Debug.Log(transform.position);
            Destroy(gameObject);
        }
    }

    private void ObtainPlayerXZPosition() {

        float playerXPosition = player.transform.position.x;
        float playerZPosition = player.transform.position.z;

        playerLookAtPosition = new Vector3(playerXPosition, 0f, playerZPosition);
    }

    private bool AllyHitCheck() {

        if (Physics.Raycast(transform.position + transform.up, transform.forward, rayHitDistance)) {
            return true;
        }
        return false;
    }
}
