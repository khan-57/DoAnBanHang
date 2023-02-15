sizeChoose = document.querySelectorAll(".size-choose");
const sizeDes = document.querySelectorAll(".size-des");
const quantity = document.querySelector(".quantity");
const plus = document.querySelector("#plus");
const minus = document.querySelector("#minus");
const clear = document.querySelectorAll(".btn-clear");
for (let i = 0; i < sizeChoose.length; i++) {
    sizeDes[i].addEventListener('click', function () {
        sizeDes.forEach(label => {
            label.classList.remove("checked")
        })
        sizeDes[i].classList.add("checked")
    })
}
console.log(plus);
plus.addEventListener('click', () => {
    let number = Number(quantity.value);

    quantity.value = number + 1;
})
minus.addEventListener('click', () => {
    let number = Number(quantity.value);
    quantity.value = number - 1;
})
for (let i = 0; i < clear.length; i++) {
    clear[i].addEventListener('click', () => {
        clear[i].parentElement.parentElement.remove();
    })
}
function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}
//document.getElementById("btn").onclick = function () {

//    var checkbox = document.getElementsByName("size");
//    for (var i = 0; i < checkbox.length; i++) {
//        if (checkbox[i].checked === true) {
//           console.log(checkbox[i].value);
//        }
//    }
//    //Console.log(Session.Contents["a"]);
//};
