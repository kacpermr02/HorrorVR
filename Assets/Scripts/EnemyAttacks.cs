using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    public void AttackHitEvent()
    {
        if (target == null) return;
        Debug.Log("attack");
    }
}
