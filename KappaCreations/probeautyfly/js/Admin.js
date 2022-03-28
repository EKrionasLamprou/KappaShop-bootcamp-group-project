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
        type: "GET",
        url: "api/CommentApi/GetCountAsync",
        contentType: "application/json",
        dataType: "json",
        success: function (count) {
            let commentNumber = document.getElementById(commentNo);
            $(commentNumber).append(count);
        }
    })
})