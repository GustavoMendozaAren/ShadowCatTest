using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataSlashDamage : MonoBehaviour
{
    [SerializeField] private GameObject ratAttackObj;

    private void ActiveDeactiveAttackObj()
    {
        ratAttackObj.SetActive(!ratAttackObj.activeSelf);
    }
}
