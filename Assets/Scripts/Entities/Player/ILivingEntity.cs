using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntity
{
    public void TakeDamage(float damage);
    public void Die();
}

