using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBullet : MonoBehaviour {

    public float speed = 5.0f;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
