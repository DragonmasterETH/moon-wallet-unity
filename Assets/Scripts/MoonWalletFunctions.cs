using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using com.usemoon.MoonSDK.Api;
using com.usemoon.MoonSDK.Client;
using com.usemoon.MoonSDK.Model;
using Nethereum.Util;
using System.Numerics;

public class MoonWalletFunctions : MonoBehaviour
{
    public class EIP4361Message
    {
        public string Domain { get; set; }
        public string Address { get; set; }
        public string Statement { get; set; }
        public string Uri { get; set; }
        public string Version { get; set; }
        public string ChainId { get; set; }
        public string Nonce { get; set; }
        public DateTime IssuedAt { get; set; }

        public string PrepareMessage()
        {
            return $"{Domain} wants you to sign in with your Ethereum account:\n{Address}\n\nSign in with Ethereum to the app.\n\nURI: {Uri}\nVersion: {Version}\nChain ID: {ChainId}\nNonce: {Nonce}\nIssued At: {IssuedAt:O}";
        }
    }

    //Moon Wallet vars
    private string url;
    private AccountsApi apiInstance;
    private string authorization = "BearerAuth";
    private string moonAddress;
    private string ethAddress;
    private string jwt;
    private string basePath = "https://beta.usemoon.ai/";
    private string siwePath = "https://beta.usemoon.ai/auth/";
    private string nonce;

    //events
    public event Action<string> OnMoonAddressRetrieved;
    public event Action<float> OnBalRetrieved;
    public event Action<string> OnGasEstimated;

    //jslib functions
    [DllImport("__Internal")]
    private static extern void ConnectMetaMask();

    [DllImport("__Internal")]
    private static extern void RequestSignature(string message);


    //functions
    private void Start()
    {
        Configuration config = new Configuration();
        config.BasePath = basePath;
        config.AddApiKey("Authorization", ""); //Add your moon wallet API key here
        apiInstance = new AccountsApi(config);
    }
    public void OnConnectButtonClick()
    {
        //if using anything other than webGL, you will have to create a connect wallet function to work outside of the browser environment
        #if UNITY_WEBGL
            ConnectMetaMask();
        #endif
    }

    // Called from Jslib's ConnectMetamask()
    public void OnWalletConnected(string addressUrl)
    {
        string[] parts = addressUrl.Split('|');
        ethAddress = parts[0];
        url = parts[1];
        Debug.Log("Wallet connected with address: " + ethAddress);
        Debug.Log("Connected URL: " + url);
        StartCoroutine(GenerateMessage(ethAddress));

    }

    private IEnumerator GenerateMessage(string address)
    {
        string api = siwePath + "ethereum/nonce";
        DataClasses.ChallengeData data = new DataClasses.ChallengeData { address = address };
        string jsonData = JsonUtility.ToJson(data);
        using (UnityWebRequest request = new UnityWebRequest(api, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            //request.SetRequestHeader("Authorization", authorization);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                DataClasses.NonceResponse nonceResponse = JsonUtility.FromJson<DataClasses.NonceResponse>(request.downloadHandler.text);
                nonce = nonceResponse.user[0].auth.genNonce;
                Debug.Log(nonceResponse.user[0].auth.genNonce);
                Uri uri = new Uri(url);
                string domain = uri.Host;
                string uriPath = uri.AbsoluteUri;
                EIP4361Message message = new EIP4361Message
                {
                    Domain = domain,
                    Address = new AddressUtil().ConvertToChecksumAddress(address),
                    Statement = "Sign in with Ethereum to the app.",
                    Uri = uriPath,
                    Version = "1",
                    ChainId = "1",
                    Nonce = nonce,
                    IssuedAt = DateTime.UtcNow
                };

                string formattedMessage = message.PrepareMessage();

                RequestSignature(formattedMessage);
            }
        }
    }


    // Called from Jslib when the signature is ready
    public void OnSignatureReceived(string signatureMessage)
    {
        
        var parts = signatureMessage.Split('|');
        if (parts.Length == 2)
        {
            string signature = parts[0];
            string message = parts[1];
            string address = ethAddress;

            SendSignatureToServer(message, signature, address);
        }
    }

    public void SendSignatureToServer(string message, string signature, string address)
    {
        StartCoroutine(PostSignatureToServer(message, signature, address));
    }

    private IEnumerator PostSignatureToServer(string message, string signature, string address)
    {

        string url = siwePath + "ethereum/login";
        DataClasses.AuthData data = new DataClasses.AuthData { message = message, signedMessage = signature, address = address, nonce = nonce};
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("Response: " + request.downloadHandler.text);

                DataClasses.MoonJWT moonJWT = JsonUtility.FromJson<DataClasses.MoonJWT>(request.downloadHandler.text);
                jwt = moonJWT.token.access_token;
                StartCoroutine(GetMoonAccount());
            }
        }
    }

    private IEnumerator GetMoonAccount()
    {
        string url = "https://beta.usemoon.ai/accounts"; //we do not use the basepath since this is a special endpoint outside of /api/

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + jwt);
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("api/account Error: " + request.error);
            }
            else
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                DataClasses.MoonAccountResponse response = JsonUtility.FromJson<DataClasses.MoonAccountResponse>(request.downloadHandler.text);

                if (response.success && response.data.data.keys != null && response.data.data.keys.Count > 0)
                {
                    // Set the first key as MoonWalletAddress
                    moonAddress = response.data.data.keys[0];
                    OnMoonAddressRetrieved?.Invoke(moonAddress);
                    StartCoroutine(GetBal());
                }
                else
                {
                    // If no keys, send POST request. This will create the wallet and then return the new keys
                    StartCoroutine(CreateMoonAccount());
                }
            }
        }
    }


    private IEnumerator CreateMoonAccount()
    {
        string url = "https://beta.usemoon.ai/accounts";

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes("{}");
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Authorization", "Bearer " + jwt);
            request.SetRequestHeader("Content-Type", "application/json");
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("api/account POST Error: " + request.error);
            }
            else
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                DataClasses.MoonAccountResponse response = JsonUtility.FromJson<DataClasses.MoonAccountResponse>(request.downloadHandler.text);

                if (response.success && response.data.data.address != null)
                {
                    moonAddress = response.data.data.address;
                    OnMoonAddressRetrieved?.Invoke(moonAddress);
                }
                else
                {
                    Debug.LogError("No keys found in POST response");
                }
            }
        }
    }

    public IEnumerator GetBal()
    {
        string url = basePath + "accounts/" + moonAddress + "/balance?chainId=11155111"; //You can create a variable to change the ChainID for crosschain applications, this will get you ETH balance on Sepolia

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + jwt);
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("api/getETH Error: " + request.error);
            }
            else
            {
                DataClasses.BalanceData response = JsonUtility.FromJson<DataClasses.BalanceData>(request.downloadHandler.text);
                float balance = response.data.balance;
                Debug.Log("Balance: " + balance);
                OnBalRetrieved?.Invoke(balance);
            }
        }
    }

    public void RefreshBal()
    {
        StartCoroutine(GetBal());
    }

    public void sendTxn(BigInteger amount, string toAddress)
    {
        StartCoroutine(SendEthereum(amount, toAddress));
    }
    private IEnumerator SendEthereum(BigInteger amount, string toAddress)
    {
        string url = basePath + "accounts/" + moonAddress + "/transfer-eth";

        DataClasses.TransferPayload payload = new DataClasses.TransferPayload { to = toAddress, value = amount.ToString() };
        string jsonData = JsonUtility.ToJson(payload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Authorization", "Bearer " + jwt);
            request.SetRequestHeader("Content-Type", "application/json");
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                DataClasses.TransferResponse response = JsonUtility.FromJson<DataClasses.TransferResponse>(request.downloadHandler.text);
                Debug.Log("Successfully transferred tokens");
                Debug.Log(response);
            }
        }
    }

    public void EstimateGas(string value, string toAddress)
    {
        StartCoroutine(GetGasEstimate(value, toAddress));
    }

    private IEnumerator GetGasEstimate(string value, string toAddress)
    {
        string url = basePath + "accounts/" + moonAddress + "/estimate-gas";

        DataClasses.TransferPayload payload = new DataClasses.TransferPayload { to = toAddress, value = value.ToString() };
        string jsonData = JsonUtility.ToJson(payload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Authorization", "Bearer " + jwt);
            request.SetRequestHeader("Content-Type", "application/json");
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                DataClasses.GasResponse response = JsonUtility.FromJson<DataClasses.GasResponse>(request.downloadHandler.text);
                string wei = response.data.estimate;
                Debug.Log(wei);
                OnGasEstimated?.Invoke(wei);
            }
        }
    }
}