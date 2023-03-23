

class TransactionData
{
    public string to;
    public string from;
    public string data;
    public string value;

    public TransactionData(string to, string from, string data, string value) {
        this.to = to;
        this.from = from;
        this.data = data;
        this.value = value;
    }
}


class AddEthereumChainParameter
{
    public string chainId = "0x13881"; // A 0x-prefixed hexadecimal string
    public string chainName = "Mumbai";
    public NativeCurrency nativeCurrency = new NativeCurrency();

    public string[] rpcUrls = new string[] { "https://rpc-mumbai.maticvigil.com" };
    public string[] blockExplorerUrls = new string[] { "https://mumbai.polygonscan.com/" };
}

[System.Serializable]
class NativeCurrency
{
    string name;
    string symbol;
    int decimals = 18;

    public NativeCurrency()
    {
        name = "MATIC";
        symbol = "MATIC";
    }
}


