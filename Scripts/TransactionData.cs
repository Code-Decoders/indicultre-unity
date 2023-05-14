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
    public string chainId = new HexBigInteger(new BigInteger(97)).HexValue; // A 0x-prefixed hexadecimal string
    public string chainName = "BNB Smart Chain Testnet";
    public NativeCurrency nativeCurrency = new NativeCurrency();

    public string[] rpcUrls = new string[] { "https://data-seed-prebsc-1-s1.binance.org:8545/" };
    public string[] blockExplorerUrls = new string[] { "https://testnet.bscscan.com/" };
}

[System.Serializable]
class NativeCurrency
{
    public string name;
    public string symbol;
    public int decimals = 18;

    public NativeCurrency()
    {
        name = "BNB";
        symbol = "BNB";
    }
}


