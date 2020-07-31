using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGravity
{
    void Gravity();
    void Impacts();

    void AddImapct(float impact, Vector3 direction);
    float Mass { get; set; }
}

