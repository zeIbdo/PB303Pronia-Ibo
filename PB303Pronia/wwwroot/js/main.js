﻿const addToBasketButtons = document.querySelectorAll(".addToBasketBtn");
const basketArea = document.querySelector(".basketPartial");

addToBasketButtons.forEach(btn => {

    btn.addEventListener('click', async (e) => {
        e.preventDefault();

        const response = await fetch(btn.href); 
        const partial = await response.text();

        basketArea.innerHTML = partial;
    })
})


