using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_RigidbodyBackup : MonoBehaviour
{
    Vector2 _Movement;
    Rigidbody2D _Rigidbody;
    float maxDist = 10f;
    [SerializeField] int _speed = 1;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {

        if ((value.Get<Vector2>().x >= 0.5 && value.Get<Vector2>().x < 1) || (value.Get<Vector2>().x > -1 && value.Get<Vector2>().x <= -0.5))
        {
            _Rigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }

        else
            _Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        //_Rigidbody.transform.forward = value.Get<Vector2>();
        _Movement = value.Get<Vector2>();


        if (value.Get<Vector2>().x == 1)
            _Rigidbody.SetRotation(-90);
        else if (value.Get<Vector2>().x == -1)
            _Rigidbody.SetRotation(90);
        else if (value.Get<Vector2>().y == 1)
            _Rigidbody.SetRotation(0);
        else if (value.Get<Vector2>().y == -1)
            _Rigidbody.SetRotation(180);



    }

    private void FixedUpdate()
    {
        _Rigidbody.velocity = _Movement * _speed;

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

}
