using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehvaiour : MonoBehaviour
{
    [SerializeField] float Speed;
    GameObject targetPlayer;

    Vector3 direction, current;

    private void Awake()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        current = transform.position;
        direction = (targetPlayer.transform.position - current).normalized;
    }
    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.DecreaseElectron();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Boundary"))
            Destroy(gameObject);
    }
}
