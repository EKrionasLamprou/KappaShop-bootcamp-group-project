function setApiCall() {
    /*const canvas = document.querySelector("#canvas");*/

    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Product",
        data: "json",
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response);

            const canvas = (this.__canvas = new fabric.Canvas("canvas"));

            /*canvas.loadFromJSON(response, function () {
                canvas.renderAll();
            });*/

            const fabricJSON = '{"objects":[{"type":"image","originX":"left","originY":"top","left":0,"top":0,"width":550,"height":550,"fill":"rgb(0,0,0)","stroke":null,"strokeWidth":1,"strokeDashArray":null,"strokeLineCap":"butt","strokeLineJoin":"miter","strokeMiterLimit":10,"scaleX":1,"scaleY":1,"angle":0,"flipX":false,"flipY":false,"opacity":1,"shadow":null,"visible":true,"clipTo":null,"backgroundColor":"","src":"https://localhost:44342/probeautyfly/printableImages/mugs.jpg","filters":[],"crossOrigin":""},{"type":"text","originX":"left","originY":"top","left":138,"top":109,"width":52.35,"height":39,"fill":"red","stroke":null,"strokeWidth":1,"strokeDashArray":null,"strokeLineCap":"butt","strokeLineJoin":"miter","strokeMiterLimit":10,"scaleX":1,"scaleY":1,"angle":0,"flipX":false,"flipY":false,"opacity":1,"shadow":null,"visible":true,"clipTo":null,"backgroundColor":"","text":"test","fontSize":30,"fontWeight":"normal","fontFamily":"Arial","fontStyle":"","lineHeight":1.3,"textDecoration":"","textAlign":"left","path":null,"textBackgroundColor":"","useNative":true}]}'

            /*const JSon = JSON.stringify(canvas.toDatalessJSON(['id', 'lnk', 'lockUniScaling', 'borderColor', 'cornerColor', 'cornerSize']));*/

            /*canvas.clear();*/

            /*canvas.add(fabricJSON).renderAll().setActiveObject(fabricJSON);*/

            /*const JSon = JSON.stringify(canvas.toDatalessJSON(['type', 'originX', 'originY']));*/

            /*const json = canvas.toJSON(fabricJSON);*/

            canvas.loadFromJSON(fabricJSON, canvas.renderAll.bind(canvas), function (o, object) {
                fabric.log(o, object);
            });
        },

        error: function (xhr) { },

    });

    /*var json = JSON.stringify(canvas);
    canvas.clear();
    canvas.loadFromJSON(json, function () {
        canvas.renderAll();
    });*/
}

document.addEventListener("DOMContentLoaded", () => { setApiCall() });


/*function initCanvas() {
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
});*/
