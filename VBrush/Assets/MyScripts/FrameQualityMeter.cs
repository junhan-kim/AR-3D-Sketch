using UnityEngine;
using UnityEngine.UI;

public class FrameQualityMeter : MonoBehaviour
{
    Image Low;
    Image Med;
    Image High;

    void Start()
    {
        Low = transform.Find("Low").GetComponent<Image>();
        Med = transform.Find("Med").GetComponent<Image>();
        High = transform.Find("High").GetComponent<Image>();
    }

    void SetMeter(Color low, Color med, Color high)
    {
        Low.color = low;
        Med.color = med;
        High.color = high;
    }

    public void SetQuality(Vuforia.ImageTargetBuilder.FrameQuality quality)
    {
        switch (quality)
        {
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE):
                SetMeter(Color.gray, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW):
                SetMeter(Color.red, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM):
                SetMeter(Color.red, Color.yellow, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH):
                SetMeter(Color.red, Color.yellow, Color.green);
                break;
        }
    }
}
