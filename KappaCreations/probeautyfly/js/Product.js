function setApiCall() {
    /*const canvas = document.querySelector("#canvas");*/

    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Product?id=5",
        data: "json",
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response);
            const canvas = (this.__canvas = new fabric.Canvas("canvas"));
            let texts = response.design.texts;
            let images = response.design.images;
            let objects = { objects: getCanvasItems(texts, images) };

            //   const fabricJSON = '{"objects":[{"type":"image","originX":"left","originY":"top","left":0,"top":0,"width":550,"height":550,"fill":"rgb(0,0,0)","stroke":null,"strokeWidth":1,"strokeDashArray":null,"strokeLineCap":"butt","strokeLineJoin":"miter","strokeMiterLimit":10,"scaleX":1,"scaleY":1,"angle":0,"flipX":false,"flipY":false,"opacity":1,"shadow":null,"visible":true,"clipTo":null,"backgroundColor":"","src":"https://localhost:44342/probeautyfly/printableImages/mugs.jpg","filters":[],"crossOrigin":""},{"type":"text","originX":"left","originY":"top","left":138,"top":109,"width":52.35,"height":39,"fill":"red","stroke":null,"strokeWidth":1,"strokeDashArray":null,"strokeLineCap":"butt","strokeLineJoin":"miter","strokeMiterLimit":10,"scaleX":1,"scaleY":1,"angle":0,"flipX":false,"flipY":false,"opacity":1,"shadow":null,"visible":true,"clipTo":null,"backgroundColor":"","text":"test","fontSize":30,"fontWeight":"normal","fontFamily":"Arial","fontStyle":"","lineHeight":1.3,"textDecoration":"","textAlign":"left","path":null,"textBackgroundColor":"","useNative":true}]}'

            /*const JSon = JSON.stringify(canvas.toDatalessJSON(['id', 'lnk', 'lockUniScaling', 'borderColor', 'cornerColor', 'cornerSize']));*/

            /*canvas.clear();*/

            /*canvas.add(fabricJSON).renderAll().setActiveObject(fabricJSON);*/

            /*const JSon = JSON.stringify(canvas.toDatalessJSON(['type', 'originX', 'originY']));*/

            /*const json = canvas.toJSON(fabricJSON);*/
            // let fabricJSON = '{"objects":' + JSON.stringify(obj) + '}';
            let fabricJSON = JSON.stringify(objects);
            console.log(fabricJSON);


            canvas.loadFromJSON(fabricJSON, canvas.renderAll.bind(canvas), function (o, object) {
                console.log("HI");
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

function getCanvasItems(texts, images) {
    let items = [];

    for (let text of texts) {
        items.push(mapTextToCanvas(text));
    }
    for (let image of images) {
        items.push(mapImageToCanvas(image));
    }

    items.sort((a, b) => a.zIndex - b.zIndex);

    return items.map(item => item.data);
}

function mapTextToCanvas(t) {
    return {
        data: {
            type: "text",
            originX: "left",
            originY: "top",
            left: t.posX,
            top: t.posY,
            width: t.sizeWidth,
            height: t.sizeHeight,
            fill: t.colourHex,
            stroke: null,
            strokeWidth: 1,
            strokeDashArray: null,
            strokeLineCap: "butt",
            strokeLineJoin: "miter",
            strokeMiterLimit: 10,
            scaleX: 1,
            scaleY: 1,
            angle: 0,
            flipX: false,
            flipY: false,
            opacity: 1,
            shadow: null,
            visible: true,
            clipTo: null,
            backgroundColor: "",
            text: t.content,
            fontSize: 30,
            fontWeight: "normal",
            fontFamily: "Arial", // TO DO
            fontStyle: "",
            lineHeight: 1.3,
            tDecoration: "",
            tAlign: "left",
            path: null,
            tBackgroundColor: "",
            useNative: true,
        },
        zIndex: t.zIndex
    }
}

    function mapImageToCanvas(image) {
        return {
            data: {
                type: "image",
                originX: "left",
                originY: "top",
                left: image.posX,
                top: image.posY,
                width: image.sizeWith,
                height: image.heightWith,
                fill: image.colourHex,
                stroke: null,
                strokeWidth: 1,
                strokeDashArray: null,
                strokeLineCap: "butt",
                strokeLineJoin: "miter",
                strokeMiterLimit: 10,
                scaleX: 1,
                scaleY: 1,
                angle: 0,
                flipX: false,
                flipY: false,
                opacity: image.colourAlpha,
                shadow: null,
                visible: true,
                clipTo: null,
                backgroundColor: "",
                src: image.url,
            },
            zIndex: image.zIndex,
            filters: [
            ],
            crossOrigin: ""
        }
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
