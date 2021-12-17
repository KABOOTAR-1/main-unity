using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivategameobject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactiavte", Random.Range(3f, 5f));
    }

    void Deactiavte()
    {
        Destroy(gameObject);
    }
    
}
