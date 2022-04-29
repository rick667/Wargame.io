using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public int hp = 1;
    public int velocity = 5;
    public abstract Vector3 Move();

}
