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


function initCanvas() {

    var ctx = document.getElementById("canvas").getContext("2d");
    ctx.fillStyle = "orange";
    ctx.fillRect(0, 0, 500, 500);

    //JSON object
    var buildings = [
        { "id": "ID1", "px": 10, "py": 50, "w": 60, "h": 60, "bgColor": "black" },
        { "id": "ID2", "px": 110, "py": 50, "w": 60, "h": 60, "bgColor": "grey" },
        { "id": "ID3", "px": 220, "py": 50, "w": 60, "h": 60, "bgColor": "yellow" }
    ];

    for (var i = 0; i < buildings.length; i++) {
        var line = buildings[i];
        ctx.fillStyle = line.bgColor;
        ctx.fillRect(line.px, line.py, line.w, line.h);
    }

}

window.addEventListener('load', function (event) {
    initCanvas();
});
