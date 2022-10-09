using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string TagOfCollision = collision.gameObject.tag;

        switch (TagOfCollision)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Ground":
                Destroy(gameObject);
                break;

            case "Player":
                Destroy(gameObject);
                break;
        }

    }
}
