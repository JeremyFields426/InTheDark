using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public abstract class CircularMenu : MonoBehaviour
{
    private Vector3 center = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

    private int currentPiece = -1;
    private List<PieceInfo> menuPieces = new List<PieceInfo>();

    [Header("Menu Prefabs")]
    [SerializeField] protected Image menu = null;
    [SerializeField] private Image piecePrefab = null;
    [SerializeField] private Image iconPrefab = null;
    [SerializeField] private Image linePrefab = null;
    [SerializeField] private Button buttonPrefab = null; 

    [Header("Menu Settings")]
    [SerializeField] [Range(125f, 375f)] private float menuRadius = 225f;
    [SerializeField] [Range(1f, 15f)] private float lineThickness = 5f;
    [SerializeField] [Range(25f, 75f)] private float iconSize = 50f;
    [SerializeField] [Range(0.25f, 0.75f)] private float iconDistancePercentage = 0.6f;
    [SerializeField] [Range(1f, 1.5f)] private float buttonPercentage = 1.1f;
    [SerializeField] private Color normalColor = new Color(0f, 0f, 0f);
    [SerializeField] private Color hoverColor = new Color(0f, 0f, 0f);
    [SerializeField] private Color clickColor = new Color(0f, 0f, 0f);


    protected virtual void Update()
    {
        if (Time.timeScale == 0f) { return; }

        if (Mouse.current.leftButton.isPressed)
        {
            StartClick();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            EndClick();
        }
        else
        {
            UpdateCurrentPiece();
        }
    }

    public void UpdateMenu()
    {
        menu.rectTransform.sizeDelta = new Vector2(menuRadius * 2f, menuRadius * 2f);

        for (int i = 0; i < menuPieces.Count; i++)
        {
            float angle = 360f / ((i == 0) ? 1f : ((float) menuPieces.Count / i));

            menuPieces[i].Piece.rectTransform.sizeDelta = new Vector2(menuRadius * 2f, menuRadius * 2f);
            menuPieces[i].Piece.fillAmount = (1f / menuPieces.Count);
            menuPieces[i].Piece.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            menuPieces[i].Piece.color = normalColor;

            menuPieces[i].Icon.rectTransform.sizeDelta = new Vector2(iconSize, iconSize);
            menuPieces[i].Icon.transform.localPosition = (menuPieces.Count == 1) ? Vector3.zero : new Vector3(
                menuRadius * iconDistancePercentage * Mathf.Cos((angle + ((360f / menuPieces.Count) / 2f)) * Mathf.Deg2Rad), 
                menuRadius * iconDistancePercentage * Mathf.Sin((angle + ((360f / menuPieces.Count) / 2f)) * Mathf.Deg2Rad), 
                1f);

            menuPieces[i].RemoveButton.transform.localPosition = new Vector3(
                menuRadius * buttonPercentage * Mathf.Cos((angle + ((360f / menuPieces.Count) / 2f)) * Mathf.Deg2Rad),
                menuRadius * buttonPercentage * Mathf.Sin((angle + ((360f / menuPieces.Count) / 2f)) * Mathf.Deg2Rad),
                1f);

            menuPieces[i].Line.rectTransform.sizeDelta = new Vector2(menuRadius, lineThickness);
            menuPieces[i].Line.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            switch (menuPieces.Count)
            {
                case 1:
                    menuPieces[0].Line.gameObject.SetActive(false);
                    break;
                case 2:
                    menuPieces[0].Line.gameObject.SetActive(true);
                    break;
            }
        }
    }

    protected void AddPiece(Sprite icon, Action onClick, Action onRemove)
    {
        PieceInfo pieceInfo = new PieceInfo(
            ObjectPooler.Create(piecePrefab.gameObject, menu.transform).GetComponent<Image>(),
            ObjectPooler.Create(iconPrefab.gameObject, menu.transform).GetComponent<Image>(),
            ObjectPooler.Create(linePrefab.gameObject, menu.transform).GetComponent<Image>(),
            ObjectPooler.Create(buttonPrefab.gameObject, menu.transform).GetComponent<Button>(),
            icon, onClick);

        menuPieces.Add(pieceInfo);
        onRemove += () => { RemovePiece(pieceInfo); };
        menuPieces[menuPieces.Count - 1].RemoveButton.onClick.AddListener(() => { onRemove?.Invoke(); });

        UpdateMenu();
    }

    public void RemovePiece(PieceInfo pieceInfo)
    {
        Destroy(pieceInfo.Piece.gameObject);
        Destroy(pieceInfo.Icon.gameObject);
        Destroy(pieceInfo.Line.gameObject);
        Destroy(pieceInfo.RemoveButton.gameObject);

        menuPieces.Remove(pieceInfo);

        UpdateMenu();
    }

    private void UpdateCurrentPiece()
    {
        int newIndex = GetCurrentPiece();

        if (currentPiece != newIndex)
        {
            if (0 <= currentPiece && currentPiece < menuPieces.Count)
            {
                menuPieces[currentPiece].Piece.color = normalColor;
            }

            if (0 <= newIndex && newIndex < menuPieces.Count)
            {
                menuPieces[newIndex].Piece.color = hoverColor;
            }
        }

        currentPiece = newIndex;
    }

    private int GetCurrentPiece()
    {
        if (center.WithinDistanceOf(Mouse.current.position.ReadValue(), menuRadius))
        {
            float angle = center.Angle(Mouse.current.position.ReadValue());
            if (angle < 0)
            {
                angle += 360f;
            }

            return Mathf.FloorToInt((angle * menuPieces.Count) / 360f);
        }

        return -1;
    }

    private void StartClick()
    {
        if (0 <= currentPiece && currentPiece < menuPieces.Count)
        {
            menuPieces[currentPiece].Piece.color = clickColor;
        }
    }

    private void EndClick()
    {
        if (0 <= currentPiece && currentPiece < menuPieces.Count)
        {
            if (currentPiece == GetCurrentPiece() && menu.gameObject.activeSelf)
            {
                menuPieces[currentPiece].Piece.color = hoverColor;

                menuPieces[currentPiece].InvokeOnClick();
            }
        }
    }
}
