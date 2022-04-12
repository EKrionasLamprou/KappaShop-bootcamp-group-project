const urlBase = '../../api/';

//Menu Toggle

    let toggle = document.querySelector('.toggle');
    let navigation = document.querySelector('.navigation');
    let main = document.querySelector('.main');

    toggle.onclick = function () {
        navigation.classList.toggle('active');
        main.classList.toggle('active');

    }


    //add hovered class in selected list item

    let list = document.querySelectorAll('.navigation li');
    function activeLink() {
        list.forEach((item) =>
            item.classList.remove('hovered'));
        this.classList.add('hovered');
    }
    list.forEach((item) =>
        item.addEventListener('mouseover', activeLink));


//Number of comments

$(document).ready(function () {
    $.ajax({
        type:"GET",
        url: urlBase +'comment/count',
        dataType: "json",
        success: function (data) {
            let commentNumber = $("#commentNo");
            $(commentNumber).text(data.count);
        },
        error: function () {
            console.log("Error. Failed to load the number of comments.");
        }
    })
})

//Total orders
$(document).ready(function () {
    $.ajax({
        type:"GET",
        url:urlBase +'order/count',
        dataType: "json",
        success: function (data) {
            let orderNumber = $("#totalOrders");
            $(orderNumber).text(data.count);
        },
        error: function () {
            console.log("Error. Failed to load the number of orders.");
        }
    })
})
//Top 3 categories
$(document).ready(function () {
    $.ajax({
        type:"GET",
        url: urlBase +'adminStats/categoriesByOrders',
        dataType: "json",
        success: function (data) {
            let topCategories = $("#topCat");
            $(topCategories).text(data.names.take(3).join(", "));
        },
        error: function () {
            console.log("Error. Failed to load the top categories.");
        }
    })
})
//Total earnings
$(document).ready(function () {
    $.ajax({
        type:"GET",
        url: urlBase +'adminStats/totalEarnings',
        dataType: "json",
        success: function (data) {
            let earnings = $("#totalAmount");
            $(earnings).text(data.totalEarnings);
        },
        error: function () {
            console.log("Error. Failed to load the amount.");
        }
    })
})