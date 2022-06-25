using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AShootFactory 
{
    public virtual AShoot CreateShoot()
    {
        return new AShoot();
    }
}
