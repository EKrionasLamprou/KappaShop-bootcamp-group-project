function setApiCall() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Product",
        /* data: JSON.stringify(data),*/
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) { },
    });
}

document.addEventListener("DOMContentLoaded", () => { setApiCall() });