using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    
    float maxDist = 10f;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    float horizontalInput;
    float verticalInput;

    static int AtomicNumber = 1;

    private void OnMovement(InputValue value)
    {
        horizontalInput = value.Get<Vector2>().x;
        verticalInput = value.Get<Vector2>().y;
    }

    private void Update()
    {
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);


        if(movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Debug.Log(transform.position);
    }

    private void OnAttack(InputValue value)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), maxDist);
        if (hit)
        {
            Debug.Log("Hit: " + hit.collider.name); 
            if (hit.transform.gameObject.CompareTag("Enemy"))
                Destroy(hit.transform.gameObject);
        }
    }

    public static void IncreaseElectron()
    {
        AtomicNumber++;
        GameController.instance.IncreaseScore();
    }

    public static void DecreaseElectron()
    {
        AtomicNumber--;
        GameController.instance.DecreaseScore();
        if (AtomicNumber == 0)
            GameController.instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("das");
        if (collision.gameObject.CompareTag("Electron"))
        {
            IncreaseElectron();
            Destroy(collision.gameObject);
            GameController.instance.SpawnElectron();
        }
    }

}
