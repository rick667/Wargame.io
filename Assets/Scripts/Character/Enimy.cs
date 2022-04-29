using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : Character
{
    public override Vector3 Move()
    {
        return new Vector3(-velocity, 0, 0);
    }
}
