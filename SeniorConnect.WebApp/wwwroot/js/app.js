
// functie voor slideshow

let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("slide");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "block";
    setTimeout(showSlides, 2000);


}


// hieronder voor hamburger menu op mobiele versie

const mobileMenu = document.getElementById("mobile-menu");
const navList = document.querySelector("nav");

mobileMenu.addEventListener("click", () => {
    navList.classList.toggle("active");
});




