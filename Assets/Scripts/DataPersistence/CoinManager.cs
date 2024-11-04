[System.Serializable] public class PlayerData
{
    public int money = 0;
}

public class CoinManager : IDataPersistence
{
    static PlayerData playerData = new PlayerData();


    public static int GetMoney()
    {
        return playerData.money;
    }

    public static void AddMoney(int amount)
    {
        playerData.money += amount;
    }

    public static bool CanSpendMoney(int amount)
    {
        return (playerData.money >= amount);
    }

    public static void SpendMoney(int amount)
    {
        playerData.money -= amount;
    }

    public void LoadGame(GameData data)
    {
        CoinManager.playerData.money = data.playerMoney.money;
    }

    public void SaveGame(GameData data)
    {
        data.playerMoney.money = CoinManager.playerData.money;
    }
}
