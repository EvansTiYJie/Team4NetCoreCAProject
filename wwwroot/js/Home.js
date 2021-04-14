

window.onload = function () {
    let elemList = document.getElementsByClassName("addtocart"); //"addtocart" is button class name (will change according to view design)
    for (i = 0; i < elemList.length; i++) {
        elemList[i].onclick = AddToCart;
    }


    function AddToCart(event) {
        let elem = event.currentTarget;

        sendAddToCart(true, elem.getAttribute("product_id"))

    }

    function sendAddToCart(added, productId) {

        let xhr = new XMLHttpRequest();

        xhr.open("POST", "/Home/UpdateCart");
        xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

        xhr.onreadystatechange = function () {
            if (this.readyState == XMLHttpRequest.DONE) {
                if (this.status == 200) {
                    let data = JSON.parse(this.responseText);
                    console.log("Status: " + data.status);
                    let cartnumber = document.getElementById("cart_counter");//"cart_counter" will change according to view design
                    cartnumber.innerHTML = data.cartNumber//?
                }
            }
        };

        xhr.send(JSON.stringify({ Added: added, ProductId: productId }));
    }
}