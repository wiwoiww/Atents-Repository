using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float lifeTime = 10.0f;

    private void Awake()
    {
        lifeTime = 10.0f;
        SelfCrush();
    }

    IEnumerator SelfCrush()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(this.gameObject);
    }
}
