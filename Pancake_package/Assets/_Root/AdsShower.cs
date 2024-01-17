using Pancake.Monetization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AdsShower : MonoBehaviour
{
    [FormerlySerializedAs("interstatialBtn")] [SerializeField] private Button interstitialBtn;
    [SerializeField] private Button rewardedBtn;

    [FormerlySerializedAs("interads")] [SerializeField] private AdUnitVariable interstitialads;
    [SerializeField] private AdUnitVariable rewardedads;
    [SerializeField] private TextMeshProUGUI result;
    
    // Start is called before the first frame update
    void Start()
    {
        rewardedBtn.onClick.AddListener(OnRewardBtnClick);
        interstitialBtn.onClick.AddListener(OnInterstitialBtnClick);
        rewardedads.OnLoaded(OnRewardAdLoaded);
        interstitialads.OnLoaded(InterstitialAdLoaded);
    }

    private void OnRewardAdLoaded()
    {
        rewardedBtn.interactable = true;
    }
    
    private void InterstitialAdLoaded()
    {
        interstitialBtn.interactable = true;
    }

    private void OnInterstitialBtnClick()
    {
        interstitialads.Show()
            .OnCompleted(() =>
            {
                result.text = "Interstitial added";
            })
            .OnClosed(() =>
            {
                interstitialBtn.interactable = false;
            });
    }

    private void OnRewardBtnClick()
    {
        rewardedads.Show()
            .OnCompleted(() =>
            {
                result.text = "Reward added";
            })
            .OnClosed(() =>
            {
                rewardedBtn.interactable = false;
            });
    }
}