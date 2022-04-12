
$(document).ready(function () {
    var table1 = $('#tableuser').DataTable({
        paging: false,
        columnDefs: [
            {
                "orderable": true,
                "targets": 0
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            'copy', 'excel', 'pdf', 'colvis'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/users",
            "dataType": 'JSON',
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return `${meta.row + 1}`;
                }
            },
            { "data": "email" },
            { "data": "firstName" },
            { "data": "lastName" },
            {
                "data": null,
                render: function (data, type, row) {
                    var temp = data.gender;
                    if (temp == 0) {
                        return temp = "Pria";
                    } else {
                        return temp = "Wanita";
                    }
                }
            },
            { "data": "phone" },
            { "data": "birthDate" },
            { "data": "education_Id" },
            { "data": "address_Id" }
        ]
    });

    var table2 = $("#table2").DataTable({
        "processing": true,
        columnDefs: [
            {
                "orderable": true,
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/classes",
            "dataType": 'JSON',
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return `${meta.row + 1}`;
                }
            },
            { "data": "name" },
            { "data": "desc" },
            { "data": "totalChapter" },
            {
                "data": 'price',
                render: $.fn.dataTable.render.number('.', ',', 0, 'Rp ')
            },
            { "data": "rating" },
            {
                "data": null,
                render: function (data, type, row) {
                    return `<div class = "row">
                                <button type="button" id="" class="btn btn-primary" data-toggle="modal" data-target="#modalUpdate" onclick = "update(${data.id})"><span class="bi bi-pencil-fill"> </span> </button> &nbsp;
                                <button type="button" class="btn btn-primary" onclick = "DeleteClass(${data.id})"><span class="bi bi-trash3-fill"> </span> </button> &nbsp;
                            </div>`
                }
            }
        ]
    });


    var table3 = $("#table3").DataTable({
        "processing": true,
        "scrollY": true,
        columnDefs: [
            {
                "targets": 0
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/sections",
            "dataType": 'JSON',
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return `${meta.row + 1}`;
                }
            },
            { "data": "name" },
            { "data": "chapter" },
            { "data": "content" },
            { "data": "class_Id" },
            { "data": null }
        ]
    })

    //Read Form
    ReadLevel();
    ReadCategory();
});

function ReadLevel() {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44376/api/levels'
    }).done((result) => {
        var data = result.data;
        var text = `<option disabled selected> ~Choose Level~ </option>`;

        $.each(data, function (key, val) {
            text += `<option value ="${val.id}"> ${val.name}</option>`;
        });
        $('#level').html(text);
    }).fail((error) => {
        return error.message();
    })
}

function LevelConv(levelId) {
    var data;
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/levels/${levelId}`,
        data: 'data',
        async: false
    }).done((result) => {
        data = result.name;
        return data;
    }).fail((error) => {
        return error;
    })
    return data;
}

function CategoryConv(cateId) {
    var data;
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/Categories/${cateId}`,
        data: 'data',
        async: false
    }).done((result) => {
        data = result.name;
        return data;
    }).fail((error) => {
        return error;
    })
    return data;
}

function ReadCategory() {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44376/api/categories'
    }).done((result) => {
        var data = result.data;
        var text = `<option disabled selected> ~Choose Category Class~ </option>`;

        $.each(data, function (key, val) {
            text += `<option value = "${val.id}"> ${val.name}</option>`;
        });
        $('#cate').html(text);
    }).fail((error) => {
        return error.message();
    })
}

function InsertClass() {
    //insert value obj
    const inClass = new Object();
    inClass.Name = $("#judul").val();
    inClass.UrlPic = $("#url").val();
    inClass.Desc = editor.getData();
    inClass.TotalChapter = Number($("#totChapter").val());
    inClass.Price = Number($("#price").val());
    inClass.Level_Id = Number($("#level").val());
    inClass.Category_Id = Number($("#cate").val());

    console.log(inClass);

    Swal.fire({
        title: 'Insert Class',
        text: 'Insert New Class?',
        showCancelButton: true,
        confirmButtonColor: "#89CFF0",
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json;charset=utf-8'
                },
                type: "POST",
                url: "https://localhost:44376/api/classes/regClass",
                dataType: "json",
                data: JSON.stringify(inClass)
            }).done((result) => {
                location.reload();
            }).fail((error) => {
                Swal.fire
                'Failed Insert'
            })
        }
    })
}

function DeleteClass(id) {
    Swal.fire({
        title: "Delete Class?",
        text: "Sure Delete this Class?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: "#89CFF0",
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: `https://localhost:44376/api/classes/${id}`,
                async: false
            }).done((deleted => {
                Swal.fire(
                    'Deleted Class'
                ).then((result) => {
                    location.reload();
                })
            })
            )
        }
    }).fail((error) => {
        return error;
    })
}

function update(key) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/classes/${key}`,
        dataType: "JSON",
        data : 'data',
        async: false
    }).done((result) => {
        var text = "";
        var data = result;
        var level = data.level_Id;
        var category = data.category_Id;
        text += `
                    <div class="form-group">
                        <label for="rating">Rating</label>
                        <input type="text" name="rating" disabled value="${data.rating}" class="form-control" id="rating">
                    </div>

                    <div class="form-group">
                        <label for="tittle">Tittle Class</label>
                        <input type="text" name="tittle" class="form-control" value="${data.name}" id="judul">
                    </div>

                    <div class="form-group">
                        <label for="url">URL Code</label>
                        <input type="text" name="url" class="form-control" value="${data.urlPic}" id="url">
                    </div>

                    <div class="form-group">
                        <label for="Desc">Description</label>
                        <input type="text" name="content" class="form-control"  value="${data.desc}" id="descEdit">
                    </div>

                    <div class="form-group">
                        <label for="TotalChapter">Total Chapter</label>
                        <input type="text" name="TotalChapter" value="${data.totalChapter}" class="form-control" id="totChapter">
                    </div>

                    <div class="form-group">
                        <label for="price">Class Price</label>
                        <input type="text" name="price" value="${data.price}" class="form-control" id="price">
                    </div>

                    <div class="form-group">
                        <label for="level">Level Class</label>
                        <div class = "row">
                            <div class = "col">
                                <input type="text" name="level" value="${data.level_Id}" disabled class="form-control" id="level-id">
                            </div>
                            <div class = "col">
                                <input type="text" name="level" value="${LevelConv(level)}" disabled class="form-control" id="level">
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="category">Category Class</label>
                        <div class = "row">
                            <div class = "col">
                                <input type="text" name="category" value="${data.category_Id}" disabled class="form-control" id="category-id">
                            </div>
                            <div class = "col">
                                <input type="text" name="category" value="${CategoryConv(category)}" disabled class="form-control" id="category">
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" onclick="EditClass(${data.id})">Edit</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
        `
        $('#form-class').html(text);
    }).fail((error) => {
        console.log(error);
    })
}

function EditClass(classId) {

    const temp = new Object();

    temp.Id = classId,
    temp.Name = $('#judul').val();
    temp.Desc = $('#descEdit').val();
    temp.TotalChapter = $('#totChapter').val();
    temp.Price = $('#price').val();
    temp.Level_Id = $('#level-id').val();
    temp.Category_Id = $('#category-id').val();

    $.ajax({
        type: "PUT",
        url: `https://localhost:44376/api/classes/updateclass`,
        dataType: 'JSON',
        data: JSON.stringify(temp)
    }).done((result) => {
        Swal.fire(
            'Updated Class'
        )
    }).fail((result) => {
        Swal.fire(
            'Failed Update Class'
        )
    })
}

