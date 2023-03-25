using Nethereum.Hex.HexTypes;
using System.Numerics;

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
    public string chainId = new HexBigInteger(new BigInteger(5001)).HexValue; // A 0x-prefixed hexadecimal string
    public string chainName = "Mantle Testnet";
    public NativeCurrency nativeCurrency = new NativeCurrency();

    public string[] rpcUrls = new string[] { "https://rpc.testnet.mantle.xyz/" };
    public string[] blockExplorerUrls = new string[] { "https://explorer.testnet.mantle.xyz/" };
}

[System.Serializable]
class NativeCurrency
{
    public string name;
    public string symbol;
    public int decimals = 18;

    public NativeCurrency()
    {
        name = "BIT";
        symbol = "BIT";
    }
}


