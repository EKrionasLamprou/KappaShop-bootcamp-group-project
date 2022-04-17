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

/*let list = document.querySelectorAll('.navigation li');
function activeLink() {
    list.forEach((item) =>
        item.classList.remove('hovered'));
        this.classList.add('hovered');
} 
list.forEach((item) => item.addEventListener('mouseover', activeLink)); */


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
    $.ajax({
        type: "GET",
        url: urlBase + 'adminStats/categoriesByOrders',
        dataType: "json",
        success: function (data) {
            let topCategories = $("#topCat");
            $(topCategories).text(data.slice(0, 3).map(c => c.categoryId).join(", ")); // to be changed to category names
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
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Order",
        dataType: "json",
        success: function (data) {
            /*console.log(data);*/
        },
        error: function () {
            console.log("Error. Failed to load the number of comments.");
        }
    });

    const apiCallData = [
        {
            id: 1,
            orderStatus: "Pending",
            submitDate: "17/04/2022",
            userId: "f923c654-177d-4034-87db-adf763d7869f",
            billingAddressId: 1,
            items: [
                {
                    id: 1,
                    quantity: 5,
                    productId: 1,
                    orderId: 1,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 1,
                    orderId: 2,
                },
                {
                    id: 3,
                    quantity: 5,
                    productId: 3,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 3,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 8,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 8,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 8,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 8,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 9,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 10,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 11,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 12,
                    orderId: 2,
                },
                {
                    id: 4,
                    quantity: 5,
                    productId: 13,
                    orderId: 2,
                },
            ],
            itemsCount: 5,
            totalCost: 40.0,
        },
        {
            id: 2,
            orderStatus: "Pending",
            submitDate: "17/04/2022",
            userId: "f923c654-177d-4034-87db-adf763d7869f",
            billingAddressId: 1,
            items: [
                {
                    id: 2,
                    quantity: 5,
                    productId: 2,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 4,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 5,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 5,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 5,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 6,
                    orderId: 2,
                },
                {
                    id: 2,
                    quantity: 5,
                    productId: 7,
                    orderId: 2,
                },
            ],
            itemsCount: 5,
            totalCost: 40.0,
        },
    ];

    const items = apiCallData.map((item) => item.items).flat(Infinity).map((item) => item.productId)

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

    const chartData = [ashtrays, bags, bedSheets, canvas, doorMats, hoodies, magnets, mousepads, mugs, phoneCases, pillows, plates, tShirts, thermoBottles, tissues]

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

    const data = {
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
        data: data,
        options: {}
    };

    const myChart = new Chart(
        document.getElementById('myChart'),
        config
    );
})