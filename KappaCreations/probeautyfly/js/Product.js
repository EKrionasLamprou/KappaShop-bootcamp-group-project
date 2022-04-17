function setApiCall() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Product?id=13",
        data: "json",
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {
            const canvas = (this.__canvas = new fabric.Canvas("canvas"));
            fillCanvas(canvas, reponse);
        },
        error: function (xhr) { },
    });
}

function fillCanvas(ele, data) {
    const canvas = (ele = new fabric.Canvas("canvas"));
    
    let texts = data.design.texts;
    let images = data.design.images;
    let objects = { objects: getCanvasItems(texts, images) };
    let fabricJSON = JSON.stringify(objects);

    canvas.loadFromJSON(fabricJSON, canvas.renderAll.bind(canvas), function (o, object) {
        fabric.log(o, object);
    });
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
            left: t.posX/2,
            top: t.posY/2,
            width: t.sizeWidth/2,
            height: t.sizeHeight/2,
            fill: "#"+t.colourHex,
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
            fontSize: t.fontSize/2,
            fontWeight: "normal",
            fontFamily: "Arial", 
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
                left: image.posX/2,
                top: image.posY/2,
                width: image.sizeWidth/2,
                height: image.sizeHeight/2,
                fill: "rgb(0,0,0)",
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
                filters: [{ type: "Tint", color: image.colourHex, opacity: 0.5 }],
                crossOrigin: ""
            },
            zIndex: image.zIndex,


          
          
        }
    }

    document.addEventListener("DOMContentLoaded", () => { setApiCall() });