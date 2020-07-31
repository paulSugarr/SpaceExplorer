using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsExtensions
{
    //public static void AddImpulse(NPCPhysics character, float force, Vector3 direction)
    //{
    //    direction.Normalize();
    //    if (direction.y < 0)
    //    {
    //        direction.y = -direction.y;
    //    }
    //    character.Impact += direction.normalized * force / character.Mass;
    //}

    public static void AddImpulse(IGravity character, float force, Vector3 direction)
    {
        character.AddImapct(force / character.Mass, direction);

    }
}