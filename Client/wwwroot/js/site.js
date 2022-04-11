// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetAllClasses() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/master",
        async: false
    }).done((result) => {
        data = result.data;
    }).fail((error) => {
        console.log(error);
    })
    return data;
}
function GetAllLevels() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/levels",
        async: false
    }).done((result) => {
        data = result.data;
    }).fail((error) => {
        console.log(error);
    })
    return data;
}
function GetAllCategories() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/categories",
        async: false
    }).done((result) => {
        data = result.data;
    }).fail((error) => {
        console.log(error);
    })
    return data;
}
function BetterPriceView(price) {
    bpv = "";
    let priceStr = price.toString();
    if (priceStr.length == 6) {
        p1 = priceStr.slice(0, 3);
        p2 = priceStr.slice(3);
        bpv = "Rp" + p1 + "." + p2 + ",00.";
    } else if (priceStr.length == 7) {
        p1 = priceStr.slice(0,1);
        p2 = priceStr.slice(1, 4);
        p3 = priceStr.slice(4, 7);
        bpv = "Rp" + p1 + "." + p2 + "." + p3 + ",00.";
    }
    return bpv
}
function FillClassesView() {
    let classes = GetAllClasses();
    let categories = GetAllCategories();
    let levels = GetAllLevels();
    let lvFilter = ``;
    let ctgFilter = ``;
    let classesContent = ``;
    let i = 0;

    $.each(categories, function (idx, val) {
        ctgFilter += `<option>${val.name}</option>`;
    });

    $.each(levels, function (idx, val) {
        lvFilter += `<option>${val.name}</option>`;
    });

    let filters = `<div class="col-sm">
                       <p class="mb-0">Level</p>
                       <select id="lv" class="selectpicker" onchange="updLv()" multiple>
                           ${lvFilter}
                       </select>
                   </div>
                   <div class="col-sm">
                       <p class="mb-0">Category</p>
                       <select id="cg" class="selectpicker" onchange="updCtg()" multiple>
                           ${ctgFilter}
                       </select>
                   </div>`;

    $.each(classes, function (idx, val) {
        bPrice = BetterPriceView(val.class_Price)

        if ((idx + 1) % 2 != 0) {
            classesContent += `<div class="row mb-3">`
        }

        classesContent += `<div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1}">${val.class_Name}</a></h5>
                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc}</p>
                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating}</button></p>
                                            <p class="mb-0">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div>`

        if ((idx + 1) % 2 == 0) {
            classesContent += `</div>`
        }
    });
    $('#classes').html(classesContent);
    $('#filters').html(filters);
}
function updLv() {
    let updated = $('#lv').val();
    let classes = GetAllClasses();
    let cList = ``;
    let i = 1;
    let ii = 0;
    updated.forEach
        (elm =>
            $.each(classes, function (idx, val) {
                if (i % 2 != 0) {
                    cList += `<div class="row mb-3">`;
                    i++;
                }
                if (elm == val.level_Name) {
                    cList += `<div class="col-sm mb-3">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1}">${val.class_Name}</a></h5>
                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc}</p>
                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating}</button></p>
                                            <p class="mb-0">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div>`;
                    ii++;
                }
                if (i % 2 != 0) {
                    cList += `</div>`;
                }
            })
        );
    if (ii % 2 != 0) {
        cList += `<div class="col-sm mb-3 invisible">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">

                                    </div>
                                </div>
                            </div>
                       </div>`;
    }
    if (updated.length != 0) {
        $('#classes').html(cList);
    } else {
        $.each(classes, function (idx, val) {
            if (i % 2 != 0) {
                cList += `<div class="row mb-3">`;
                i++;
            }
            cList += `<div class="col-sm mb-3">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1}">${val.class_Name}</a></h5>
                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc}</p>
                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating}</button></p>
                                            <p class="mb-0">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div>`;
            ii++;
            if (i % 2 != 0) {
                cList += `</div>`;
            }
        })
        $('#classes').html(cList);
    }
}

FillClassesView();

function GetClassById(id) {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/masterbyid/" + id,
        async: false
    }).done((result) => {
        data = result.data;
    }).fail((error) => {
        console.log(error);
    })
    return data;
}
function GetSectionsByClassId(id) {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/section/" + id,
        async: false
    }).done((result) => {
        data = result.data;
    }).fail((error) => {
        console.log(error);
    })
    return data;
}
function FillClassDetView() {
    let cDet = GetClassById(classId);
    let cSects = GetSectionsByClassId(classId);
    let classDetail = `<div class="container mt-5 mb-5">
                        <div class="row">
                            <div class="col-sm-4">
                                <img src="${cDet.class_UrlPic}" alt="" style="width: 250px; height: 250px;" />
                            </div>
                            <div class="col-sm-8 align-self-center">
                                <h5 class="mb-3 font-weight-bold">${cDet.class_Name}</h5>
                                <p class="mb-1">${cDet.class_Desc}</p>
                                <p class="mb-4"><button type="button" class="btn btn-outline-dark btn-sm disabled">${cDet.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${cDet.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${cDet.class_Rating}</button></p>`;
    let classSections = `<div class="container card mb-3">`;
    let sectsHead = `<div class="list-group" id="list-tab" role="tablist" style="height: 33rem; overflow: scroll;">`;
    let sectsBody = ``;

    // Belum Daftar
    if (true) {
        classDetail += `       <button id="enroll" type="button" class="btn btn-primary">Take Class</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<img class="card-img align-self-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                         <div class="card-img-overlay"></div>
                         </div>`;

        // Belum Bayar
    } else if (true) {
        classDetail += `       <button id="enroll" type="button" class="btn btn-secondary" disabled>Waiting For Payment</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<img class="card-img align-self-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                         <div class="card-img-overlay"></div>
                         </div>`;

        // Belum Selesai
    } else if (true) {
        $.each(cSects, function (idx, val) {
            let chap = idx + 1;
            if (chap < 4) {
                sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="viewCert" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
                             </div>`;
            } else {
                sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>`;
                if (chap == 4) {
                    sectsBody += `<br />

                                  <button id="btn${val.chapter}" class="btn btn-primary rounded float-right">Continue Progress</button>
                               </div>`
                } else {
                    sectsBody += `<br />

                                  <button id="btn${val.chapter}" class="btn btn-secondary rounded float-right disabled">Continue Progress</button>
                               </div>`
                }
            }
        });
        classDetail += `       <button id="feedback" type="button" class="btn btn-info" data-toggle="modal" data-target="#formFb" disabled>Give Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success" disabled>View Certificate</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `   <div class="card-body">

                                <ul class="nav nav-tabs mb-3">
                                    <li class="nav-item">
                                        <a class="nav-link active" href="#classSect">Class Sections</a>
                                    </li>
                                </ul>
                                <div id="#classSect" class="row">
                                    <div class="col-4">
                                            ${sectsHead}
                                        </div>
                                    </div>
                                    <div class="col-8">
                                        <div class="tab-content" id="nav-tabContent">
                                            ${sectsBody}
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>`;

        // Belum Ulas
    } else if (true) {
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="viewCert" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
                         </div>`;
        });
        classDetail += `        <button id="feedback" type="button" class="btn btn-info" data-toggle="modal" data-target="#formFb">Give Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success" disabled>View Certificate</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<div class="card-body">

                                <ul class="nav nav-tabs mb-3">
                                    <li class="nav-item">
                                        <a class="nav-link active" href="#classSect">Class Sections</a>
                                    </li>
                                </ul>
                                <div id="#classSect" class="row">
                                    <div class="col-4">
                                        ${sectsHead}
                                        </div>
                                    </div>
                                    <div class="col-8">
                                        <div class="tab-content" id="nav-tabContent">
                                            ${sectsBody}
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>`;

        // Sudah Semua
    } else if (true) {
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="viewCert" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
                         </div>`;
        });
        classDetail += `        <button id="feedback" type="button" class="btn btn-info" data-toggle="modal" data-target="#formFb">View Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success">View Certificate</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<div class="card-body">

                                <ul class="nav nav-tabs mb-3">
                                    <li class="nav-item">
                                        <a class="nav-link active" href="#classSect">Class Sections</a>
                                    </li>
                                </ul>
                                <div id="#classSect" class="row">
                                    <div class="col-4">
                                        ${sectsHead}
                                        </div>
                                    </div>
                                    <div class="col-8">
                                        <div class="tab-content" id="nav-tabContent">
                                            ${sectsBody}
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>`;
    }
    $('#classDetail').html(classDetail);
    $('#classSections').html(classSections);
}

FillClassDetView();

