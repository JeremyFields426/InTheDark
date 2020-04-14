using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(IHaveUsableItemInput))]
public class Lantern : EquippableItem
{
    [SerializeField] private Light2D lanternLight = null;


    private void Awake()
    {
        GetComponent<IHaveUsableItemInput>().UseCallback += ToggleLantern;
    }

    private void ToggleLantern()
    {
        if (UserState.IsBusy) { return; }

        lanternLight.gameObject.SetActive(!lanternLight.gameObject.activeSelf);
    }

    public override void OnItemAdded()
    {
        
    }
}
