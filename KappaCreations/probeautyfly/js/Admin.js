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
        url:'https://localhost:44342/api/commentApi',
        dataType: "json",
        success: function (data) {
            console.log("cat");
            let commentNumber = document.getElementById(commentNo);
            $(commentNumber).text(data.count);
        },
        error: function () {
            let commentNumber = document.getElementById(commentNo);
            $(commentNumber).html("Zero");
        }
    })
})