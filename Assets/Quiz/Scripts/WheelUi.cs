using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class WheelUi : MonoBehaviour
{
    public List<string> Categories;

    public Transform PlayButton;

    public Transform Wheel;

    public int AmountRotations;

    public float RotateDuration;

    public void SpinWheel()
    {
        
        float randomAngle = Random.Range(0, 360);
        Debug.Log(GetLandedCategory(randomAngle));
        float rotateAngles = (360 + AmountRotations)+randomAngle;
        Wheel.DOLocalRotate(new Vector3(0, 0, rotateAngles * -1), RotateDuration,RotateMode.FastBeyond360).onComplete+=WheelFinishedRotating;
    }
    private void WheelFinishedRotating()
    {
        PlayButton.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public string GetLandedCategory(float angle)
    {
        var anglePercategory = 360 / Categories.Count;//30
        return Categories[(int)(angle/anglePercategory)];
    }
}
