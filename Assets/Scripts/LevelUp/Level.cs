using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;
    [SerializeField] private int baseXpNeeded = 1000;
    [SerializeField] private ExperienceBar experienceBar;
    [SerializeField] private UpgradePanelManager upgradePanel;

    [SerializeField] private List<UpgradeData> upgrades;
    private List<UpgradeData> selectedUpgrades;
    private List<UpgradeData> acquiredUpgrades;

    private WeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    private int TO_LEVEL_UP
    {
        get
        {
            return level * baseXpNeeded;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }
    
    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        if (acquiredUpgrades == null) acquiredUpgrades = new List<UpgradeData>();

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                break;
        }
        
        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    internal void AddUpgradesToAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            if (selectedUpgrades == null) selectedUpgrades = new List<UpgradeData>();
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(GetUpgrades(3));
            
            upgradePanel.OpenPanel(selectedUpgrades);
            experience -= TO_LEVEL_UP;
            level += 1;
            experienceBar.SetLevelText(level);
        }
    }

    //return random upgrade
    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
            count = upgrades.Count;
        
        for (int i = 0; i < count; i++)
            upgradeList.Add( upgrades[Random.Range(0, upgrades.Count)] );

        return upgradeList;
    }
}
