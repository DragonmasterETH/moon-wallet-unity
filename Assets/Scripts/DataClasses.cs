using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DataClasses : MonoBehaviour
{
    //Place all your custom JSON classes here for deserialization, then access them with JsonUtility.FromJson<DataClasses.CLASS>(DATA);

    [Serializable]
    public class NonceResponse
    {
        public User[] user;
    }
    [Serializable]
    public class User
    {
        //id
        //created_at
        //address
        public Auth auth;
        //email
        //users
    }

    [Serializable]
    public class Auth
    {
        public string genNonce;
        //lastAuth
        //lastAuthStatus
    }

    [Serializable]
    public class MoonAccountResponse
    {
        public bool success;
        public MoonAccountData data;
    }

    [Serializable]
    public class MoonAccountData
    {
        public MoonAccounts data;
    }
    [Serializable]
    public class MoonAccounts
    {
        public List<string> keys;
        public string address;
    }

    [Serializable]
    public class BalanceData
    {
        public Balance data;
        public bool success;
        public string message;
    }

    [Serializable]
    public class Balance
    {
        public float balance;
    }

    [Serializable]
    public class ChallengeData
    {
        public string address;
    }

    [Serializable]
    public class MoonJWT
    {
        public Token token;

    }

    [Serializable]
    public class Token
    {
        public string access_token;
        public string refresh_token;
    }

    [Serializable]
    public class AuthorizationHeader
    {
        public string Authorization;
    }

    [Serializable]
    public class AuthData
    {
        public string message;
        public string signedMessage;
        public string nonce;
        public string address;
    }

    [Serializable]
    public class TransferPayload
    {
        public string to;
        public string value;
        public int chain_id = 11155111;
    }

    [Serializable]
    public class TransferResponse
    {
        public TransferResponseData data;
        public bool success;
        public string message;
    }

    [Serializable]
    public class TransferResponseData
    {
        public Transaction[] transactions;
    }

    [Serializable]
    public class Transaction
    {
        public string raw_transaction;
        public string transaction_hash;
        //there is also a transaction class with things like chainId, data, gas, value, to, from, etc. Create this extra class if needed
    }

    [Serializable]
    public class BroadcastPayload
    {
        public string chainId = "11155111";
        public string rawTransaction;
    }

    [Serializable]
    public class GasResponse
    {
        public Estimate data;
    }

    [Serializable]
    public class Estimate
    {
        public string estimate;
    }
}
