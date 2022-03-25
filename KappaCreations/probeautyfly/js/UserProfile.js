function setUpTabs() {
    document.querySelectorAll(".tabs__button").forEach((btn) => {
        btn.addEventListener("click", (e) => {
            e.preventDefault();
            const tabsMenu = btn.parentElement;
            const tabs = tabsMenu.parentElement;
            const tabsNumber = btn.dataset.forTab;
            const tabToActivate = tabs.querySelector(".tabs__content-container").querySelector(`.tabs__content[data-tab="${tabsNumber}"]`);

            tabsMenu.querySelectorAll(".tabs__button").forEach((btn) => {
                btn.classList.remove("tabs__button--active");
            });

            tabs.querySelector(".tabs__content-container")
                .querySelectorAll(".tabs__content")
                .forEach((cnt) => {
                    cnt.classList.remove("tabs__content--active");
                });

            btn.classList.add("tabs__button--active");
            tabToActivate.classList.add("tabs__content--active");
        });
    });
}

function SetTabsFromIcons() {
    document.querySelectorAll(".tabs__icon").forEach((icon) => {
        icon.addEventListener("click", (e) => {
            e.preventDefault();
            const tabsMenu = icon.closest(".tabs__content-container").previousElementSibling;
            const tabs = tabsMenu.parentElement;
            const tabsNumber = icon.dataset.forTab;
            const tabToActivate = tabs.querySelector(".tabs__content-container").querySelector(`.tabs__content[data-tab="${tabsNumber}"]`);

            tabsMenu.querySelectorAll(".tabs__button").forEach((icon) => {
                icon.classList.remove("tabs__button--active");
            });

            tabs.querySelector(".tabs__content-container")
                .querySelectorAll(".tabs__content")
                .forEach((cnt) => {
                    cnt.classList.remove("tabs__content--active");
                });

            document.querySelector(".tabs__menu").querySelector(`.tabs__button[data-for-tab="${tabsNumber}"]`).classList.add("tabs__button--active")

            //icon.classList.add("tabs__button--active");
            tabToActivate.classList.add("tabs__content--active");
        });
    });
}



document.addEventListener("DOMContentLoaded", () => { setUpTabs(), SetTabsFromIcons() });