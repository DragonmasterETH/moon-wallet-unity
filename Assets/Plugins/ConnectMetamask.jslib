mergeInto(LibraryManager.library, {
  ConnectMetaMask: function () {
    if (typeof window.ethereum !== 'undefined') {
      window.ethereum.request({ method: 'eth_requestAccounts' })
        .then(accounts => {
          if (accounts.length > 0) {
            var currentUrl = window.location.href;
            console.log("Connected with account: " + accounts[0]);
            SendMessage('Web3Connector', 'OnWalletConnected', accounts[0] + "|" + currentUrl);
          } else {
            console.log("No accounts found");
          }
        })
        .catch(error => {
          console.error("Connection error:", error);
        });
    } else {
      console.log("MetaMask not detected");
    }
  },
  RequestSignature: function (messagePointer) {
    var message = UTF8ToString(messagePointer);
    console.log("Requesting signature for message:", message);

    if (typeof window.ethereum !== 'undefined') {
      var from = window.ethereum.selectedAddress;
      if (!from) {
        console.log("No account is connected");
        return;
      }

      window.ethereum.request({ 
        method: 'personal_sign', 
        params: [message, from]
      })
      .then(signature => {
        console.log("Signature: " + signature);
        // Pass the signature back to Unity along with the message
        SendMessage('Web3Connector', 'OnSignatureReceived', signature + "|" + message);
      })
      .catch(error => {
        console.error("Signing error:", error);
      });
    } else {
      console.log("MetaMask not detected");
    }
  }
});
