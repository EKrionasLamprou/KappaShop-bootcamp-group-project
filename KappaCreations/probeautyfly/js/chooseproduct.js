const anchors = [...document.querySelectorAll(".test-nav-list a")];

const setLocalStorage = (key, value) => {
    localStorage.setItem(key, value);
}

const setProductData = () => {
    anchors.forEach((item) => {
        item.addEventListener("click", (e) => {

            const imageUrl = `/probeautyfly/printableImages/${e.currentTarget.innerText.toLowerCase()}.png`;
            setLocalStorage('ImageUrl', imageUrl);

            const category = item.id.slice(4);
            setLocalStorage('ProductCategory', category);


            const name = item.innerText.toLowerCase();
            setLocalStorage('ProductName', name);

        })
    });
}

document.addEventListener("DOMContentLoaded", () => { setProductData() })