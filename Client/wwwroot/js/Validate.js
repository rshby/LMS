jQuery.validator.setDefaults({
    debug: true,
    success: "valid"
});

$("#formClass").validate({

    ignore: [],
    debug: false,
    remove_lt_whitespace: true,
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


$("#formSection").validate({
    ignore: [],
    debug: false,
    rules: {
        class: {
            required: true
        },
        chapter: {
            required: true
        },
        title: {
            required: true,
            minlength: 3
        },
        content: {
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
        title: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter tittle',
            minlength: '<i class="bi bi-x-octagon-fill"></i> Please enter 3 characters'
        },
        content: {
            required: '<i class="bi bi-x-octagon-fill"></i> Please enter text',
            digits: '<i class="bi bi-x-octagon-fill"></i> Please enter 3 characters'
        }
    }
});