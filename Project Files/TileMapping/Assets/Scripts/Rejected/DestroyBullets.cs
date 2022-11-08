using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(6.0f);
        while (true)
        {
            Destroy(transform.GetChild(0).gameObject);

            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
}
