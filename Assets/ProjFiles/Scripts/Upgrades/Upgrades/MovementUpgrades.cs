using UnityEngine;

public class MovementUpgrades : MonoBehaviour
{

    private PlayerDash dash;

    private bool dashPowMaxed = false;
    private bool dashTimeMaxed = false;

    private void Start()
    {
        dash = PlayerHP.Instance.gameObject.GetComponent<PlayerDash>();
    }
    public void DashPowUpgrade()
    {
        if (dash.maxDashPower > dash.GetDashPower())
        {
            dash.AddDashPower();
            Debug.Log("Dash power boosted");
            UpgradesUiManager.Instance.CloseUI();
            //UpgradesUiManager.Instance.isUpgPressed = true;
        }
        else
        {
            dashPowMaxed = true;
        }

    }
    public void DashTimeUpgrade()
    {
        if (dash.GetTimeToDash() != dash.minTimeToDash)
        {
            dash.ReduceDashTime();
            Debug.Log("Dash time decreased");
            UpgradesUiManager.Instance.CloseUI();
            //UpgradesUiManager.Instance.isUpgPressed = true;
        }
        else
        {
            dashTimeMaxed = true;
        }
    }

    public bool GetDashPowMaxed()
    {
        return dashPowMaxed;
    }
    public bool GetDashTimeMaxed()
    {
        return dashTimeMaxed;
    }
}
