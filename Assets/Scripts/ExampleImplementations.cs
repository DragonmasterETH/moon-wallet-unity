using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;
using Nethereum.Util;
using System;

public class ExampleImplementations : MonoBehaviour
{
    public MoonWalletFunctions moonWalletFunctions;
    public TextMeshProUGUI walletText;
    public TextMeshProUGUI balanceText;
    public TMP_InputField walletAddy;
    public TMP_InputField amount;
    public Button connectButton;
    public Button txnButton;
    public Button refreshButton;
    private decimal eth;

    private void Awake()
    {
        moonWalletFunctions.OnMoonAddressRetrieved += SetMoonText;
        moonWalletFunctions.OnBalRetrieved += RefreshBal;
        moonWalletFunctions.OnGasEstimated += CalculateTxn;
    }
    private void RefreshBal(float bal)
    {
        UnitConversion unitConversion = new UnitConversion();
        eth = unitConversion.FromWei((BigInteger)bal, UnitConversion.EthUnit.Ether);
        balanceText.text = "Balance: " + Math.Round(eth, 3) + "eth";
    }

    public void OnAmountChanged()
    {
        if (walletAddy.text != "" && amount.text != "")
        {
            if (decimal.Parse(amount.text) < eth)
            {
                UnitConversion unitConversion = new UnitConversion();
                string wei = unitConversion.ToWei(decimal.Parse(amount.text), UnitConversion.EthUnit.Ether).ToString();
                moonWalletFunctions.EstimateGas(wei, "0x8332Cb81341BF579075aD5625F2D2d91409df79D");
            }
        }
    }

    private void SetMoonText(string wallet)
    {
        walletText.text = wallet;
        connectButton.gameObject.SetActive(false);
        refreshButton.interactable = true;
    }

    private void CalculateTxn(string gas)
    {
        UnitConversion unitConversion = new UnitConversion();
        decimal wei = unitConversion.FromWei(BigInteger.Parse(gas), UnitConversion.EthUnit.Ether);
        if (decimal.Parse(amount.text) + wei < eth)
        {
            txnButton.interactable = true;
        }
        else
        {
            txnButton.interactable = false;
            Debug.Log("Not enough gas to transfer, need " + ((eth - (decimal.Parse(amount.text) + wei)) * -1) + " more gas");
        }
    }
    public void TransferFunds()
    {
        if (walletAddy.text != null && amount.text != null)
        {
            string testWallet = "0x8332Cb81341BF579075aD5625F2D2d91409df79D";
            string toWallet = walletAddy.text;
            decimal eth = decimal.Parse(amount.text);
            UnitConversion unitConversion = new UnitConversion();
            BigInteger wei = unitConversion.ToWei(eth, UnitConversion.EthUnit.Ether);
            moonWalletFunctions.sendTxn(wei, testWallet);
            //You can grab the txn hash from the output of this if you need it
        }
        else 
        {
            Debug.Log("Ensure you have entered a wallet to transfer to as well as an amount of ether to transfer!");
        }
    }
}
