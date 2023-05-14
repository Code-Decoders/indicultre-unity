using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using System;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;
using System.Threading.Tasks;

namespace IndiCultre
{


    public class IndiCultreConsole
    {
        public string ADDRESS = "0x40721AE051B1D20c12038d7c408454B3Ca310Ea1";

        public string ABI = "[{\"inputs\":[{\"internalType\":\"uint32\",\"name\":\"tokenId\",\"type\":\"uint32\"}],\"name\":\"bid\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint32\",\"name\":\"tokenId\",\"type\":\"uint32\"}],\"name\":\"collect\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"sec\",\"type\":\"uint256\"}],\"name\":\"setDuration\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_nftAddress\",\"type\":\"address\"}],\"name\":\"setNFTContract\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint32\",\"name\":\"tokenId\",\"type\":\"uint32\"}],\"name\":\"startAuction\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"addressList\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"auctions\",\"outputs\":[{\"internalType\":\"uint32\",\"name\":\"tokenId\",\"type\":\"uint32\"},{\"internalType\":\"address\",\"name\":\"seller\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"bidder\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"bidAmount\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"endTimestamp\",\"type\":\"uint256\"},{\"internalType\":\"address\",\"name\":\"artist\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"balances\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"MINIMUM_BIDDING_PRICE\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";



        public string RPC_URL = "https://data-seed-prebsc-1-s1.binance.org:8545/";

        public async Task<AuctionsOutputDTO> GetById(string id)
        {
            Debug.Log(id);
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            /** Function: auctions**/
            var web3 = new Web3(account, RPC_URL);
            var contractHandler = web3.Eth.GetContractHandler(ADDRESS);
            var auctionsFunction = new AuctionsFunction();
            auctionsFunction.ReturnValue1 = BigInteger.Parse(id);
            var auctionsOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<AuctionsFunction, AuctionsOutputDTO>(auctionsFunction);
            return auctionsOutputDTO;
        }

        public string ConvertWei(BigInteger value)
        {
            return Web3.Convert.FromWei(value).ToString();
        }

        public TransactionInput Collect(int id, string account)
        {
            
            var contract = new ContractBuilder(ABI, ADDRESS);
            var contractHandler = contract.GetFunctionBuilder("collect").CreateTransactionInput(account, new object[] { id });
            return contractHandler;
        }

        public TransactionInput Bid(string id, string account, BigDecimal bid)
        {
            Debug.Log("Bid: " + bid);
            var contract = new ContractBuilder(ABI, ADDRESS);
            var contractHandler = contract.GetFunctionBuilder("bid").CreateTransactionInput(account,new HexBigInteger(new BigInteger(0)),new HexBigInteger(Web3.Convert.ToWei(bid)), new object[] { ((int)Int64.Parse(id)) });
            return contractHandler;
        }

        public TransactionInput Resale(string id, string account)
        {
            var contract = new ContractBuilder(ABI, ADDRESS);
            var contractHandler = contract.GetFunctionBuilder("startAuction").CreateTransactionInput(account, new object[] { ((int)Int64.Parse(id)) });
            return contractHandler;
        }

        public async Task CompletedSuccessfully(string hash)
        {
            var web3 = new Web3(RPC_URL);
            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(hash);
            while (receipt == null)
            {
                Thread.Sleep(5000);
                receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(hash);
            }
        }

        public static async Task Main()
        {

            //var url = "https://mainnet.infura.io";
            
            

            /* Deployment 
           var indiCultreDeployment = new IndiCultreDeployment();

           var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<IndiCultreDeployment>().SendRequestAndWaitForReceiptAsync(indiCultreDeployment);
           var contractAddress = transactionReceiptDeployment.ContractAddress;
            */
            

            /** Function: bid**/
            /*
            var bidFunction = new BidFunction();
            bidFunction.TokenId = tokenId;
            var bidFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(bidFunction);
            */


            /** Function: collect**/
            /*
            var collectFunction = new CollectFunction();
            collectFunction.TokenId = tokenId;
            var collectFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(collectFunction);
            */


            /** Function: setDuration**/
            /*
            var setDurationFunction = new SetDurationFunction();
            setDurationFunction.Sec = sec;
            var setDurationFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setDurationFunction);
            */


            /** Function: setNFTContract**/
            /*
            var setNFTContractFunction = new SetNFTContractFunction();
            setNFTContractFunction.NftAddress = nftAddress;
            var setNFTContractFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setNFTContractFunction);
            */


            /** Function: startAuction**/
            /*
            var startAuctionFunction = new StartAuctionFunction();
            startAuctionFunction.TokenId = tokenId;
            var startAuctionFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(startAuctionFunction);
            */


            /** Function: addressList**/
            /*
            var addressListFunction = new AddressListFunction();
            addressListFunction.ReturnValue1 = returnValue1;
            var addressListFunctionReturn = await contractHandler.QueryAsync<AddressListFunction, string>(addressListFunction);
            */


            /** Function: auctions**/
            /*
            var auctionsFunction = new AuctionsFunction(); 
            auctionsFunction.ReturnValue1 = returnValue1;
            var auctionsOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<AuctionsFunction, AuctionsOutputDTO>(auctionsFunction);
            */


            /** Function: balances**/
            /*
            var balancesFunction = new BalancesFunction();
            balancesFunction.ReturnValue1 = returnValue1;
            var balancesFunctionReturn = await contractHandler.QueryAsync<BalancesFunction, BigInteger>(balancesFunction);
            */


            /** Function: MINIMUM_BIDDING_PRICE**/
            /*
            var minimumBiddingPriceFunctionReturn = await contractHandler.QueryAsync<MinimumBiddingPriceFunction, BigInteger>();
            */
        }

    }


    public partial class BidFunction : BidFunctionBase { }

    [Function("bid")]
    public class BidFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "tokenId", 1)]
        public virtual uint TokenId { get; set; }
    }

    public partial class CollectFunction : CollectFunctionBase { }

    [Function("collect")]
    public class CollectFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "tokenId", 1)]
        public virtual uint TokenId { get; set; }
    }

    public partial class SetDurationFunction : SetDurationFunctionBase { }

    [Function("setDuration")]
    public class SetDurationFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "sec", 1)]
        public virtual BigInteger Sec { get; set; }
    }

    public partial class SetNFTContractFunction : SetNFTContractFunctionBase { }

    [Function("setNFTContract")]
    public class SetNFTContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_nftAddress", 1)]
        public virtual string NftAddress { get; set; }
    }

    public partial class StartAuctionFunction : StartAuctionFunctionBase { }

    [Function("startAuction")]
    public class StartAuctionFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "tokenId", 1)]
        public virtual uint TokenId { get; set; }
    }

    public partial class AddressListFunction : AddressListFunctionBase { }

    [Function("addressList", "address")]
    public class AddressListFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AuctionsFunction : AuctionsFunctionBase { }

    [Function("auctions", typeof(AuctionsOutputDTO))]
    public class AuctionsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BalancesFunction : BalancesFunctionBase { }

    [Function("balances", "uint256")]
    public class BalancesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class MinimumBiddingPriceFunction : MinimumBiddingPriceFunctionBase { }

    [Function("MINIMUM_BIDDING_PRICE", "uint256")]
    public class MinimumBiddingPriceFunctionBase : FunctionMessage
    {

    }

    public partial class AddressListOutputDTO : AddressListOutputDTOBase { }

    [FunctionOutput]
    public class AddressListOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AuctionsOutputDTO : AuctionsOutputDTOBase { }

    [FunctionOutput]
    public class AuctionsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint32", "tokenId", 1)]
        public virtual uint TokenId { get; set; }
        [Parameter("address", "seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "bidder", 3)]
        public virtual string Bidder { get; set; }
        [Parameter("uint256", "bidAmount", 4)]
        public virtual BigInteger BidAmount { get; set; }
        [Parameter("uint256", "endTimestamp", 5)]
        public virtual BigInteger EndTimestamp { get; set; }
        [Parameter("address", "artist", 6)]
        public virtual string Artist { get; set; }
    }

    public partial class BalancesOutputDTO : BalancesOutputDTOBase { }

    [FunctionOutput]
    public class BalancesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MinimumBiddingPriceOutputDTO : MinimumBiddingPriceOutputDTOBase { }

    [FunctionOutput]
    public class MinimumBiddingPriceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}


namespace IndiCultureNFT
{


    public class IndiCultureNFTConsole
    {


        public string ADDRESS = "0xB7ff4e2dbE970f94Ca08083dB9cb073266E3c357";

        public string ABI = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"marketplace\",\"type\":\"address\"}],\"name\":\"changeMarketplace\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getLatestTokenId\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"tokenURI\",\"type\":\"string\"}],\"name\":\"mint\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";

        public string RPC_URL = "https://data-seed-prebsc-1-s1.binance.org:8545/";
        public async void Approve(string tokenId, string account)
        {

        }

        public async Task<string> GetOwnerOf(string tokenId)
        {
            Debug.Log(tokenId);
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            var web3 = new Web3(account, RPC_URL);
            var contractHandler = web3.Eth.GetContractHandler(ADDRESS);
            var ownerOfFunction = new OwnerOfFunction();
            ownerOfFunction.TokenId = BigInteger.Parse(tokenId);
            var ownerOfFunctionReturn = await contractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction);
            return ownerOfFunctionReturn;
        }

        public TransactionInput approve(string id, string from)
        {
            var contract = new ContractBuilder(ABI, ADDRESS);
            var contractHandler = contract.GetFunctionBuilder("approve").CreateTransactionInput(from, new object[] { new IndiCultre.IndiCultreConsole().ADDRESS,  ((int)Int64.Parse(id))});
            return contractHandler;
        }


        public static async Task Main()
        {
            var url = "http://testchain.nethereum.com:8545";
            //var url = "https://mainnet.infura.io";
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            var web3 = new Web3(account, url);

            /* Deployment 
           var indiCultureNFTDeployment = new IndiCultureNFTDeployment();

           var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<IndiCultureNFTDeployment>().SendRequestAndWaitForReceiptAsync(indiCultureNFTDeployment);
           var contractAddress = transactionReceiptDeployment.ContractAddress;
            */

            /** Function: approve**/
            /*
            var approveFunction = new ApproveFunction();
            approveFunction.To = to;
            approveFunction.TokenId = tokenId;
            var approveFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveFunction);
            */


            /** Function: balanceOf**/
            /*
            var balanceOfFunction = new BalanceOfFunction();
            balanceOfFunction.Owner = owner;
            var balanceOfFunctionReturn = await contractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
            */


            /** Function: changeMarketplace**/
            /*
            var changeMarketplaceFunction = new ChangeMarketplaceFunction();
            changeMarketplaceFunction.Marketplace = marketplace;
            var changeMarketplaceFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(changeMarketplaceFunction);
            */


            /** Function: getApproved**/
            /*
            var getApprovedFunction = new GetApprovedFunction();
            getApprovedFunction.TokenId = tokenId;
            var getApprovedFunctionReturn = await contractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction);
            */


            /** Function: getLatestTokenId**/
            /*
            var getLatestTokenIdFunctionReturn = await contractHandler.QueryAsync<GetLatestTokenIdFunction, BigInteger>();
            */


            /** Function: isApprovedForAll**/
            /*
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
            isApprovedForAllFunction.Owner = owner;
            isApprovedForAllFunction.Operator = @operator;
            var isApprovedForAllFunctionReturn = await contractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction);
            */


            /** Function: mint**/
            /*
            var mintFunction = new MintFunction();
            mintFunction.TokenURI = tokenURI;
            var mintFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(mintFunction);
            */


            /** Function: name**/
            /*
            var nameFunctionReturn = await contractHandler.QueryAsync<NameFunction, string>();
            */


            /** Function: ownerOf**/
            /*
            var ownerOfFunction = new OwnerOfFunction();
            ownerOfFunction.TokenId = tokenId;
            var ownerOfFunctionReturn = await contractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction);
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFromFunction = new SafeTransferFromFunction();
            safeTransferFromFunction.From = from;
            safeTransferFromFunction.To = to;
            safeTransferFromFunction.TokenId = tokenId;
            var safeTransferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction);
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
            safeTransferFrom1Function.From = from;
            safeTransferFrom1Function.To = to;
            safeTransferFrom1Function.TokenId = tokenId;
            safeTransferFrom1Function.Data = data;
            var safeTransferFrom1FunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function);
            */


            /** Function: setApprovalForAll**/
            /*
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
            setApprovalForAllFunction.Operator = @operator;
            setApprovalForAllFunction.Approved = approved;
            var setApprovalForAllFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction);
            */


            /** Function: supportsInterface**/
            /*
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
            supportsInterfaceFunction.InterfaceId = interfaceId;
            var supportsInterfaceFunctionReturn = await contractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction);
            */


            /** Function: symbol**/
            /*
            var symbolFunctionReturn = await contractHandler.QueryAsync<SymbolFunction, string>();
            */


            /** Function: tokenURI**/
            /*
            var tokenURIFunction = new TokenURIFunction();
            tokenURIFunction.TokenId = tokenId;
            var tokenURIFunctionReturn = await contractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction);
            */


            /** Function: transferFrom**/
            /*
            var transferFromFunction = new TransferFromFunction();
            transferFromFunction.From = from;
            transferFromFunction.To = to;
            transferFromFunction.TokenId = tokenId;
            var transferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction);
            */
        }

    }

  

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class ChangeMarketplaceFunction : ChangeMarketplaceFunctionBase { }

    [Function("changeMarketplace")]
    public class ChangeMarketplaceFunctionBase : FunctionMessage
    {
        [Parameter("address", "marketplace", 1)]
        public virtual string Marketplace { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetLatestTokenIdFunction : GetLatestTokenIdFunctionBase { }

    [Function("getLatestTokenId", "uint256")]
    public class GetLatestTokenIdFunctionBase : FunctionMessage
    {

    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint", "uint256")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("string", "tokenURI", 1)]
        public virtual string TokenURI { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true)]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false)]
        public virtual bool Approved { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true)]
        public virtual BigInteger TokenId { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetLatestTokenIdOutputDTO : GetLatestTokenIdOutputDTOBase { }

    [FunctionOutput]
    public class GetLatestTokenIdOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
