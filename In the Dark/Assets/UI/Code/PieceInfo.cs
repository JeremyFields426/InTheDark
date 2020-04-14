using UnityEngine;
using UnityEngine.UI;
using System;

public class PieceInfo
{
    private event Action OnClick;


    public Image Piece { get; private set; }

    public Image Icon { get; private set; }

    public Image Line { get; private set; }

    public Button RemoveButton { get; private set; }


    public PieceInfo(Image piece, Image icon, Image line, Button button, Sprite sprite, Action onClick)
    {
        Piece = piece;
        Icon = icon;
        Line = line;
        RemoveButton = button;

        Piece.transform.SetSiblingIndex(0);
        Icon.transform.SetSiblingIndex(Icon.transform.parent.childCount - 1);
        Line.transform.SetSiblingIndex(Line.transform.parent.childCount - 1);

        Icon.sprite = sprite;
        OnClick += onClick;
    }

    public void InvokeOnClick() => OnClick?.Invoke();
}
