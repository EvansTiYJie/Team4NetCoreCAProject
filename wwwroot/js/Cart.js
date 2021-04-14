window.onload = function () {
    let elemList = document.getElementsByClassName("updatecartquantity");
    for (i = 0; i < elemList.length; i++) {
        elemList[i].onclick = UpdateQuantity;
    }
}

function UpdateQuantity(event) {
    let elem = event.currentTarget;
    if (elem.getAttribute("plus") == "true") {
        sendUpdateQuantity(true, elem.getAttribute("product_id"))
    }
    else {
        sendUpdateQuantity(false, elem.getAttribute("product_id")) // if flase--> deduct quantity from cart
    }
}
function sendUpdateQuantity(plus, productId) {

    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Cart/UpdateQuantityInCart");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState == XMLHttpRequest.DONE) {
            if (this.status == 200) {
                let data = JSON.parse(this.responseText);
                console.log("Status: " + data.status);
                let displayquantity = document.getElementById("number_" + data.productId);
                displayquantity.innerHTML = data.quantity;
                let displaytotalpriceofthisproduct = document.getElementById("Total_" + data.productId);
                displaytotalpriceofthisproduct.innerHTML = data.price;
                let displaytotalprice = document.getElementById("cTotal");
                displaytotalprice.innerHTML = data.totalprice;
            }
        }
    };

    xhr.send(JSON.stringify({ Plus: plus, ProductId: productId }));
}