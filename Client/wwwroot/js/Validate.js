jQuery.validator.setDefaults({
    debug: true,
    success: "valid"
});

$("#formClass").validate({

    ignore: [],
    debug: false,
    rules: {
        tittleCls: {
            required: true,
            minlength: 3
        },
        url: {
            required: true,
            minlength: 3
        },
        Desc: {
            required: function () {
                editor.getData();
            },
            minlength: 10
        },
        TotalChapter: {
            required: true,
            digits: true
        },
        price: {
            required: true,
            digits: true
        },
        level: {
            required: true
        },
        category: {
            required: true
        }
    },
    messages: {
        tittleCls: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter text',
            minlength: '<i class="bi bi-x-octagon-fill"></i> Min 3 Character'
        },
        url: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter Url',
            minlength: '<i class="bi bi-x-octagon-fill"></i> Please enter 10 characters'
        },
        Desc: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter description',
            minlength: '<i class="bi bi-x-octagon-fill"></i> Please enter 10 characters'
        },
        TotalChapter: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter text',
            digits: '<i class="bi bi-x-octagon-fill"></i> Should use digits!'
        },
        price: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter Price',
            digits: '<i class="bi bi-x-octagon-fill"></i> Should use digits!'
        },
        level: {
            required: '<i class="bi bi-x-octagon-fill"></i> Required!'
        },
        category: {
            required: '<i class="bi bi-x-octagon-fill"></i> Required!'
        }
    }
});


const formClass = document.querySelector("#formClass")
const tittle = document.querySelector("#judul");
const url = document.querySelector("#url");
const totChapter = document.querySelector("#totChapter");
const price = document.querySelector("#price");
const level = document.querySelector("#level");
const cate = document.querySelector("#cate");

formClass.addEventListener("submit", submitForm);

function submitForm(e) {
    e.preventDefault();

    const tittleValue = tittle.value;
    const urlValue = url.value;
    const totChapterValue = totChapter.value;
    const priceValue = price.value;
    const levelValue = level.value;
    const cateValue = cate.value;
    console.log(tittleValue);

    if (tittleValue === "") {
        tittle.style.border = "2px solid red";
    } else {
        tittle.style.border = "none";
    }

    if (urlValue === "") {
        url.style.border = "2px solid red";
    }

    if (totChapterValue === "") {
        totChapter.style.border = "2px solid red";
    }

    if (priceValue === "") {
        price.style.border = "2px solid red";
    }

    if (levelValue === "~Choose Level~") {
        level.style.border = "2px solid red";
    }

    if (cateValue === "~Choose Category Class~") {
        cate.style.border = "2px solid red";
    }
}

$("#formSection").validate({
    rules: {
        class: {
            required: true
        },
        chapter: {
            required: true
        },
        titleSection: {
            required: true,
            minlength: 3
        },
        section: {
            required: true,
            minlength: 3
        }
    },
    messages: {
        class: {
            required: '<i class="bi bi-x-octagon-fill"></i> Choose class required'
        },
        chapter: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter chapter'
        },
        titleSection: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter tittle',
            minlength: '<i class="bi bi-x-octagon-fill"></i> Please enter 3 characters'
        },
        section: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter text',
            digits: '<i class="bi bi-x-octagon-fill"></i> Please enter 3 characters'
        }
    }
});

//const formSection = document.querySelector("#formSection")
//const classid = document.querySelector("#class-id");
//const section = document.querySelector("#onSection");
//const tittleSection = document.querySelector("#name");
//const codeVideo = document.querySelector("#link-video");

//formSection.addEventListener("submit", submitFormSection);

//function submitFormSection(e) {
//    e.preventDefault();

//    const classidValue = classid.value;
//    const sectionValue = section.value;
//    const tittleSectionValue = tittleSection.value;
//    const codeVideoValue = codeVideo.value;

//    console.log(tittleSectionValue);

//    if (classidValue === "") {
//        classid.style.border = "2px solid red";
//    }

//    if (sectionValue === "") {
//        section.style.border = "2px solid red";
//    }

//    if (tittleSectionValue === "") {
//        tittleSection.style.border = "2px solid red";
//    }

//    if (codeVideoValue === "") {
//        codeVideo.style.border = "2px solid red";
//    }
//}