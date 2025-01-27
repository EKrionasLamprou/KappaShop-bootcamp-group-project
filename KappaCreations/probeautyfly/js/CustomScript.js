﻿const designerId = $("#designerId").text();

const url = localStorage.getItem("ImageUrl");
const category = localStorage.getItem("ProductCategory");
const name = localStorage.getItem("ProductName");

const uploadedImagesCount = ["default"];

const cloudName = "dj3kkbjpi";
const cloudApiKey = "783748518282284";
const cloudApiSecret = "Jbp2bErMwYHRiDuiWAW8h1gz-io";
const cloudApiEnvironmentVar = "CLOUDINARY_URL=cloudinary://783748518282284:Jbp2bErMwYHRiDuiWAW8h1gz-io@dj3kkbjpi";
const cloupUploadPreset = "p7ytvqur";

let uploadImages = [];

let activateAddToCart = false;

var select_item = "";
var select_price = "+0";
var price = 10;

var item_list = [];

var rectboxX = 130,
    rectboxY = 352,
    rectboxWidth = 480,
    rectboxHeight = 500;
let productPrice = 0;

function getPrice() {

    switch (category) {
        case "1": productPrice = 8; break;
        case "2": productPrice = 10; break;
        case "3": productPrice = 30; break;
        case "4": productPrice = 20; break;
        case "5": productPrice = 10; break;
        case "6": productPrice = 30; break;
        case "7": productPrice = 5; break;
        case "8": productPrice = 7; break;
        case "9": productPrice = 7; break;
        case "10": productPrice = 20; break;
        case "11": productPrice = 20; break;
        case "12": productPrice = 10; break;
        case "13": productPrice = 15; break;
        case "14": productPrice = 10; break;
        case "15": productPrice = 3; break;
        default:
    }
    $(".create-side-price").html('€' + productPrice);
};

//PRICE FIELD START
function updatePrice(price_change) {
    var regExp = /(\=|\+|\-)(\d+)/;
    var result, result_sign, result_no;


    if ((result = regExp.exec(price_change)) != null) {
        if (result.index === regExp.lastIndex) {
            regExp.lastIndex++;
        }
        result_sign = result[1];
        result_no = result[2];
    }

    if (!result_no) {
    } else if (result_sign == "=") {
        price = price_change;
    } else if (result_sign == "+") {
        price += price_change;
    } else if (result_sign == "-") {
        price -= price_change;
    }

    /* Update Price */
    $("#price").html(price);
}
//PRICE FIELD END

function setApiCall(data) {
    $.ajax({
        type: "Post",
        url: "https://localhost:44342/api/Product",
        data: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) { },
    });
}

$(document).ready(function () {
    $('.create-side-title').text(`${name}`);

    if (activateAddToCart === false) {
        $("#addToCart").prop('disabled', true);
    }

    getPrice();
    updatePrice();

    $("#boxEdit").show();

    $("#boxEditText, #boxEditImage").hide();

    $(".ui.dropdown").dropdown();

    $("#libraryButton").on("click", function () {
        select_item = "";
        $(".library.modal").modal("show");
    });

    $(".library")
        .find(".item")
        .on("click", function () {
            $(".item").removeClass("active");
            select_item = $(this).find("img").attr("src");
            select_price = $(this).attr("data-price");
            $(this).addClass("active");
        });

    $("#libAddButton").on("click", function () {
        if (select_item === "") return;
        var imgObj = new Image();
        imgObj.src = select_item;
        imgObj.onload = function () {
            // start fabricJS stuff

            var image = new fabric.Image(imgObj);
            image.scale(0.5).set({
                left: 0,
                right: 0,
            });

            image.on("selected", function () {
                var obJ = canvas.getActiveObject();

                $("#boxEdit, #boxEditText").hide();
                $("#boxEditImage").show();
            });

            image.itemPrice = select_price;

            item_list.push(image);
            canvas.setActiveObject(image).add(image);

            console.log(canvas.getObjects().indexOf(image));

            // end fabricJS stuff

            updatePrice(select_price);
        };
    });

    var canvas = (this.__canvas = new fabric.Canvas("c"));
    fabric.Object.prototype.transparentCorners = false;
   
    var radius = 300;

    fabric.Image.fromURL(url, function (img) {
        img.set({
            width: 550,
            height: 550,
            left: 0,
            top: 0,
            selectable: false,
            hasControls: false,
            hasBorders: false,
        });

        const colorLight = document.getElementById('colorLight')
        if (!colorLight) return;
        colorLight.addEventListener('change', function (e) {
            img.filters[0] = new fabric.Image.filters.Tint({
                color: e.target.value,
                opacity: 0.5
            });
            img.applyFilters(canvas.renderAll.bind(canvas));
        });

        canvas.add(img).setActiveObject(img);
        item_list.push(img);

        rectbox = new fabric.Rect({
            width: rectboxWidth,
            height: rectboxHeight,
            left: 35,
            top: 35,
            stroke: "rgba(0,0,0,0.3)",
            strokeWidth: 2,
            fill: "rgba(0,0,0,0)",
            selectable: false,
            hasControls: false,
            hasBorders: false,
        });

        canvas.add(rectbox);

        var recttext = new fabric.Text("Printable Area", {
            fontSize: 14,
            fontFamily: "sans-serif",
            left: 180,
            top: 330,
            fill: "rgba(0,0,0,0.3)",
            selectable: false,
            hasControls: false,
            hasBorders: false,
        });

      
        // END  Area
    });

    $("#addTextButton").on("click", function () {
        var inText = $("#inputText").val();

        if (inText.trim() === "") {
            alert("Please type text");
            return;
        }

        var inFont = $("#inputFont").val();
        var inSize = 30;
        var inColor = $("#inputColor").val();
        var canvasConfig = true;

        var newText = new fabric.Text(inText, {
            fontSize: inSize,
            fontFamily: inFont,
            fill: inColor,
        });
        newText.setControlsVisibility({
            mt: false, 
            mb: false, 
            ml: false, 
            mr: false, 
        });

        newText.on("selected", function () {
            var obJ = canvas.getActiveObject();

            // Update Edit Text
            $("#editText").val(obJ.text);
            $("#uiEditFont").dropdown("set selected", obJ.fontFamily);
            $("#uiEditFont").dropdown("set value", obJ.fontFamily);
            $("#uiEditColor").dropdown("set selected", obJ.fill);
            $("#uiEditColor").dropdown("set value", obJ.fill);

            $("#boxEdit, #boxEditImage").hide();
            $("#boxEditText").show();

        });
  
        canvas.on('object:scaling', function (evt) {
            /*     canvas.getActiveObject();*/
            var fontSizeX = evt.target.scaleX;
            var fontSizeY = evt.target.scaleY;
            if (fontSizeX === fontSizeY) {
                evt.target.fontSize = fontSizeX * 100;
                console.log(evt.target.fontSize);
            }

        });
        newText.zIndex = canvas.getObjects().indexOf(newText);

        canvas.setActiveObject(newText).add(newText);

        item_list.push(newText);
       
    });

    $("#updateTextButton").on("click", function () {
        var inText = $("#editText").val();

        if (inText.trim() === "") {
            $(".trashButton").trigger("click");
            return;
        }

        var inFont = $("#editFont").val();
        var inSize = 30;
        var inColor = $("#editColor").val();

        var TexttoEdit = canvas.getActiveObject();
        TexttoEdit.setText(inText).setFontFamily(inFont).setFontSize(inSize).setFill(inColor);

        canvas.renderAll();
    });

    if (!document.getElementById("imgLoader")) {
        return;
    } else {
        document.getElementById("imgLoader").onchange = function handleImage(e) {
            // Upload User Image to Cloud
            uploadedImagesCount.push(e.target.files[0]);

            // Check for available file
            if ($("#imgLoader").val().length < 1) {
                // No file Uploaded
                console.log("No file uploaded");
                return false;
            }

            // Check file extensions
            var fileExt = $("#imgLoader").val().split(".").pop().toLowerCase();
            if ($.inArray(fileExt, ["png", "jpg", "jpeg"]) == -1) {
                alert("You cannot upload this file. Please upload only .png, .jpg, or .jpeg images.");
                $("#file").val("");
                return false;
            }

            var reader = new FileReader();
            reader.onload = function (event) {
                var imgObj = new Image();
                imgObj.src = event.target.result;
                imgObj.onload = function () {
                    // start fabricJS stuff

                    var image = new fabric.Image(imgObj);
                    image.set({
                        left: 0,
                        right: 0,
                    });

                    image.on("selected", function () {
                        var obJ = canvas.getActiveObject();

                        $("#boxEdit, #boxEditText").hide();
                        $("#boxEditImage").show();
                    });

                    canvas.on('object:scaling', function () {
                        var obj = canvas.getActiveObject(),
                            width = obj.width,
                            height = obj.height,
                            scaleX = obj.scaleX,
                            scaleY = obj.scaleY;

                        obj.set({
                            width: width * scaleX,
                            height: height * scaleY,
                            scaleX: 1,
                            scaleY: 1
                        });
                    });

                    document.getElementById('colorDark').addEventListener('change', function (e) {
                        image.filters[0] = new fabric.Image.filters.Tint({
                            color: e.target.value,
                            opacity: 0.5
                        });
                        image.applyFilters(canvas.renderAll.bind(canvas));
                    });
                    canvas.setActiveObject(image).add(image);

                    item_list.push(image);


                    // end fabricJS stuff
                };
            };
            reader.readAsDataURL(e.target.files[0]);
        };
    }

    $("#tempSave").on("click", function () {
        const rowData = JSON.stringify(item_list);
        const data = JSON.parse(rowData);

        const text = data.filter((item) => item.type === "text");

        if (designerId == "0") {
            alert("Please Register Or Login To create your Product")
            return
        }

        if (uploadedImagesCount.length === 1 && uploadedImagesCount[0] === "default" && text.length < 1) {
            alert("Please add Text or Image");
            return;
        }

        if (uploadedImagesCount.length > 1) uploadedImagesCount.shift();

        if (uploadedImagesCount[0] === "default") {
            uploadImages = []
        } else {
            uploadedImagesCount.map((file) => {
                const formData = new FormData();
                formData.append("file", file);
                formData.append("upload_preset", cloupUploadPreset);

                axios({
                    url: `https://api.cloudinary.com/v1_1/${cloudName}/upload`,
                    method: "POST",
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    },
                    data: formData
                }).then(function (res) { uploadImages.push(res.data.secure_url) }).catch(function (err) { console.log(err) });
            });
        }

        activateAddToCart = true
        $("#addToCart").prop('disabled', false);
    });

    $(".trashButton").on("click", function () {
        $("#modalDelete")
            .modal("setting", {
                onDeny: function () { },
                onApprove: function () {
                    var obJ = canvas.getActiveObject();

                    // Remove from item_list
                    var obJindex = item_list.indexOf(obJ);
                    if (obJindex > -1) {
                        item_list.splice(obJindex, 1);
                    }

                    // Remove from canvas
                    obJ.remove();
                    clearSelection();
                },
            })
            .modal("show");

        return false;
    });

    $("#resetButton").on("click", function () {
        var iLength = item_list.length;
        for (var i = 0; i < iLength; i++) {
            canvas.remove(item_list[i]);
        }
        item_list = [];
    });

    canvas.on("selection:cleared", function () {
        clearSelection();
    });

    function clearSelection() {
        $("#boxEditImage, #boxEditText").hide();
        $("#boxEdit").show();
    }

    $("#getdata-button").on("click", function () {
        alert(JSON.stringify(item_list));
        console.log(JSON.stringify(item_list));
      
    });

    $("#addToCart").on("click", function () {
      
        const rowData = JSON.stringify(item_list);
        const data = JSON.parse(rowData);

        if (data.length === 1) return;

        const dataImages = data
            .filter((item) => item.type === "image")
            .map((item, index) => {
                if (index === 0) {
                    return {
                        posX: item.left,
                        posY: item.top,
                        zIndex: data.indexOf(item), 
                        sizeWidth: item.width,
                        sizeHeight: item.height,
                        colourHex: item.filters.length !== 0 ? item.filters[0].color : "#ffffff",
                        colourAlpha: 1,
                        url: item.src,
                    };
                }

                return {
                    posX: item.left,
                    posY: item.top,
                    zIndex: data.indexOf(item),
                    sizeWidth: item.width,
                    sizeHeight: item.height,
                    colourHex: item.filters.length !== 0 ? item.filters[0].color : "#ffffff",
                    colourAlpha: 1,
                    url: uploadImages.length === 1 ? uploadImages[0] : uploadImages[index - 1],
                };
            });

        const dataTexts = data
            .filter((item) => item.type === "text")
            .map((item) => {
                return {
                    posX: item.left,
                    posY: item.top,
                    zIndex: data.indexOf(item),
                    sizeWidth: item.width,
                    sizeHeight: item.height,
                    colourHex: item.fill,
                    colourAlpha: item.opacity,
                    content: item.text,
                    fontSize: item.fontSize,
                    font: item.fontFamily
                };
            });


        const design = {
            design: {
                images: dataImages,
                texts: dataTexts,
            },
            categoryId: Number(category),
            designerId: designerId
        };

        console.log(design);

        setApiCall(design);

        alert("Your Product created Successfully!")

        //var image = $("#image");
        //var img = canvas.toDataURL("image/png");
        //image.src = img;
        //document.write('<img src="' + img + '"/>');
    });
});
