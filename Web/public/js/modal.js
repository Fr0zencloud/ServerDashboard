
let modals = document.getElementsByClassName('modal');
let buttons = document.getElementsByTagName('button');

for (let modal of modals) {
  let addButton = modal.children[0].children[0].children[2].children[0]
  let cancelButton = modal.children[0].children[0].children[2].children[1]

  //close modal if clicked on the closing (x) span
  modal.children[0].children[0].children[0].addEventListener("click", function () { closeModal(modal) });
  cancelButton.addEventListener("click", function () { closeModal(modal) });
}

for (let btn of buttons) {
  if (btn.dataset.modal) {
    let modal = document.getElementById(btn.dataset.modal)
    btn.addEventListener("click", function () { openModal(modal) });
  }

}

function openModal(modal) {
  modal.style.display = "block"
}

function closeModal(modal) {
  modal.style.display = "none";
}


window.onclick = function (event) {
  for (let modal of modals) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }
}
