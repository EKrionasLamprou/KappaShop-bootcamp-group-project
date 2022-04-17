const urlBase = '../../api/';

//Menu Toggle

let toggle = document.querySelector('.toggle');
let navigation = document.querySelector('.navigation');
let main = document.querySelector('.main');

toggle.onclick = function () {
    navigation.classList.toggle('active');
    main.classList.toggle('active');

}




//Number of comments

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: urlBase + 'comment/count',
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
        type: "GET",
        url: urlBase + 'order/count',
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

    function getPrice(category) {
        switch (category) {
            case 1: return "Ashtrays"; break;
            case 2: return "Bags"; break;
            case 3: return "Bed-Sheets"; break;
            case 4: return "Canvas"; break;
            case 5: return "Door-Mats"; break;
            case 6: return "Hoodies"; break;
            case 7: return "Magnets"; break;
            case 8: return "Mousepads"; break;
            case 9: return "Mugs"; break;
            case 10: return "Phone-Cases"; break;
            case 11: return "Pillows"; break;
            case 12: return "Plates"; break;
            case 13: return "T-Shirts"; break;
            case 14: return "Thermos-Bottles"; break;
            case 15: return "Tissues"; break;
            default:
        }
    };


    $.ajax({
        type: "GET",
        url: urlBase + 'adminStats/categoriesByOrders',
        dataType: "json",
        success: function (data) {

            const categories = data.map((item, index, arr) => {
                if (index !== arr.length - 1) {
                    return `<span id="categoryId-${item.categoryId}">${getPrice(item.categoryId)}</span>, `
                } else {
                   return `<span id="categoryId-${item.categoryId}">${getPrice(item.categoryId)}</span>`
                }

            });
            console.log(categories)
            let topCategories = $("#topCat");
            $(topCategories).html(categories);
        },
        error: function () {
            console.log("Error. Failed to load the top categories.");
        }
    })
})

//Total earnings
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: urlBase + 'adminStats/totalEarnings',
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

//Tabs
$(document).ready(function () {
    const tabsButtons = document.querySelectorAll(".tabs__button");

    if (!tabsButtons) return;

    tabsButtons.forEach((btn) => {
        btn.addEventListener("click", (e) => {
            e.preventDefault();
            const tabsMenu = btn.parentElement;
            const tabs = tabsMenu.parentElement.parentElement;
            const tabsNumber = btn.dataset.forTab;
            const tabToActivate = tabs.querySelector(".tabs__content-container").querySelector(`.tabs__content[data-tab="${tabsNumber}"]`);

            tabsMenu.querySelectorAll(".tabs__button").forEach((btn) => {
                btn.classList.remove("active");
            });

            tabs.querySelector(".tabs__content-container")
                .querySelectorAll(".tabs__content")
                .forEach((cnt) => {
                    cnt.classList.remove("active");
                });

            btn.classList.add("active");
            tabToActivate.classList.add("active");
        });
    });
})

//Chart
$(document).ready(function () {
    const labels = [
        'Ashtrays',
        'Bags',
        'Bed-Sheets',
        'Canvas',
        'Door-Mats',
        'Hoodies',
        'Magnets',
        'Mousepads',
        'Mugs',
        'Phone-Cases',
        'Pillows',
        'Plates',
        'T-Shirts',
        'Thermos-Bottles',
        'Tissues',
    ];

    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Order",
        dataType: "json",
        success: function (data) {
            /*console.log(data.data);*/
            const items = data.data.map((item) => item.items).flat(Infinity).map((item) => item.productCategoryId)

            const ashtrays = items.filter((item) => item === 1).length;
            const bags = items.filter((item) => item === 2).length;
            const bedSheets = items.filter((item) => item === 3).length;
            const canvas = items.filter((item) => item === 4).length;
            const doorMats = items.filter((item) => item === 5).length;
            const hoodies = items.filter((item) => item === 6).length;
            const magnets = items.filter((item) => item === 7).length;
            const mousepads = items.filter((item) => item === 8).length;
            const mugs = items.filter((item) => item === 9).length;
            const phoneCases = items.filter((item) => item === 10).length;
            const pillows = items.filter((item) => item === 11).length;
            const plates = items.filter((item) => item === 12).length;
            const tShirts = items.filter((item) => item === 13).length;
            const thermoBottles = items.filter((item) => item === 14).length;
            const tissues = items.filter((item) => item === 15).length;

            const chartData = [ashtrays, bags, bedSheets, canvas, doorMats, hoodies, magnets, mousepads, mugs, phoneCases, pillows, plates, tShirts, thermoBottles, tissues];

            const chartRenderData = {
                labels: labels,
                datasets: [{
                    label: 'Products Categories',
                    backgroundColor: '#1dabb8',
                    borderColor: '#1dabb8',
                    data: chartData,
                }]
            };

            const config = {
                type: 'bar',
                data: chartRenderData,
                options: {}
            };

            const myChart = new Chart(
                document.getElementById('myChart'),
                config
            );
        },
        error: function () {
            console.log("Error. Failed to load the number of comments.");
        }
    });



})