// communication layer between unity and react

mergeInto(LibraryManager.library, {
  StartCountDown: function (data) {
    var parseData = UTF8ToString(data)
    var time = parseData.split(",")[0];
    var id = parseData.split(",")[1];
    var countDownDate = new Date(parseInt(time)).getTime();
    // Update the count down every 1 second
    // Get today's date and time
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = countDownDate - now;

    // Time calculations for days, hours, minutes and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Display the result in the element with id="demo"
    sendMessage("Timer", "SetTimer", days + "d " + hours + "h "
      + minutes + "m " + seconds + "s ");

    // If the count down is finished, write some text
    if (distance < 0) {
      sendMessage("Timer", "OnCompleted", parseInt(id));
    }
  },
  GetData: function (token_id) {
    try {
      return window.dispatchReactUnityEvent("OnNFTCall", token_id);
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  GetUser: function () {
    try {
      return window.dispatchReactUnityEvent("OnUserReady");
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
    // SendMessage("FirstPersonController", "SetUser", 'tz1eHDxGHWcyobNnocRVeQUHhpYrM1kBtYTx');
  },
  RemoveListener: function () {
    try {
      return window.dispatchReactUnityEvent("OnRemove");
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  Withdraw: function (id) {
    console.log(id)
    try {
      return window.dispatchReactUnityEvent("OnWithdraw", id);
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  Resale: function (id) {
    console.log(id)
    try {
      return window.dispatchReactUnityEvent("OnResale", id);
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  Bid: function (data) {
    var parseData = UTF8ToString(data)
    var id = parseData.split(",")[0];
    var amount = parseData.split(",")[1];
    console.log(id, amount)
    try {
      console.log(id + " " + amount)
      return window.dispatchReactUnityEvent("OnBid", { id, amount });
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  }
});