using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillEffect : MonoBehaviour
{
    [Header("Skill Efects")]
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    public GameObject Skill4;
    public GameObject Skill5;
    public GameObject Skill6;
    [Header("Skill Transforms")]
    public Transform Skill1Transform;
    public Transform Skill2Transform;
    public Transform Skill3Transform;
    public Transform Skill4Transform;
    public Transform Skill6Transform;

    void Skill1Cast()
    {
        Instantiate(Skill1, Skill1Transform.position, Quaternion.identity);
    }
    void Skill2Cast()
    {
        Instantiate(Skill2, Skill2Transform.position, Quaternion.identity);
    }
    void Skill3Cast()
    {
        Instantiate(Skill3, Skill3Transform.position, Quaternion.identity);
    }

    void Skill6Cast()
    {
        Instantiate(Skill6, Skill6Transform.position, Quaternion.identity);
    }
    void Skill5Cast()
    {
        Vector3 pos = transform.position;
        GameObject HealClone = Instantiate(Skill5, pos, Quaternion.identity);
        HealClone.transform.SetParent(transform);
    }
    void Skill4Cast()
    {
        Vector3 pos = transform.position;
        GameObject ShieldClone = Instantiate(Skill4, pos, Quaternion.identity);
        ShieldClone.transform.SetParent(transform);
    }
}
