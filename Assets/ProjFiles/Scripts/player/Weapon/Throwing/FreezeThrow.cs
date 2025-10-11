using UnityEngine;
using UnityEngine.UI;

public class FreezeThrow : MonoBehaviour
{
    [SerializeField] private GameObject freezePrefab;
    [SerializeField] private Transform  throwPoint;

    [SerializeField] private Image throwBar;
    [SerializeField] private GameObject throwFreezeUI;

    [SerializeField] private float throwPower = 15f;
    [SerializeField] private float throwCd = 10f;
    private float timer = 0;

    public bool isAvalible = false;

    private void Update()
    {
        if (isAvalible)
        {
            timer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.G) && timer <= 0)
            {
                ThrowFreeze();
                timer = throwCd;
            }
            ShowThrowBar();
        }
    }
    private void ThrowFreeze()
    {
        GameObject freezeInstance = Instantiate(freezePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = freezeInstance.GetComponentInChildren<Rigidbody>();
        rb.linearVelocity = throwPoint.forward * throwPower;
    }

    private void ShowThrowBar()
    {
        throwFreezeUI.SetActive(true);
        throwBar.fillAmount = 1 - (timer / throwCd);
    }

}
