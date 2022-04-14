let dashboard = document.getElementById("dashboard");
let codemyClasses = document.getElementById("codemyClasses");
let codemyClassesDetail = document.getElementById("codemyClassesDetail");

$(function () {
    // INITIALIZE DATEPICKER PLUGIN
    $(".datepicker").datepicker({
        clearBtn: true,
        format: "dd/mm/yyyy",
    });
});

function readSession() {
    let inOut = ``;
    let Modal = ``;
    
    if ($("#sessionEmail").val() != null) {
        inOut = `<a class="nav-item nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Account
                 </a>
                 <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                     <a class="dropdown-item" href="~/dashboard">My Classes</a>
                     <a class="dropdown-item" href="~/account">My Account</a>
                     <div class="dropdown-divider"></div>
                     <a class="dropdown-item" href="#">Logout</a>
                 </div>`;
    } else {
        inOut = `<button type="button" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target="#loginModal">Login</button>`;
        Modal = ``;
    }
    $("#loginLogout").html(inOut);
    /*$('#navModal').html(Modal);*/
}
readSession();



function GetAllClasses() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/master",
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function GetAllLevels() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/levels",
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function GetAllCategories() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/categories",
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
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
        p1 = priceStr.slice(0, 1);
        p2 = priceStr.slice(1, 4);
        p3 = priceStr.slice(4, 7);
        bpv = "Rp" + p1 + "." + p2 + "." + p3 + ",00.";
    }
    return bpv;
}
function BetterDateView(date) {
    iDate = new Date(`${date}`);
    let betterDate = iDate.toLocaleString("en-GB", { hour12: false });
    return betterDate;
}
function GetClassById(id) {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/masterbyid/" + id,
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function TakenClassById(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/takenclasses/byEmailAndClassId`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email,
            Class_Id: classId,
        }),
        async: false,
    })
        .done((result) => {
            data = result;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function GetSectionsByClassId(id) {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/sections/byclassid/" + id,
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function TakenUnpaidClass(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/takenclasses/ispaidfalse`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email,
        }),
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function payStatus(id) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/takenclasses/konfirmasibayar`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: `dennyfpr@gmail.com`,
            Class_Id: id,
        }),
        async: false,
    })
        .done((result) => {
            data = result.paid;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function TakenPaidClass(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/takenclasses/byemail/` + email,
        async: false,
    })
        .done((result) => {
            data = result.data;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function ContinueProgressChap(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/takenclasses/nextchapter`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email,
            Class_Id: classId,
        }),
        async: false,
    })
        .done((result) => {
            data = result;
            console.log(data);
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function AddFeddback(email, rating, review) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/feedbacks/add`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email,
            Class_Id: classId,
            Rating: rating,
            Review: review,
        }),
        async: false,
    })
        .done((result) => {
            data = result;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}
function feedbackStatus(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/feedbacks/byemailclassid`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email,
            Class_Id: classId,
        }),
        async: false,
    })
        .done((result) => {
            data = result.status;
        })
        .fail((error) => {
            console.log(error);
        });
    return data;
}

function FillDashboard() {
    let unpaidTb = TakenUnpaidClass(`dennyfpr@gmail.com`);
    let unpaidCont = ``;
    $.each(unpaidTb, function (idx, val) {
        bPrice = BetterPriceView(val.class_Price);
        bDate = BetterDateView(`${val.takenClass_Expired}`);
        unpaidCont += `<tr>
                            <td><a href="class/details/${val.class_Id}">${val.class_Name}</a></td>
                            <td>${bPrice}</td>
                            <td>${bDate}</td>
                            <td><button id="btnP${val.class_Id}" type="button" class="btn btn-outline-dark" onclick="payClass${val.class_Id}()">Konfirmasi Pembayaran</button></td>
                        </tr>`;
    });

    $("#unpaidClass").html(unpaidCont);

    $.each(unpaidTb, function (idx, val) {
        console.log(val.class_Id);
        window[`payClass${val.class_Id}`] = document.getElementById(
            `btnP${val.class_Id}`
        );
        window[`payClass${val.class_Id}`].addEventListener("click", function () {
            pStatus = payStatus(`${val.class_Id}`);
            if (pStatus == "pending") {
                Swal.fire({
                    icon: "warning",
                    title: "Pembayaran Belum Diterima",
                    text: "Mohon Selesaikan Pembayaran",
                }).then(function () {
                    location.reload();
                });
            } else if (pStatus == "sukses") {
                Swal.fire({
                    icon: "success",
                    title: "Pembayaran Sukses",
                    text: "Pembayaran Berhasil Dikonfirmasi",
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    icon: "error",
                    title: "Pembayaran Gagal",
                    text: "Batas Waktu Pembayaran Telah Habis",
                }).then(function () {
                    location.reload();
                });
            }
        });
    });

    let paidTb = TakenPaidClass(`dennyfpr@gmail.com`);
    let onGoingCont = ``;
    let doneCont = ``;

    $.each(paidTb, function (idx, val) {
        if (val.takenClass_IsDone == false) {
            onGoingCont += `<tr>
                            <td><a href="class/details/${val.class_Id}">${val.class_Name}</a></td>
                            <td>
                                <form action="https://localhost:44329/class/details/${val.class_Id}">
                                    <button id="btnCt${val.class_Id}" type="submit" class="btn btn-outline-primary">Continue Class</button>
                                </form>
                            </td>
                        </tr>`;
        } else {
            doneCont += `<tr>
                            <td><a href="class/details/${val.class_Id}">${val.class_Name}</a></td>
                            <td><button id="btnCf${val.class_Id}" type="button" class="btn btn-outline-success  ml-2">Certificate</button></td>
                        </tr>`;
        }
    });
    $("#undoneClass").html(onGoingCont);
    $("#doneClass").html(doneCont);

    $.each(paidTb, function (idx, val) {
        if (val.takenClass_IsDone == false) {
            window[`continue${val.class_Id}`] = document.getElementById(
                `btnC${val.class_Id}`
            );
            window[`continue${val.class_Id}`].addEventListener("click", function () {
                alert("Pindah ke current chapter");
            });
        } else {
            window[`certificate${val.class_Id}`] = document.getElementById(
                `btnCf${val.class_Id}`
            );
            window[`certificate${val.class_Id}`].addEventListener(
                "click",
                function () {
                    alert("Lihat Certificate");
                }
            );
        }
    });
}

if (dashboard != null) {
    FillDashboard();
}

function FillClassesView() {
    //let categories = GetAllCategories();
    //let levels = GetAllLevels();
    //let lvFilter = ``;
    //let ctgFilter = ``;
    let classes = GetAllClasses();
    let classesContent = `<div id="class-list"><ul class="list" style="list-style: none; margin: 0; padding: 0;">`;
    let i = 0;

    //$.each(categories, function (idx, val) {
    //    ctgFilter += `<option>${val.name}</option>`;
    //});

    //$.each(levels, function (idx, val) {
    //    lvFilter += `<option>${val.name}</option>`;
    //});

    //let filters = `<div class="col-sm">
    //                   <p class="mb-0">Level</p>
    //                   <select id="lv" class="selectpicker" onchange="updLv()" multiple>
    //                       ${lvFilter}
    //                   </select>
    //               </div>
    //               <div class="col-sm">
    //                   <p class="mb-0">Category</p>
    //                   <select id="cg" class="selectpicker" onchange="updCtg()" multiple>
    //                       ${ctgFilter}
    //                   </select>
    //               </div>`;

    $.each(classes, function (idx, val) {
        bPrice = BetterPriceView(val.class_Price);

        if ((idx + 1) % 2 != 0) {
            classesContent += `<div class="row mb-3 mx-2">`;
        }

        classesContent += `<li><div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic
            }" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1
            }">${val.class_Name}</a></h5>
                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc
            }</p>
                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name
            }</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name
            }</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating
            }</button></p>
                                            <p class="mb-0">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div></li>`;

        if ((idx + 1) % 2 == 0) {
            classesContent += `</div>`;
        }
    });
    classesContent += `</ul><ul class="pagination justify-content-center mt-3"></ul></div>`;
    $("#classes").html(classesContent);
    /*    $('#filters').html(filters);*/

    var classList = new List("class-list", {
        valueNames: ["name"],
        page: 2,
        pagination: true,
    });
}

if (codemyClasses != null) {
    FillClassesView();
}

function FillClassDetView() {
    let cDet = GetClassById(classId);
    let cSects = GetSectionsByClassId(classId);
    let takenClass = TakenClassById(`dennyfpr@gmail.com`);
    let fbStatus = feedbackStatus(`dennyfpr@gmail.com`);
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
    if (takenClass.status == 404) {
        classDetail += `       <button type="button" class="btn btn-primary" onclick="enroll()">Take Class</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<img class="card-img align-self-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                         <div class="card-img-overlay"></div>
                         </div>`;

        // Belum Bayar
    } else if (takenClass.data.takenClass_IsPaid == false) {
        classDetail += `       <button id="enroll" type="button" class="btn btn-secondary" disabled>Waiting For Payment</button>
                            </div>
                        </div>
                   </div>`;
        classSections += `<img class="card-img align-self-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                         <div class="card-img-overlay"></div>
                         </div>`;

        // Belum Selesai
    } else if (
        takenClass.data.takenClass_IsPaid == true &&
        takenClass.data.takenClass_IsDone == false
    ) {
        $.each(cSects, function (idx, val) {
            let chap = idx + 1;
            let prog = takenClass.data.takenClass_ProgressChapter + 1;
            if (chap < prog) {
                sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="btnC${val.chapter}" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
                             </div>`;
            } else {
                sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>`;
                if (chap == prog) {
                    sectsBody += `<br />

                                  <button id="btnC${val.chapter}" class="btn btn-primary rounded float-right">Continue Progress</button>
                               </div>`;
                } else {
                    sectsBody += `<br />

                                  <button id="btnC${val.chapter}" class="btn btn-secondary rounded float-right disabled">Continue Progress</button>
                               </div>`;
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
    } else if (takenClass.data.takenClass_IsDone == true && fbStatus != 200) {
        console.log(fbStatus);
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="btnC${val.chapter}" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
                         </div>`;
        });
        classDetail += `        <button id="btnfeedback" type="button" class="btn btn-info" data-toggle="modal" data-target="#formFb">Give Feedback</button>
                                <button id="btnviewCert" type="button" class="btn btn-success" disabled>View Certificate</button>
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
    } else if (fbStatus == 200) {
        console.log(fbStatus);
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>

                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>
                                <br />

                                <button id="btnC${val.chapter}" type="button" class="btn btn-outline-success rounded float-right" disabled>Progress Done</button>
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
    $("#classDetail").html(classDetail);
    $("#classSections").html(classSections);

    if (takenClass.status == "200") {
        if (
            takenClass.data.takenClass_IsPaid == true &&
            takenClass.data.takenClass_IsDone == false
        ) {
            $.each(cSects, function (idx, val) {
                window[`continue${val.chapter}`] = document.getElementById(
                    `btnC${val.chapter}`
                );
                window[`continue${val.chapter}`].addEventListener("click", function () {
                    continueChap = ContinueProgressChap(`dennyfpr@gmail.com`);
                    if (continueChap.status == 200) {
                        Swal.fire({
                            icon: "success",
                            text: `Chapter ${val.chapter} Telah Diselesaikan`,
                        }).then(function () {
                            location.reload();
                        });
                    } else {
                        Swal.fire({
                            icon: "error",
                            text: `Terjadi Kesalahan Dalam Menyelesaikan Chapter ${val.chapter}`,
                        }).then(function () {
                            location.reload();
                        });
                    }
                });
            });
        } else if (takenClass.data.takenClass_IsDone == true && fbStatus != 200) {
            let feeedback = document.getElementById(`btnSendFb`);
            feeedback.addEventListener("click", function () {
                let star = document.getElementsByName("rating");
                let selected = Array.from(star).find((radio) => radio.checked);

                let review = $("#reviewText").val();
                let rating = parseInt(selected.value);
                if (review != null && rating != null) {
                    AddFeddback(`dennyfpr@gmail.com`, rating, review);
                }
            });
        }
    }
}

if (codemyClassesDetail != null) {
    FillClassDetView();
}

//Tampilkan Daftar Semua Univ
function TampilkanAllUniv() {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/universities`,
        async: false,
        data: {},
    })
        .done((result) => {
            let pilihanUniv = ``;
            if (result.status == 200) {
                $.each(result.data, function (index, data) {
                    pilihanUniv += `<option value="${data.id}">${data.name}</option>`;
                });
                $("#inUniv").html(pilihanUniv);
            } else {
                pilihanUniv = `<option value="-">Data Tidak Ditemukan</option>`;
                $("#inUniv").html(pilihanUniv);
            }
        })
        .fail((e) => {
            console.log(e);
        });
}

//Tampilkan Semua Province
function TampilkanAllProvince() {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/provinces`,
        async: false,
        data: {},
    })
        .done((result) => {
            let pilihanProvince = ``;
            if (result.status == 200) {
                $.each(result.data, function (index, data) {
                    pilihanProvince += `<option value="${data.id}">${data.name}</option>`;
                });
                $("#inProv").html(pilihanProvince);
            } else {
                pilihanProvince = `<option value="-">Data Tidak Ditemukan</option>`;
                $("#inProv").html(pilihanProvince);
            }
        })
        .fail((e) => {
            console.log(e);
        });
}

//Tampilkan City By Province_Id
function TampilkanCityByProvId(provinceId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/cities/byprovince/${provinceId}`,
        async: false,
        data: {},
    })
        .done((result) => {
            let pilihanCity = ``;
            if (result.status == 200) {
                $.each(result.data, function (index, data) {
                    pilihanCity += `<option value="${data.id}">${data.name}</option>`;
                });
                $("#inCity").html(pilihanCity);
            } else {
                pilihanCity = `<option value="-">Data Tidak Ditemukan</option>`;
                $("#inCity").html(pilihanCity);
            }
        })
        .fail((e) => {
            console.log(e);
        });
}

//Tampilkan District By City_Id
function TampilkanDistricyByCityId(cityId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/districts/bycity/${cityId}`,
        async: false,
        data: {},
    })
        .done((result) => {
            let pilihanDistrict = ``;
            if (result.status == 200) {
                $.each(result.data, function (index, data) {
                    pilihanDistrict += `<option value="${data.id}">${data.name}</option>`;
                });
                $("#inDis").html(pilihanDistrict);
            } else {
                pilihanDistrict = `<option value="-">Data Tidak Ditemukan</option>`;
                $("#inDis").html(pilihanDistrict);
            }
        })
        .fail((e) => {
            console.log(e);
        });
}

//Tampilkan SubDistrict by District_Id
function TampilkanSubDistricyByDistrictId(districtId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/subdistricts/bydistrict/${districtId}`,
        async: false,
        data: {},
    })
        .done((result) => {
            let pilihanSD = ``;
            if (result.status == 200) {
                $.each(result.data, function (index, data) {
                    pilihanSD += `<option value="${data.id}">${data.name}</option>`;
                });
                $("#inSubDis").html(pilihanSD);
            } else {
                pilihanSD = `<option value="-">Data Tidak Ditemukan</option>`;
                $("#inSubDis").html(pilihanSD);
            }
        })
        .fail((e) => {
            console.log(e);
        });
}

//Insert Register Data
function RegisterAccount() {
    let data = new Object();
    data.Email = document.getElementById("inEmailRegister").value;
    data.Password = document.getElementById("inPass").value;
    data.FirstName = document.getElementById("inFName").value;
    data.LastName = document.getElementById("inLName").value;
    data.Phone = document.getElementById("inPhone").value;
    data.Gender = parseInt(document.getElementById("inGender").value);
    data.BirthDate = document.getElementById("inBDate").value;
    data.Street = document.getElementById("inAddress").value;
    data.SubDistrict_Id = parseInt(document.getElementById("inSubDis").value);
    data.Major = document.getElementById("inMajor").value;
    data.University_Id = parseInt(document.getElementById("inUniv").value);

    console.log(data);

    $("#formRegisterAccount").validate({
        errorPlacement: function (error, element) { },
    });

    if ($("#formRegisterAccount").valid()) {
        Swal.fire({
            title: "Daftar Account?",
            text: "Mendaftar Account Ke LMS ini!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Daftar",
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    headers: {
                        Accept: "application/json",
                        "Content-Type": "application/json",
                    },
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: `https://localhost:44376/api/accounts/register`,
                    async: false,
                    data: JSON.stringify(data),
                })
                    .done((result) => {
                        if (result.status == 200) {
                            Swal.fire({
                                title: "Selamat",
                                text: "Account Anda Berhasil Dibuat",
                                icon: "success",
                                showConfirmButton: false,
                                timer: 1550,
                            }).then(function () {
                                location.reload();
                            });
                        } else {
                            Swal.fire({
                                title: "Gagal",
                                text: result.message,
                                icon: "error",
                                showConfirmButton: false,
                                timer: 1550,
                            });
                        }
                    })
                    .fail((e) => {
                        console.log(e);
                    });
            }
        });
    }
}

//Ketika link Register diklick
document.getElementById("linkRegister").addEventListener("click", function () {
    TampilkanAllProvince();
    TampilkanAllUniv();

    document.getElementById("inProv").addEventListener("change", function () {
        var pilihanProv = this.options[this.selectedIndex].value;
        TampilkanCityByProvId(pilihanProv);
    });

    document.getElementById("inCity").addEventListener("change", function () {
        var pilihanCity = this.options[this.selectedIndex].value;
        TampilkanDistricyByCityId(pilihanCity);
    });

    document.getElementById("inDis").addEventListener("change", function () {
        var pilihanDistrict = this.options[this.selectedIndex].value;
        TampilkanSubDistricyByDistrictId(pilihanDistrict);
    });
});

//Ketika button Register Account diklick -> proses mendaftar akun
document.getElementById("buttonRegisterAccount").addEventListener("click", function () {
    RegisterAccount();
});

// Untuk Form Validate
(function () {
    "use strict";
    window.addEventListener(
        "load",
        function () {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.getElementsByClassName("needs-validation");
            // Loop over them and prevent submission
            var validation = Array.prototype.filter.call(forms, function (form) {
                form.addEventListener(
                    "submit",
                    function (event) {
                        if (form.checkValidity() === false) {
                            event.preventDefault();
                            event.stopPropagation();
                        }
                        form.classList.add("was-validated");
                    },
                    false
                );
            });
        },
        false
    );
})();


//function updLv() {
//    let updated = $('#lv').val();
//    let classes = GetAllClasses();
//    let cList = `<div id="class-list"><ul class="list" style="list-style: none; margin: 0; padding: 0;">`;
//    let i = 1;
//    let ii = 0;
//    updated.forEach
//        (elm =>
//            $.each(classes, function (idx, val) {
//                if (i % 2 != 0) {
//                    cList += `<div class="row mb-3">`;
//                    i++;
//                }
//                if (elm == val.level_Name) {
//                    cList += `<li><div class="col-sm mb-3">
//                            <div class="card">
//                                <div class="card-body text-left">
//                                    <div class="row">
//                                        <div class="col-sm-3">
//                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
//                                        </div>
//                                        <div class="col-sm-9 align-self-center">
//                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1}">${val.class_Name}</a></h5>
//                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc}</p>
//                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating}</button></p>
//                                            <p class="mb-0">${bPrice}</p>
//                                        </div>
//                                    </div>
//                                </div>
//                            </div>
//                       </div></li>`;
//                    ii++;
//                }
//                if (i % 2 != 0) {
//                    cList += `</div>`;
//                }
//            })
//        );
//    if (ii % 2 != 0) {
//        cList += `<li><div class="col-sm mb-3 invisible">
//                            <div class="card">
//                                <div class="card-body text-left">
//                                    <div class="row">

//                                    </div>
//                                </div>
//                            </div>
//                       </div></li>`;
//    }
//    if (updated.length != 0) {
//        cList += `</ul><ul class="pagination justify-content-center"></ul></div>`;
//        $('#classes').html(cList);
//        var classList = new List('class-list', {
//            valueNames: ['name'],
//            page: 2,
//            pagination: true
//        });
//    } else {
//        $.each(classes, function (idx, val) {
//            if (i % 2 != 0) {
//                cList += `<div class="row mb-3">`;
//                i++;
//            }
//            cList += `<li><div class="col-sm mb-3">
//                            <div class="card">
//                                <div class="card-body text-left">
//                                    <div class="row">
//                                        <div class="col-sm-3">
//                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
//                                        </div>
//                                        <div class="col-sm-9 align-self-center">
//                                            <h5 class="mb-1 font-weight-bold"><a href="../class/details/${idx + 1}">${val.class_Name}</a></h5>
//                                            <p class="mb-2 text-truncate" style="width: 20rem">${val.class_Desc}</p>
//                                            <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm disabled">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm disabled">${val.level_Name}</button> <button type="button" class="btn btn-outline-warning btn-sm disabled">★${val.class_Rating}</button></p>
//                                            <p class="mb-0">${bPrice}</p>
//                                        </div>
//                                    </div>
//                                </div>
//                            </div>
//                       </div></li>`;
//            ii++;
//            if (i % 2 != 0) {
//                cList += `</div>`;
//            }
//        })
//        cList += `</ul><ul class="pagination justify-content-center"></ul></div>`;
//        $('#classes').html(cList);
//        var classList = new List('class-list', {
//            valueNames: ['name'],
//            page: 2,
//            pagination: true
//        });
//    }
//}
