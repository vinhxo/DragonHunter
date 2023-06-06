using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillCast : MonoBehaviour
{
    [Header("Mana Settins")]
    public float totalMana = 100f;
    public float manaRegenSpeed = 2f;
    private Image manaBar;

    [Header("Cooldown Icons")]
    public Image[] CooldownIcon;

    [Header("Out Of Mana Icons")]
    public Image[] OutOfManaIcons;

    [Header("Cooldown Times")]
    public float CooldownTime1 = 1f;
    public float CooldownTime2 = 1f;
    public float CooldownTime3 = 1f;
    public float CooldownTime4 = 1f;
    public float CooldownTime5 = 1f;
    public float CooldownTime6 = 1f;

    [Header("Mana Amounts")]
    public float Skill1ManaAmount = 20f;
    public float Skill2ManaAmount = 20f;
    public float Skill3ManaAmount = 20f;
    public float Skill4ManaAmount = 20f;
    public float Skill5ManaAmount = 20f;
    public float Skill6ManaAmount = 20f;

    [Header("Requierd level")]
    public int Skill1 = 1;
    public int Skill2 = 2;
    public int Skill3 = 3;
    public int Skill4 = 4;
    public int Skill5 = 5;
    public int Skill6 = 1;

    private bool faded = false;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0, };

    [HideInInspector] public List<float> CooldownTimesList = new List<float>();

    private List<float> ManaAmountList = new List<float>();

    private List<int> LevelList = new List<int>();

    private Animator anim;

    private bool canAttack = true;

    private PlayerOnClick playerOnClick;

    private LevelManager levelManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerOnClick = GetComponent<PlayerOnClick>();
        manaBar = GameObject.Find("ManaOrb").GetComponent<Image>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {
        AddList();
    }
    void AddList()
    {
        //CoolDownListAdd
        CooldownTimesList.Add(CooldownTime1);
        CooldownTimesList.Add(CooldownTime2);
        CooldownTimesList.Add(CooldownTime3);
        CooldownTimesList.Add(CooldownTime4);
        CooldownTimesList.Add(CooldownTime5);
        CooldownTimesList.Add(CooldownTime6);
        //ManaAmountList
        ManaAmountList.Add(Skill1ManaAmount);
        ManaAmountList.Add(Skill2ManaAmount);
        ManaAmountList.Add(Skill3ManaAmount);
        ManaAmountList.Add(Skill4ManaAmount);
        ManaAmountList.Add(Skill5ManaAmount);
        ManaAmountList.Add(Skill6ManaAmount);
        //LevelList
        LevelList.Add(Skill1);
        LevelList.Add(Skill2);
        LevelList.Add(Skill3);
        LevelList.Add(Skill4);
        LevelList.Add(Skill5);
        LevelList.Add(Skill6);
    }


    void Update()
    {
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
        if (anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            TurnThePlayer();
        }
        if (totalMana < 100f)
        {
            totalMana += Time.deltaTime * manaRegenSpeed;
            manaBar.fillAmount = totalMana / 100f;
        }
        CheckLevel();
        CheckMana();
        CheckToFade();
        CheckInput();
    }
    void CheckInput()
    {
        if (anim.GetInteger("Attack") == 0)
        {
            playerOnClick.FinishedMovement = false;

            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                playerOnClick.FinishedMovement = true;
            }

        }

        //Skill Input
        if (Input.GetKeyDown(KeyCode.A) && totalMana >= Skill1ManaAmount && levelManager.Level >= Skill1)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                totalMana -= Skill1ManaAmount;
                fadeImages[0] = 1;
                anim.SetInteger("Attack", 1);
                playerOnClick.CanMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && totalMana >= Skill2ManaAmount && levelManager.Level >= Skill2)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                totalMana -= Skill2ManaAmount;
                fadeImages[1] = 1;
                anim.SetInteger("Attack", 2);
                playerOnClick.CanMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && totalMana >= Skill3ManaAmount && levelManager.Level >= Skill3)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                totalMana -= Skill3ManaAmount;
                fadeImages[2] = 1;
                anim.SetInteger("Attack", 3);
                playerOnClick.CanMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q) && totalMana >= Skill4ManaAmount && levelManager.Level >= Skill4)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                totalMana -= Skill4ManaAmount;
                fadeImages[3] = 1;
                anim.SetInteger("Attack", 4);
                playerOnClick.CanMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && totalMana >= Skill5ManaAmount && levelManager.Level >= Skill5)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                totalMana -= Skill5ManaAmount;
                fadeImages[4] = 1;
                anim.SetInteger("Attack", 5);
                playerOnClick.CanMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && totalMana >= Skill6ManaAmount && levelManager.Level >= Skill6)
        {
            playerOnClick.TargetPosition = transform.position;
            if (playerOnClick.FinishedMovement && fadeImages[5] != 1 && canAttack)
            {
                totalMana -= Skill6ManaAmount;
                fadeImages[5] = 1;
                anim.SetInteger("Attack", 6);
                playerOnClick.CanMove = false;
            }
        }
        else
        {
            anim.SetInteger("Attack", 0);
        }
    }
    void CheckToFade()
    {
        for (int i = 0; i < CooldownIcon.Length; i++)
        {
            if (fadeImages[i] == 1)
            {
                if (FadeAndWait(CooldownIcon[i], CooldownTimesList[i]))
                {
                    fadeImages[i] = 0;
                }
            }

        }
    }

    bool FadeAndWait(Image fadeImage, float fadeTime)
    {
        faded = false;
        if (fadeImage == null)
        {
            return faded;
        }
        if (!fadeImage.gameObject.activeInHierarchy)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.fillAmount = 1f;
        }
        fadeImage.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImage.fillAmount <= 0f)
        {
            fadeImage.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }

    void CheckMana()
    {
        for (int i = 0; i < OutOfManaIcons.Length; i++)
        {
            if (levelManager.Level >= LevelList[i])
            {
                if (totalMana < ManaAmountList[i])
                {
                    OutOfManaIcons[i].gameObject.SetActive(true);
                }
                else
                {
                    OutOfManaIcons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    void CheckLevel()
    {
        for (int i = 0; i < OutOfManaIcons.Length; i++)
        {
            if (levelManager.Level < LevelList[i])
            {
                OutOfManaIcons[i].gameObject.SetActive(true);
            }
        }
    }

    void TurnThePlayer()
    {
        Vector3 targetPos = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - transform.position),
            playerOnClick.turnSpeed * Time.deltaTime);
    }
}