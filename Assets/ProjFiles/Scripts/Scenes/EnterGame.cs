using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterGame : MonoBehaviour
{
    [SerializeField] private GameObject worldsPanel;
    [SerializeField] private List<Button> worldsList;

    [SerializeField] private List<KeyCode> world2CodeSave;
    private List<KeyCode> world2Code = new List<KeyCode>();

    [SerializeField] private List<KeyCode> DataResetCodeSave;
    private List<KeyCode> DataResetCode = new List<KeyCode>();

    private void Start()
    {
        SetList(world2CodeSave, world2Code);
        SetList(DataResetCodeSave, DataResetCode);


    }
    private void Update()
    {
        CheatWorld2();
        CheatDataReset();
        if (PlayerPrefs.GetInt("IsWorld2Enabled") == 0)
        {
            worldsList[1].interactable = false;
        }
        else
        {
            worldsList[1].interactable = true;
        }
    }


    private void CheatWorld2()
    {
        if (world2Code.Count > 0)
        {
            if (Input.GetKeyDown(world2Code[0]))
            {
                world2Code.Remove(world2Code[0]);
            }
        }
        else
        {
            Debug.Log("World 2 Unlocked!");
            PlayerPrefs.SetInt("IsWorld2Enabled", 1);
            worldsList[1].interactable = true;
            SetList(world2CodeSave, world2Code);
        }
    }
    private void CheatDataReset()
    {
        if (DataResetCode.Count > 0)
        {
            if (Input.GetKeyDown(DataResetCode[0]))
            {
                DataResetCode.Remove(DataResetCode[0]);
            }
        }
        else
        {
            Debug.Log("Data Was Reset!");
            PlayerPrefs.DeleteAll();
            SetList(DataResetCodeSave, DataResetCode);
        }
    }

    private void SetList(List<KeyCode> list, List<KeyCode> pasteListHere)
    {
        for (int i = 0; i < list.Count; i++)
        {
            pasteListHere.Add(list[i]);
        }
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
}
