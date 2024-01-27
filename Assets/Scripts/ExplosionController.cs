using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] float lifetime = 1.25f;
    void Start()
    {
         Destroy(gameObject, lifetime);
        
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
