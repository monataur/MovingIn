using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObject : MonoBehaviour
{
    public enum TurnStatus {PlayerMenu, PlayerSelecting, PlayerAttacking, FoeTalk, FoeAttacking}
    public enum MenuSelection {None, Fire, Item, Flee, Fire2, Item2, Flee2}
    public MenuSelection menuSelect = MenuSelection.None;
    public GameObject menuObject;
    public GameObject menuFireObject;
    public GameObject menuItemObject;
    public GameObject menuFleeObject;
    public Transform pThingy;
    PlayerControls controls;
    private Vector3 velocity = Vector3.zero;
    public float pSmoothSpeed = 0.5f;
    public AudioSource dink;
    public AudioSource nuhUh;
    public AudioSource okBye;
    public AudioSource okProceed;
    public GameObject battleCam;

    private void OnEnable()
    {
        controls.UI.Enable();
    }

    private void OnDisable()
    {
        controls.UI.Disable();
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.UI.Left.performed += ctx => UILeft();
        controls.UI.Right.performed += ctx => UIRight();
        controls.UI.Confirm.performed += ctx => Confirm();
        controls.UI.Back.performed += ctx => Back();
    }

    private void FixedUpdate()
    {
        var fireV2 = new Vector3(-716.07f, -264.3374f, 0);
        var itemV2 = new Vector3(-715.955f, -264.3374f, 0);
        var fleeV2 = new Vector3(-715.84f, -264.3374f, 0);
        var selectV2 = new Vector3(-715.955f, -264.3374f, 0);


        CamUpdate();

        switch (menuSelect)
        {
            case MenuSelection.None:
                menuObject.SetActive(true);
                menuFireObject.SetActive(false);
                menuItemObject.SetActive(false);
                menuFleeObject.SetActive(false);
                selectV2 = itemV2;
                pThingy.position = new Vector3(-715.955f, -264.3374f, 0);
                break;

            case MenuSelection.Fire:
                menuObject.SetActive(false);
                menuFireObject.SetActive(true);
                menuItemObject.SetActive(false);
                menuFleeObject.SetActive(false);
                selectV2 = fireV2;
                pThingy.position = new Vector3(-716.07f, -264.3374f, 0);
                break;

            case MenuSelection.Item:
                menuObject.SetActive(false);
                menuFireObject.SetActive(false);
                menuItemObject.SetActive(true);
                menuFleeObject.SetActive(false);
                selectV2 = itemV2;
                pThingy.position = new Vector3(-715.955f, -264.3374f, 0);
                break;

            case MenuSelection.Flee:
                menuObject.SetActive(false);
                menuFireObject.SetActive(false);
                menuItemObject.SetActive(false);
                menuFleeObject.SetActive(true);
                selectV2 = fleeV2;
                pThingy.position = new Vector3(-715.84f, -264.3374f, 0);
                break;
        }
    }

    public void UILeft()
    {
        dink.Play();
        switch (menuSelect)
        {
            case MenuSelection.None:
                menuSelect = MenuSelection.Fire;
                break;

            case MenuSelection.Fire:
                menuSelect = MenuSelection.Flee;
                break;

            case MenuSelection.Flee:
                menuSelect = MenuSelection.Item;
                break;

            case MenuSelection.Item:
                menuSelect = MenuSelection.Fire;
                break;
        }
    }

    public void UIRight()
    {
        dink.Play();
        switch (menuSelect)
        {
            case MenuSelection.None:
                menuSelect = MenuSelection.Fire;
                break;

            case MenuSelection.Fire:
                menuSelect = MenuSelection.Item;
                break;

            case MenuSelection.Item:
                menuSelect = MenuSelection.Flee;
                break;

            case MenuSelection.Flee:
                menuSelect = MenuSelection.Fire;
                break;
        }
    }

    public void CamUpdate()
    {
        switch (menuSelect)
        {
            case MenuSelection.Fire:
                battleCam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.Default;
                battleCam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookPoly;
                break;

            case MenuSelection.Item:
                battleCam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.Default;
                battleCam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookPoly;
                break;

            case MenuSelection.Flee:
                battleCam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.Default;
                battleCam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookPoly;
                break;

            case MenuSelection.Fire2:
                battleCam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.LowZoomIn;
                battleCam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookFoe;
                break;

            case MenuSelection.Item2:
                battleCam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.LowZoomIn;
                battleCam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookPoly;
                break;
        }
    }

    public void Confirm()
    {
        switch (menuSelect)
        {
            case MenuSelection.Fire:
                menuSelect = MenuSelection.Fire2;
                okProceed.Play();
                break;

            case MenuSelection.Flee:
                okProceed.Play();
                Flee();
                break;

            case MenuSelection.Item:
                okProceed.Play();
                menuSelect = MenuSelection.Item2;
                break;
                
        }
    }

    public void Back()
    {
        switch (menuSelect)
        {
            case MenuSelection.Fire2:
                menuSelect = MenuSelection.Fire;
                okBye.Play();
                break;

            case MenuSelection.Item2:
                menuSelect = MenuSelection.Item;
                okBye.Play();
                break;

            case MenuSelection.Fire:
                nuhUh.Play();
                break;

            case MenuSelection.Item:
                nuhUh.Play();
                break;

            case MenuSelection.Flee:
                nuhUh.Play();
                break;  
        }
    }

    void Flee()
    {
        Debug.Log("You have fled... Woops! Not implemented yet!");
    }
}
