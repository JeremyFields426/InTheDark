using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public static class MiscExtensions
{
    public static float GetAnimationLength(this Animator animator, string animationName)
    {
        RuntimeAnimatorController animatorController = animator.runtimeAnimatorController;
        for (int i = 0; i < animatorController.animationClips.Length; i++)
        {
            if (animatorController.animationClips[i].name == animationName)
            {
                return animatorController.animationClips[i].length;
            }
        }

        return 0f;
    }

    public static GameObject GetGameObjectUnderMouse(this Camera camera)
    {
        Vector3 circlePosition = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        circlePosition.z = 0f;

        Collider2D target = Physics2D.OverlapCircle(circlePosition, 0.01f);

        if (target != null)
        {
            return target.gameObject;
        }

        return null;
    }

    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);

            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    public static void Shuffle<T>(this T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);

            (arr[i], arr[rand]) = (arr[rand], arr[i]);
        }
    }
}
