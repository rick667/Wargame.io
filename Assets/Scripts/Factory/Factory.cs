using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory 
{
    public static Character GetEnimy()
    {
        return new Enimy();
    }
}
