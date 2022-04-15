
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
            "url": "https://localhost:44376/api/users/master",
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
            { "data": "fullName" },
            { "data": "gender" },
            { "data": "birthDate" },
            { "data": "phone" },
            { "data": "address" },
            { "data": "university" },
            { "data": "major" }
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
            'copy', 'csv', 'excel', 'colvis'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/classes/master",
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
            { "data": "class_Name" },
            { "data": "class_Desc" },
            { "data": "class_TotalChapter" },
            {
                "data": 'class_Price',
                render: $.fn.dataTable.render.number('.', ',', 0, 'Rp ')
            },
            { "data": "class_Rating" },
            { "data": "level_Name" },
            { "data": "category_Name" },
            { "data": "jumlah_Peserta" },
            {
                "data": null,
                render: function (data, type, row) {
                    return `<div class = "row">
                                <div style = "margin: auto;">
                                <button type="button" id="" class="btn btn-primary" data-toggle="modal" data-target="#modalUpdate" onclick = "ReadClass(${data.class_Id})"><span class="bi bi-pencil-fill"> </span> </button> &nbsp;
                                <button type="button" class="btn btn-primary" onclick = "DeleteClass(${data.class_Id})"><span class="bi bi-trash3-fill"> </span> </button> &nbsp;
                                </div>
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
            'copy', 'csv', 'excel', 'colvis'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/sections/master",
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
            { "data": "section_Name" },
            { "data": "section_Chapter" },
            { "data": "section_Content" },
            { "data": "class_Name" },
            {
                "data": null,
                render: function (data, type, row) {
                    return `<div class = "row">
                               <div style = "margin: auto;">
                                <button type="button" id="" class="btn btn-primary" data-toggle="modal" data-target="#modalUpdate" onclick = "ReadSection(${data.section_Id})"><span class="bi bi-pencil-fill"> </span> </button> &nbsp;
                                <button type="button" class="btn btn-primary" onclick = "DeleteSection(${data.section_Id})"><span class="bi bi-trash3-fill"> </span> </button> &nbsp;
                                </div>
                            </div>`
                }
            }
        ]
    })

    var table4 = $("#table4").DataTable({
        "processing": true,
        "scrollY": true,
        columnDefs: [
            {
                "targets": 0
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'colvis'
        ],
        "ajax": {
            "url": "https://localhost:44376/api/users/daftarpembayaran",
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
            { "data": "user_FullName" },
            { "data": "class_Name" },
            { "data": "takenClass_OrderId" },
            {
                "data": null,
                render: function (data, type, row) {
                    var temp = "";
                    if (data.takenClass_IsPaid == true) {
                        temp = "Already Paid";
                        return temp;
                    } else {
                        temp = "Unpaid";
                        return temp;
                    }
                }
            }
        ]
    })

    //Read Form
    ReadLevel();
    ReadCategory();
    GetReadyClass();
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
    var data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/Categories/${cateId}`,
        async: false
    }).done((result) => {
        data.name = result.name;
        data.id = result.id;
        return data;
    }).fail((error) => {
        return error;
    })
    return data;
}

function ClassConv(classId) {
    var data;
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/Classes/${classId}`,
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
                    cache: false,
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

function DeleteSection(id) {
    Swal.fire({
        title: "Delete Section?",
        text: "Sure Delete this Section?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: "#89CFF0",
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: `https://localhost:44376/api/sections/${id}`,
                async: false
            }).done((deleted => {
                Swal.fire(
                    'Deleted Section'
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

function ReadClass(key) {

    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/classes/${key}`,
        dataType: "JSON",
        async: false
    }).done((result) => {
        var text = "";
        var data = result;
        var level = data.level_Id;
        var category = data.category_Id;
        var temp = CategoryConv(category);

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
                                <input type="text" name="category" value="${temp.id}" disabled class="form-control" id="category">
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

function ReadSection(sectionId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/sections/${sectionId}`,
        dataType: "JSON",
        async: false
    }).done((section) => {
        var text = "";
        var data = section;
        var tempClass = ClassConv(data.class_Id);
        text += `

                    <div class="form-group">
                        <label for="class_Id">Id / Name Class</label>
                        <div class = "row">
                            <div class = "col">
                                <input type="text" name="class_Id" value="${data.class_Id}" disabled class="form-control" id="class_id">
                            </div>
                            <div class = "col">
                                <input type="text" name="class_Id" value="${tempClass}" disabled class="form-control" id="class">
                            </div>
                        </div>
                    </div>
                
                    <div class="form-group">
                        <label for="tittlesection">Tittle Section</label>
                        <input type="text" name="tittlesection"  value="${data.name}" class="form-control" id="tittlesection">
                    </div>

                    <div class="form-group">
                        <label for="chapter">Chapter</label>
                        <input type="text" disabled name="chapter" class="form-control" value="${data.chapter}" id="chapter">
                    </div>

                    <div class="form-group">
                        <label for="content">Content Video Code URL</label>
                        <input type="text" name="content" class="form-control" value="${data.content}" id="content">
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" onclick="EditSection(${data.Id})">Edit</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
        `;

        $('#form-section').html(text);
    })
}


function EditClass(classId) {

    let temp = new Object();

    temp.Id = classId;
    temp.Name = $('#judul').val();
    temp.UrlPic = $('#url').val();
    temp.Desc = $('#descEdit').val();
    temp.TotalChapter = Number($('#totChapter').val());
    temp.Price = Number($('#price').val());
    temp.Level_Id = Number($('#level-id').val());
    temp.Category_Id = Number($('#category-id').val());



    //console.log(temp);
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8'
        },
        type: 'PUT',
        url: `https://localhost:44376/api/classes/UpdateClass`,
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

function EditSection(sectionId) {

    let temp = new Object();

    temp.class_id = Number($('#class_id').val());
    temp.name = $('#tittlesection').val();
    temp.chapter = Number($('#chapter').val());
    temp.content = $('#content').val();

    console.log(temp);
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8'
        },
        type: 'PUT',
        url: `https://localhost:44376/api/classes/UpdateContent`,
        dataType: 'JSON',
        data: JSON.stringify(temp)
    }).done((result) => {
        Swal.fire(
            'Updated Section'
        ).then((result) => {
            location.reload();
        })
    }).fail((result) => {
        Swal.fire(
            'Failed Update Section'
        )
    })
}

function InsertSection() {
    //insert value obj
    const inContent = new Object();
    inContent.class_id = Number($("#class-id").val());
    inContent.chapter = Number($("#onSection").val());
    inContent.name = $("#name").val();
    inContent.content = $("#link-video").val();

    //console.log(inContent);

    Swal.fire({
        title: 'Insert Sectioin',
        text: 'Insert New Section?',
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
                url: "https://localhost:44376/api/classes/InputContent",
                dataType: "json",
                data: JSON.stringify(inContent)
            }).done((result) => {
                location.reload();
            }).fail((error) => {
                Swal.fire
                'Failed Insert'
            })
        }
    })

}

function GetReadyClass() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44376/api/classes'
    }).done((result) => {
        var data = result.data
        var text = `<option disabled selected> ~Choose Class~ </option>`;
        $.each(data, function (key, val) {
            text += `<option value = "${val.id}"> ${val.name}</option>`;
        });
        $('#class-id').html(text);
    }).fail((error) => {
        error.message(error)
    })
}


$('#class-id').on('change', function () {
    var valueSelected = this.value;
    $.ajax({
        type: 'GET',
        url: `https://localhost:44376/api/classes/${valueSelected}`,
        async: false
    }).done((result) => {
        var text = `<option disabled selected> ~Choose Contain Section~ </option>`;
        //console.log(result.totalChapter);
        for (var i = 0; i < result.totalChapter; i++) {
            text += `<option value = "${i + 1}"> ${i + 1}</option>`;
        }
        $('#onSection').html(text);
    })
});


