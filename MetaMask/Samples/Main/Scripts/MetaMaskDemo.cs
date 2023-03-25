using System;

using MetaMask.Models;

using UnityEngine;
using UnityEngine.SceneManagement;

using Nethereum.JsonRpc.Client;

using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Contracts;
using Nethereum.ABI.Model;
using System.Numerics;
using Nethereum.Util;
using System.Threading.Tasks;

namespace MetaMask.Unity.Samples
{

    public class MetaMaskDemo : MonoBehaviour
    {

        #region Events

        /// <summary>Raised when the wallet is connected.</summary>
        public event EventHandler onWalletConnected;
        /// <summary>Raised when the wallet is disconnected.</summary>
        public event EventHandler onWalletDisconnected;
        /// <summary>Raised when the wallet is ready.</summary>
        public event EventHandler onWalletReady;
        /// <summary>Raised when the wallet is paused.</summary>
        public event EventHandler onWalletPaused;
        /// <summary>Raised when the user signs and sends the document.</summary>
        public event EventHandler onSignSend;
        /// <summary>Occurs when a transaction is sent.</summary>
        public event EventHandler onTransactionSent;
        /// <summary>Raised when the transaction result is received.</summary>
        /// <param name="e">The event arguments.</param>
        public event EventHandler<MetaMaskEthereumRequestResultEventArgs> onTransactionResult;

        #endregion

        #region Fields

        /// <summary>The configuration for the MetaMask client.</summary>
        [SerializeField]
        protected MetaMaskConfig config;

        #endregion

        #region Unity Methods

        /// <summary>Initializes the MetaMaskUnity instance.</summary>
        private void Awake()
        {
            MetaMaskUnity.Instance.Initialize();
            MetaMaskUnity.Instance.Wallet.WalletAuthorized += walletConnected;
            MetaMaskUnity.Instance.Wallet.WalletDisconnected += walletDisconnected;
            MetaMaskUnity.Instance.Wallet.WalletReady += walletReady;
            MetaMaskUnity.Instance.Wallet.WalletPaused += walletPaused;
            MetaMaskUnity.Instance.Wallet.EthereumRequestResultReceived += TransactionResult;
        }

        private void OnDisable()
        {
            MetaMaskUnity.Instance.Wallet.WalletAuthorized -= walletConnected;
            MetaMaskUnity.Instance.Wallet.WalletDisconnected -= walletDisconnected;
            MetaMaskUnity.Instance.Wallet.WalletReady -= walletReady;
            MetaMaskUnity.Instance.Wallet.WalletPaused -= walletPaused;
            MetaMaskUnity.Instance.Wallet.EthereumRequestResultReceived -= TransactionResult;
        }

        #endregion

        #region Event Handlers

        /// <summary>Raised when the transaction result is received.</summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        public void TransactionResult(object sender, MetaMaskEthereumRequestResultEventArgs e)
        {
            onTransactionResult?.Invoke(sender, e);
        }

        /// <summary>Raised when the wallet is connected.</summary>
        private async void walletConnected(object sender, EventArgs e)
        {
            onWalletConnected?.Invoke(this, EventArgs.Empty);
            await Sign();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("MainScene");
        }

        /// <summary>Raised when the wallet is disconnected.</summary>
        private void walletDisconnected(object sender, EventArgs e)
        {
            Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MetaMaskMain");
            onWalletDisconnected?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Raised when the wallet is ready.</summary>
        private void walletReady(object sender, EventArgs e)
        {
            onWalletReady?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Raised when the wallet is paused.</summary>
        private void walletPaused(object sender, EventArgs e)
        {
            onWalletPaused?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Public Methods

        public void OpenDeepLink()
        {
            if (MetaMask.Transports.Unity.UI.MetaMaskUnityUITransport.DefaultInstance != null)
            {
                MetaMask.Transports.Unity.UI.MetaMaskUnityUITransport.DefaultInstance.OpenDeepLink();
            }
        }

        /// <summary>Calls the connect method to the Metamask Wallet.</summary>
        public void Connect()
        {
            MetaMaskUnity.Instance.Wallet.Connect();
        }

        /// <summary>Sends a transaction to the Ethereum network.</summary>
        /// <param name="transactionParams">The parameters of the transaction.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async void SendTransaction()
        {
            var transactionParams = new MetaMaskTransaction
            {

                To = "0xd0059fB234f15dFA9371a7B45c09d451a2dd2B5a",
                From = MetaMaskUnity.Instance.Wallet.SelectedAddress,
                Value = "0x0"
            };

            var request = new MetaMaskEthereumRequest
            {
                Method = "eth_sendTransaction",
                Parameters = new MetaMaskTransaction[] { transactionParams }
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
            await MetaMaskUnity.Instance.Wallet.Request(request);
            
            
        }

        /// <summary>Signs a message with the user's private key.</summary>
        /// <param name="msgParams">The message to sign.</param>
        /// <exception cref="InvalidOperationException">Thrown when the application isn't in foreground.</exception>
        public async Task Sign()
        {
            AddEthereumChainParameter addEthereumChainParameter = new AddEthereumChainParameter();

            var paramsArray = new AddEthereumChainParameter[] { addEthereumChainParameter };

            var request = new MetaMaskEthereumRequest
            {
                Method = "wallet_addEthereumChain",
                Parameters = paramsArray,
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
            await MetaMaskUnity.Instance.Wallet.Request(request);

        }

        public async void GetNFT(string id)
        {
            IndiCultre.IndiCultreConsole indiCultre = new IndiCultre.IndiCultreConsole();
            IndiCultureNFT.IndiCultureNFTConsole indiCultureNFTConsole = new IndiCultureNFT.IndiCultureNFTConsole();
            var data = await indiCultre.GetById(id);
            if (data != null)
            {
                var owner = await indiCultureNFTConsole.GetOwnerOf(id);
                NFTData nftData = new NFTData(Int16.Parse(data.TokenId.ToString()), owner.ToLower(), indiCultre.ConvertWei(data.BidAmount), data.Bidder.ToLower(), data.EndTimestamp.ToString() + "000");
                MetaState.nft = nftData;
            }
        }

        public async void Collect(int id)
        {
            TransactionInput input = new IndiCultre.IndiCultreConsole().Collect(id, MetaMaskUnity.Instance.Wallet.SelectedAddress);
            TransactionData transactionData = new TransactionData(input.To, input.From, input.Data, "0x0");
            var request = new MetaMaskEthereumRequest
            {
                Method = "eth_sendTransaction",
                Parameters = new TransactionData[] { transactionData },
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
             await MetaMaskUnity.Instance.Wallet.Request(request);
        }

        public async void Bid(string id,BigDecimal  amount)
        {
            TransactionInput input = new IndiCultre.IndiCultreConsole().Bid(id, MetaMaskUnity.Instance.Wallet.SelectedAddress, amount);
            TransactionData transactionData = new TransactionData(input.To, input.From, input.Data, input.Value.HexValue);
            var request = new MetaMaskEthereumRequest
            {
                Method = "eth_sendTransaction",
                Parameters = new TransactionData[] { transactionData },
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
            await MetaMaskUnity.Instance.Wallet.Request(request);
        }

        public async void Resale(string id)
        {
            TransactionInput approveTransaction = new IndiCultureNFT.IndiCultureNFTConsole().approve(id, MetaMaskUnity.Instance.Wallet.SelectedAddress);
            TransactionData approveTransactionData = new TransactionData(approveTransaction.To, approveTransaction.From, approveTransaction.Data, "0x0");
            var request = new MetaMaskEthereumRequest
            {
                Method = "eth_sendTransaction",
                Parameters = new TransactionData[] { approveTransactionData },
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
            var hash = await MetaMaskUnity.Instance.Wallet.Request(request);
            await new IndiCultre.IndiCultreConsole().CompletedSuccessfully(hash.GetString());
            TransactionInput input = new IndiCultre.IndiCultreConsole().Resale(id, MetaMaskUnity.Instance.Wallet.SelectedAddress);
            TransactionData transactionData = new TransactionData(input.To, input.From, input.Data, "0x0");
            var resaleRequest = new MetaMaskEthereumRequest
            {
                Method = "eth_sendTransaction",
                Parameters = new TransactionData[] { transactionData },
            };
            onTransactionSent?.Invoke(this, EventArgs.Empty);
            await MetaMaskUnity.Instance.Wallet.Request(resaleRequest);
        }

        public string getUser() {
            return MetaMaskUnity.Instance.Wallet.SelectedAddress;
        }

        #endregion
    }

}
