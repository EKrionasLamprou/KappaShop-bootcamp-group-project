let object = {
    "userId": "2f5caca2-957a-4faa-946b-315dd92c96a0",
    "billingAddressId": 1,
    "submitDate": "2021-01-01",
    "items": [
        {
            "id": 5,
            "quantity": 2
        }
    ]
}
 
$(document).ready(function () {
    $("#order").on("click", function (e) {
        e.preventDefault();

        let fullName = $("#fname").val();
        let email = $("#email").val();
        let address = $("#adr").val();
        let city = $("#city").val();
        let zip = $("#zip").val();
        let cardName = $("cname").val();
        let cardNumber = $("#ccnum").val();
        let expireMonth = $("#expmonth").val();
        let expireYear = $("#expyear").val();
        let cvv = $("#cvv").val();

        let order = {
            fullname: fullName,
            email: email,
            address: address,
            city: city,
            zip: zip,
            cardName: cardName,
            cardNumber: cardNumber,
            expireMonth: expireMonth,
            expireYear: expireYear,
            cvv: cvv
        };

        console.log(order);

        /*$.ajax({
            type: "POST",
            url: "https://localhost:44342/api/Order",
            data: JSON.stringify(order),
            contentType: "application/json",
            success: function (response) {
                console.log(response);
                alert("Order sent Successfully!");
            }
        });*/
    });
}); 
