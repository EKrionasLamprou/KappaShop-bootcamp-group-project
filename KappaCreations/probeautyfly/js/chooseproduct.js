////$('.test-nav-list a').each(icon => {
////    icon.click(function (e) {

////        e.preventDefault();
////        console.log(icon.text());
////        localStorage.setItem('ImageUrl', 'Anna');
////    })
////}) 

const anchors = [...document.querySelectorAll(".test-nav-list a")]


anchors.forEach((icon) => {
    icon.addEventListener("click", (e) => {

        const imageUrl = `/probeautyfly/printableImages/${e.currentTarget.innerText.toLowerCase()}.jpg`

        localStorage.setItem('ImageUrl', imageUrl);

    })
})