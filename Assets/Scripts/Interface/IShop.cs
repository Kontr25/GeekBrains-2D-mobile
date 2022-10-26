namespace Interface
{
    internal interface IShop
    {
        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchase();
    }

}