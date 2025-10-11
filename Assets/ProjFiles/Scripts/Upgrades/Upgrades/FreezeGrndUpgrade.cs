using UnityEngine;

public class FreezeGrndUpgrade : MonoBehaviour
{
    public void FreezeGroundUpgrade()
    {
        Shoot.Instance.gameObject.GetComponent<FreezeThrow>().isAvalible = true;
        Debug.Log("Freeze ground unlocked");
        UpgradesUiManager.Instance.CloseUI();
    }
}
