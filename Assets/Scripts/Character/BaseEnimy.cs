using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnimy : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public float velocity = 5;
    private Character enimy;

    // Start is called before the first frame update
    void Start()
    {
        enimy = Factory.GetEnimy();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = enimy.Move();
        
    }
}
