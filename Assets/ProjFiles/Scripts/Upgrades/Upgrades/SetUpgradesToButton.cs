using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetUpgradesToButton : MonoBehaviour
{


    [Header("Weapon Upgrade buttons")]
    [SerializeField] private GameObject buttonDamage;
    [SerializeField] private GameObject buttonRadius;
    [SerializeField] private GameObject buttonAtkSpeed;

    [Header("Health/Expirience Upgrade buttons")]
    [SerializeField] private GameObject buttonHealth;
    [SerializeField] private GameObject buttonExp;

    [Header("Player Movement Upgrade buttons")]
    [SerializeField] private GameObject buttonDashPow;
    [SerializeField] private GameObject buttonDashTime;

    private int randomSelectedUpg;
    private int rnd;

    private MovementUpgrades movementUpgrades;

    private Dictionary<int, GameObject> upgradeButtonsDict = new Dictionary<int, GameObject>();

    private List<int> types = new List<int>();
    private void Awake()
    {
        types.Add(1); // Weapon Upgrades
        types.Add(2); // Health/Expirience Upgrades
        types.Add(3); // Player Movement Upgrades

        movementUpgrades = gameObject.GetComponentInChildren<MovementUpgrades>();
        SetButtons(); // Setting buttons to dictionary
    }

    private void OnEnable()
    {
        //DisableButtons();
        foreach (var button in upgradeButtonsDict)
        {
            button.Value.SetActive(false);
        }
        SelectUpgType();
        while ((randomSelectedUpg == 301 && movementUpgrades.GetDashPowMaxed()) || (randomSelectedUpg == 302 && movementUpgrades.GetDashTimeMaxed()))
        {
            rnd = Random.Range(1, types.Count);
        }
        upgradeButtonsDict[randomSelectedUpg].SetActive(true);

    }

    /*
    private void DisableButtons()
    {
       for (int i = 101; i <= upgradeButtonsDict.Count; i++)
        {
            if (upgradeButtonsDict[i] == null) { continue; }
            Debug.Log(upgradeButtonsDict[i]);
            upgradeButtonsDict[i].SetActive(false);
        }
    }
    */

    private void SetButtons()
    {
        upgradeButtonsDict.Add(101, buttonDamage);//Weapon Upgrades
        upgradeButtonsDict.Add(102, buttonRadius);
        upgradeButtonsDict.Add(103, buttonAtkSpeed);

        upgradeButtonsDict.Add(201, buttonExp);//Health/Expirience Upgrades
        upgradeButtonsDict.Add(202, buttonHealth);

        upgradeButtonsDict.Add(301, buttonDashPow);//Player Movement Upgrades
        upgradeButtonsDict.Add(302, buttonDashTime);
    }

    private void SelectUpgType()
    {
        rnd = Random.Range(1, types.Count);
        Debug.Log(rnd);
        switch (types[rnd])
        {
            case 1:
                randomSelectedUpg = Random.Range(101,104);
                break;

            case 2:
                randomSelectedUpg = Random.Range(201, 203);
                break;

            case 3:
                randomSelectedUpg = Random.Range(301, 303);
                break;

            default:
                Debug.Log("Error");
                break;
        }
    }


}
