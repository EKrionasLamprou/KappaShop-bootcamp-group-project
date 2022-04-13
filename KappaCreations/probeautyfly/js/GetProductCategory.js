function ApiCall() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Product",
        data: "json",
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {

            console.log(response.map((item) => item.categoryId));
            console.log("Kalinixta");
        },
        error: function (xhr) { },


    }
    )
};
document.addEventListener("DOMContentLoaded", () => { ApiCall() });

