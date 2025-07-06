using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;
using System.Collections.Generic;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance;
    private IStoreController storeController;
    private IExtensionProvider storeExtensionProvider;

    public List<string> weaponProductIDs = new List<string> { "weapon_1", "weapon_2", "weapon_3" };
    public Dictionary<string, Product> products = new Dictionary<string, Product>();

    public List<GameObject> weaponButtons;
    public List<Text> weaponPriceTexts;
    public List<GameObject> weaponLocks;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        InitializePurchasing();
    }

    public void InitializePurchasing()
    {
        if (storeController != null) return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        foreach (string id in weaponProductIDs)
            builder.AddProduct(id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;

        foreach (string id in weaponProductIDs)
        {
            Product product = storeController.products.WithID(id);
            if (product != null)
            {
                products[id] = product;

                int index = weaponProductIDs.IndexOf(id);
                bool unlocked = PlayerPrefs.GetInt($"{id}_unlocked", 0) == 1;

                if (!unlocked)
                {
                    if (index < weaponPriceTexts.Count)
                        weaponPriceTexts[index].text = product.metadata.localizedPriceString;

                    if (index < weaponLocks.Count)
                        weaponLocks[index].SetActive(true);
                }
                else
                {
                    if (index < weaponPriceTexts.Count)
                        weaponPriceTexts[index].gameObject.SetActive(false);

                    if (index < weaponLocks.Count)
                        weaponLocks[index].SetActive(false);
                }
            }
        }
    }

    public void BuyProduct(string productId)
    {
        if (storeController != null && storeController.products.WithID(productId) != null)
        {
            storeController.InitiatePurchase(productId);
        }
        else
        {
            Debug.LogError("BuyProduct: FAIL. Not initialized or product not found.");
        }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        string id = args.purchasedProduct.definition.id;

        if (weaponProductIDs.Contains(id))
        {
            PlayerPrefs.SetInt($"{id}_unlocked", 1);
            PlayerPrefs.Save();

            int index = weaponProductIDs.IndexOf(id);

            if (index < weaponPriceTexts.Count)
                weaponPriceTexts[index].gameObject.SetActive(false);

            if (index < weaponLocks.Count)
                weaponLocks[index].SetActive(false);

            Debug.Log($"Purchase Successful: {id}");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnInitializeFailed(InitializationFailureReason error) =>
        Debug.LogError($"IAP Init Failed: {error}");

    public void OnInitializeFailed(InitializationFailureReason error, string message) =>
        Debug.LogError($"IAP Init Failed: {error} - {message}");

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) =>
        Debug.LogError($"Purchase failed: {product.definition.id}, Reason: {failureReason}");
}
