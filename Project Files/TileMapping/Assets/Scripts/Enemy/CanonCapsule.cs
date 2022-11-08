using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CanonCapsule : MonoBehaviour
{
    GameObject targetPlayer;

    [SerializeField] ProjectileBehvaiour ProjectilePrefab;
    [SerializeField] Transform LauchOffset;
    [SerializeField] Transform Projectiles;
    [SerializeField] float bulltSpawnTimeMin;
    [SerializeField] float bulltSpawnTimeMax;
    float bulltSpawnTime;


    private void Awake()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        //Projectiles = GameObject.Find("Bullets").transform;
    }

    void Start()
    {
        StartCoroutine("SpawnBullt");
    }


    void Update()
    {
        LookAt2D(targetPlayer.transform.position);
    }

    void LookAt2D(Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator SpawnBullt()
    {
        while (true)
        {
            bulltSpawnTime = Random.Range(bulltSpawnTimeMin, bulltSpawnTimeMax);
            yield return new WaitForSecondsRealtime(bulltSpawnTime);
            //Instantiate(ProjectilePrefab, LauchOffset.position, transform.rotation, Projectiles);
            Instantiate(ProjectilePrefab, LauchOffset.position, transform.rotation);
        }
    }
}
