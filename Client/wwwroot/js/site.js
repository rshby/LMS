let home = document.getElementById("home");
let dashboard = document.getElementById("dashboard");
let codemyClasses = document.getElementById("codemyClasses");
let codemyClassesDetail = document.getElementById("codemyClassesDetail");
let loginLogout = document.getElementById("loginLogout");

function readSession() {
    let inOut = ``;
    if (sesEmail.length != 0) {
        inOut = `<a class="nav-item nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     ${sesEmail}
                 </a>
                 <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
                     <a class="dropdown-item" href="/dashboard">My Classes</a>
                     <a class="dropdown-item" href="/account">My Account</a>
                     <div class="dropdown-divider"></div>
                     <a class="dropdown-item text-danger" href="/login/Terminate">Logout</a>
                 </div>`;
    } else {
        inOut = `<button type="button" class="btn btn-outline-primary btn-sm" style="border-style: hidden;" data-toggle="modal" data-target="#loginModal">Login</button>`;
    }
    $("#loginLogout").html(inOut);
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
    if (priceStr.length == 1) {
        bpv = "GRATIS!";
    } else if (priceStr.length == 6) {
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
function BetterRatingView(rating) {
    newRating = rating.toFixed(1);
    return newRating
}
function BetterRatingView2(rating) {
    let detail = ``;
    console.log(rating);
    let newRating = rating.toFixed(1).toString();
    console.log(newRating);
    if (newRating == 5) {
        detail = "Perfect";
        newRating += ` (${detail})`;
    } else if (newRating >= 3) {
        detail = "Great";
        newRating += ` (${detail})`;
    } else if (newRating >= 2) {
        detail = "Okay";
        newRating += ` (${detail})`;
    } else if (newRating >= 1) {
        detail = "Bad";
        newRating += ` (${detail})`;
    } else if (newRating >= 0) {
        detail = "Empty";
        newRating += ` (${detail})`;
    }
    return newRating
}
function BetterLevelView(level) {
    let bLevel = ``;
    if (level == `Basic`) {
        bLevel = `⁎ ${level}`;
    } else if (level == `Intermediate`) {
        bLevel = `⁑ ${level}`;
    } else if (level == `Advanced`) {
        bLevel = `⁂ ${level}`;
    }
    return bLevel;
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
            Email: sesEmail,
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
function getUserDataByEmail(email) {
    let data = {};
    $.ajax({
        url: `https://localhost:44376/api/users/masterbyemail`,
        type: `POST`,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Email: email
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
function GetClassesSortedByRating() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/master/rating",
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

//Get Certificate by Email and Class_Id
function GetCertificate(email, class_id) {
    let response = new Object();
    let data = new Object();
    data.Email = email;
    data.Class_Id = class_id;
    $.ajax({
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
        },
        type: "POST",
        url: `https://localhost:44376/api/certificates/byemailclassid`,
        dataType: "json",
        data: JSON.stringify(data),
        async: false
    }).done((result) => {
        response = result.data;
    }).fail((e) => {
        console.log(e);
    });
    return response;
}

function FillHome() {
    let threeClasses = GetClassesSortedByRating();
    let topClass = ``;
    let joinButton = ``;
    if (sesEmail.length == 0) {
        joinButton = `<a href="#registerModal" id="linkRegister1" class="btn btn-outline-primary" data-target="#registerModal" data-toggle="modal" data-dismiss="modal">Yuk bergabung sekarang!</a>`
    }
    $("#joinButton").html(joinButton);
    $.each(threeClasses, function (idx, val) {
        bRating = BetterRatingView(val.class_Rating);
        if (idx < 3) {
            bLevel = BetterLevelView(val.level_Name);
            topClass += `<div class="col-md-4">
                            <div class="card" style="width: 18rem;">
                                <img class="card-img-top align-self-center mt-3" src="${val.class_UrlPic}" style="width: 150px; height: 150px;">
                                <div class="card-body">
                                    <h5 class="card-title mb-1 font-weight-bold">${val.class_Name}</h5>
                                    <p class="mb-3"><button type="button" class="btn btn-outline-dark btn-sm" style="font-size: 14px; padding: 0px; border-style: hidden;">Fullstack</button> <button type="button" class="btn btn-outline-info btn-sm mx-2" style="font-size: 14px; padding: 0px; border-style: hidden;">&nbsp;${bLevel}&nbsp;</button> <button type="button" class="btn btn-outline-warning btn-sm" style="font-size: 14px; padding: 0px; border-style: hidden;">&nbsp;★ ${bRating}&nbsp;</button></p>
                                    <a href="/class/details/${val.class_Id}" class="btn btn-primary">Check the Class</a>
                                </div>
                            </div>
                        </div>`;
        }
    });
    $("#topClass").html(topClass);
}

if (home != null) {
    FillHome();
}

function FillDashboard() {
    let welcMsg = getUserDataByEmail(sesEmail);
    if (sesEmail.length != 0) {
        $("#welcomingMessage").html(`Selamat datang, ${welcMsg.firstName}!`);
    }

    let unpaidTb = TakenUnpaidClass(sesEmail);
    let unpaidCont = ``;
    let unpaidHead = ``;
    $.each(unpaidTb, function (idx, val) {
        bPrice = BetterPriceView(val.class_Price);
        bDate = BetterDateView(`${val.takenClass_Expired}`);
        unpaidCont += `<tr>
                            <td><a href="class/details/${val.class_Id}" style="color: black;">${val.class_Name}</a></td>
                            <td>${bPrice}</td>
                            <td>${bDate}</td>
                            <td><button id="btnP${val.class_Id}" type="button" class="btn btn-outline-dark" onclick="payClass${val.class_Id}()">Konfirmasi Pembayaran</button></td>
                        </tr>`;
    });
    if (unpaidCont.length != 0) {
        unpaidHead = `<tr>
                         <th scope="col">Class Name</th>
                         <th scope="col">Price</th>
                         <th scope="col">Expired Date</th>
                         <th scope="col">Action</th>
                     </tr>`;
    } else {
        unpaidHead = `<tr class="text-center">
                          <th scope="col" style="font-size: 14px; font-weight:lighter">Kamu tidak memiliki kelas yang belum dibayar</th>
                      </tr>`;
    }
    $("#unpaidClassHead").html(unpaidHead);
    $("#unpaidClass").html(unpaidCont);

    $.each(unpaidTb, function (idx, val) {
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

    let paidTb = TakenPaidClass(sesEmail);
    let onGoingCont = ``;
    let doneCont = ``;
    let onGoingHead = ``;
    let doneHead = ``;

    $.each(paidTb, function (idx, val) {
        if (val.takenClass_IsDone == false) {
            onGoingCont += `<tr>
                            <td><a href="class/details/${val.class_Id}" style="color: black;">${val.class_Name}</a></td>
                            <td>
                                <form action="https://localhost:44329/class/details/${val.class_Id}">
                                    <button id="btnCt${val.class_Id}" type="button" class="btn btn-outline-primary">Continue Class</button>
                                    <button id="btnCt${val.class_Id}2" type="submit" hidden class="btn btn-outline-primary">Continue Class</button>
                                </form>
                            </td>
                        </tr>`;
        } else {
            certificate = GetCertificate(sesEmail, val.class_Id);
            doneCont += `<tr>
                            <td><a href="class/details/${val.class_Id}" style="color: black;">${val.class_Name}</a></td>
                            <td><button id="btnCf${val.class_Id}" type="button" class="btn btn-outline-success  ml-2">Certificate</button></td>
                            <td><a id="viewCert${val.class_Id}" href="../certificate/code/${certificate.certificate_Code}" hidden>...</a></td>
                        </tr>`;
        }
    });
    if (onGoingCont.length != 0) {
        onGoingHead = `<tr>
                          <th scope="col">Class Name</th>
                          <th scope="col">Action</th>
                      </tr>`;
    } else {
        onGoingHead = `<tr class="text-center">
                          <th scope="col" style="font-size: 14px; font-weight:lighter">Kamu tidak memiliki kelas yang sedang dijalani</th>
                      </tr>`;
    }
    $("#undoneClassHead").html(onGoingHead);
    $("#undoneClass").html(onGoingCont);

    if (doneCont.length != 0) {
        doneHead = `<tr>
                          <th scope="col">Class Name</th>
                          <th scope="col">Action</th>
                      </tr>`;
    } else {
        doneHead = `<tr class="text-center">
                          <th scope="col" style="font-size: 14px; font-weight:lighter">Kamu belum memiliki kelas yang sudah selesai</th>
                      </tr>`;
    }
    $("#doneClassHead").html(doneHead);
    $("#doneClass").html(doneCont);

    $.each(paidTb, function (idx, val) {
        if (val.takenClass_IsDone == false) {
            window[`continue${val.class_Id}`] = document.getElementById(
                `btnCt${val.class_Id}`
            );
            window[`continue${val.class_Id}`].addEventListener("click", function () {
                Swal.fire({
                    title: 'Lanjutkan Kelas?',
                    text: "Membuka Chapter Terakhir",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Ya',
                    cancelButtonText: 'Tidak',
                }).then((x) => {
                    let button = document.getElementById(`btnCt${val.class_Id}2`);
                    if (x.isConfirmed) {
                        button.click();
                    }
                });
            });
        } else {
            window[`certificate${val.class_Id}`] = document.getElementById(`btnCf${val.class_Id}`);
            window[`certificate${val.class_Id}`].addEventListener("click", function () {
                Swal.fire({
                    title: 'Lihat Sertifikat?',
                    text: "Membuka Sertifikat",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Ya',
                    cancelButtonText: 'Tidak',
                }).then((x) => {
                    if (x.isConfirmed) {
                        document.getElementById(`viewCert${val.class_Id}`).click();
                    }
                });
            });
        }
    });
}

if (dashboard != null) {
    FillDashboard();
}

function FillClassesView() {
    let categories = GetAllCategories();
    let ctgFilter = ``;
    let classes = GetAllClasses();
    let classesContent = `<div id="class-list"><ul class="list" style="list-style: none; margin: 0; padding: 0;">`;
    let i = 0;

    $.each(categories, function (idx, val) {
        ctgFilter += `<option>${val.name}</option>`;
    });

    let filters = `<div class="col-sm">
                       <p class="mb-0">Category</p>
                       <select id="cg" class="selectpicker" onchange="updCtg()" multiple>
                           ${ctgFilter}
                       </select>
                   </div>`;

    $.each(classes, function (idx, val) {
        bPrice = BetterPriceView(val.class_Price);
        bLevel = BetterLevelView(val.level_Name);
        bRating = BetterRatingView2(val.class_Rating);

        if ((idx + 1) % 2 != 0) {
            classesContent += `<div class="row mb-3 mx-2">`;
        }

        classesContent += `<li><div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h6 class="mb-1 font-weight-bold" ><a href="../class/details/${idx + 1}" style="color: black;">${val.class_Name}</a></h6>
                                            <p class="mb-0 text-truncate font-weight-light" style="width: 20rem; font-size: 13px;">${val.class_Desc}</p>
                                            <p class="mb-1"><button type="button" class="btn btn-outline-dark btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm mx-2" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;${bLevel}&nbsp;</button> <button type="button" class="btn btn-outline-warning btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;★ ${bRating}&nbsp;</button></p>
                                            <p class="font-weight-bold mb-0" style="font-size: 14px">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div></li>`;

        if ((idx + 1) % 2 == 0) {
            classesContent += `</div>`;
        }
    });
    classesContent += `</ul><ul class="pagination justify-content-center mt-3 mb-0"></ul></div>`;
    $("#classes").html(classesContent);
    $('#filters').html(filters);

    var classList = new List("class-list", {
        valueNames: ["name"],
        page: 2,
        pagination: true,
    });
}
function updCtg() {
    let updated = $('#cg').val();
    let classes = GetAllClasses();
    let cList = `<div id="class-list"><ul class="list" style="list-style: none; margin: 0; padding: 0;">`;
    let i = 1;
    if (updated.length != 0) {
        updated.forEach(elm =>
            $.each(classes, function (idx, val) {
                if (elm == val.category_Name) {
                    bPrice = BetterPriceView(val.class_Price);
                    bLevel = BetterLevelView(val.level_Name);
                    bRating = BetterRatingView2(val.class_Rating);

                    if (i % 2 != 0) {
                        cList += `<div class="row mb-3 mx-2">`;
                    }

                    cList += `<li><div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h6 class="mb-1 font-weight-bold" ><a href="../class/details/${idx + 1}" style="color: black;">${val.class_Name}</a></h6>
                                            <p class="mb-0 text-truncate" style="width: 20rem; font-size: 13px;">${val.class_Desc}</p>
                                            <p class="mb-1"><button type="button" class="btn btn-outline-dark btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm mx-2" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;${bLevel}&nbsp;</button> <button type="button" class="btn btn-outline-warning btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;★ ${bRating}&nbsp;</button></p>
                                            <p class="font-weight-bold mb-0" style="font-size: 14px">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div></li>`;

                    if (i % 2 == 0) {
                        cList += `</div>`;
                    }
                    i++;
                }
            })
        );
    } else {
        $.each(classes, function (idx, val) {
            bPrice = BetterPriceView(val.class_Price);
            bLevel = BetterLevelView(val.level_Name);
            bRating = BetterRatingView2(val.class_Rating);

            if ((idx + 1) % 2 != 0) {
                cList += `<div class="row mb-3 mx-2">`;
            }

            cList += `<li><div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.class_UrlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h6 class="mb-1 font-weight-bold" ><a href="../class/details/${idx + 1}" style="color: black;">${val.class_Name}</a></h6>
                                            <p class="mb-0 text-truncate" style="width: 20rem; font-size: 13px;">${val.class_Desc}</p>
                                            <p class="mb-1"><button type="button" class="btn btn-outline-dark btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">${val.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm mx-2" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;${bLevel}&nbsp;</button> <button type="button" class="btn btn-outline-warning btn-sm" style="font-size: 13px; padding: 0px; border-style: hidden;">&nbsp;★ ${bRating}&nbsp;</button></p>
                                            <p class="font-weight-bold mb-0" style="font-size: 14px">${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div></li>`;

            if ((idx + 1) % 2 == 0) {
                cList += `</div>`;
            }
        });
    }
    cList += `</ul><ul class="pagination justify-content-center mt-3"></ul></div>`;
    $("#classes").html(cList);
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
    let takenClass = TakenClassById(sesEmail);
    let fbStatus = feedbackStatus(sesEmail);
    let bPrice = BetterPriceView(`${cDet.class_Price}`);
    let bRating = BetterRatingView2(cDet.class_Rating);
    let bLevel = BetterLevelView(cDet.level_Name);
    let classDetail = `<div class="container mt-5 mb-5">
                        <div class="row">
                            <div class="col-sm-4">
                                <img src="${cDet.class_UrlPic}" alt="" style="width: 250px; height: 250px;" />
                            </div>
                            <div class="col-sm-8 align-self-center">
                                <h4 class="mb-1 font-weight-bold">${cDet.class_Name}</h4>
                                <p class="mb-1" style="font-size: 15px; font-weight: lighter; opacity: 0.8;" >${cDet.class_Desc}</p>
                                <p class="mb-2"><button type="button" class="btn btn-outline-dark btn-sm" style="font-size: 16px; padding: 0px; border-style: hidden;">${cDet.category_Name}</button> <button type="button" class="btn btn-outline-info btn-sm mx-3" style="font-size: 16px; padding: 0px; border-style: hidden;">&nbsp;${bLevel}&nbsp;</button> <button type="button" class="btn btn-outline-warning btn-sm" style="font-size: 16px; padding: 0px; border-style: hidden;">&nbsp;★ ${bRating}&nbsp;</button></p>
                                `;
    let classSections = `<div class="container card mb-3">`;
    let sectsHead = `<div class="list-group" id="list-tab" role="tablist" style="height: 33rem; overflow: scroll;">`;
    let sectsBody = ``;

    // Belum Login
    if (sesEmail.length == 0) {
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade align-self-center text-center" id="body${val.chapter}">
                                <img class="align-self-center text-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                          </div>`;
        });
        classDetail += `       <h5 class="font-weight-bold mb-3 ">${bPrice}</h5>
                               <a href="#registerModal" id="linkRegister" class="btn btn-outline-primary" data-target="#registerModal" data-toggle="modal" data-dismiss="modal">Register dulu yuk!</a>
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

        // Belum Daftar
    } else if (takenClass.status == 404) {
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade align-self-center text-center" id="body${val.chapter}">
                                <img class="align-self-center text-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                          </div>`;
        });
        classDetail += `       <h5 class="font-weight-bold mb-3">${bPrice}</h5>
                               <button type="button" class="btn btn-primary" onclick="enroll()">Take Class</button>
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

        // Belum Bayar
    } else if (takenClass.data.takenClass_IsPaid == false) {
        $.each(cSects, function (idx, val) {
            sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
            sectsBody += `<div class="tab-pane fade align-self-center text-center" id="body${val.chapter}">
                                <img class="align-self-center text-center" src="https://icon-library.com/images/lock-icon-transparent-background/lock-icon-transparent-background-10.jpg" style="width:500px; height:500px;" alt="Card image">
                          </div>`;
        });
        classDetail += `       <button id="enroll" type="button" class="btn btn-secondary mt-2" disabled>Waiting For Payment</button>
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

        // Belum Selesai
    } else if (takenClass.data.takenClass_IsPaid == true && takenClass.data.takenClass_IsDone == false) {
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
                if (chap == prog) {
                    sectsHead += `<a class="list-group-item list-group-item-action active" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                    sectsBody += `<div class="tab-pane fade show active" id="body${val.chapter}">
                                <h4>${val.name}</h4>
                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>`;
                    sectsBody += `<br />
                                  <button id="btnC${val.chapter}" class="btn btn-primary rounded float-right">Continue Progress</button>
                               </div>`;
                } else {
                    sectsHead += `<a class="list-group-item list-group-item-action" data-toggle="list" href="#body${val.chapter}"><div class="row"><div class="col-sm-2 invisible">✔</div><div class="col-sm-10"><h6>${val.name}</h6></div></div></a>`;
                    sectsBody += `<div class="tab-pane fade" id="body${val.chapter}">
                                <h4>${val.name}</h4>
                                <br />
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${val.content}?rel=0" allowfullscreen></iframe>
                                </div>`;
                    sectsBody += `<br />
                                  <button id="btnC1${val.chapter}" class="btn btn-secondary rounded float-right" disabled>Continue Progress</button>
                               </div>`;
                }
            }
        });
        classDetail += `       <button id="feedback" type="button" class="btn btn-info  mt-2" data-toggle="modal" data-target="#formFb" disabled>Give Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success  mt-2" disabled>View Certificate</button>
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
        classDetail += `        <button id="btnfeedback" type="button" class="btn btn-info  mt-2" data-toggle="modal" data-target="#formFb">Give Feedback</button>
                                <button id="btnviewCert" type="button" class="btn btn-success  mt-2" disabled>View Certificate</button>
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
        certificate = GetCertificate(sesEmail, cSects[0].class_Id);
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
        classDetail += `        <button id="feedback" type="button" class="btn btn-info  mt-2" data-toggle="modal" data-target="#formFb" hidden>View Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success  mt-2">View Certificate</button>
                                <a id="viewCert5${cSects[0].class_Id}" href="../../certificate/code/${certificate.certificate_Code}" hidden>...</a>
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
                    continueChap = ContinueProgressChap(sesEmail);
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
                    AddFeddback(sesEmail, rating, review);
                }
            });
        }
        else if (fbStatus == 200) {
            let buttonCertif = document.getElementById("viewCert");
            buttonCertif.addEventListener("click", function () {
                Swal.fire({
                    title: "Buka Certificate?",
                    text: "Akan Membuka Certificate!",
                    icon: "warning",
                    showCancelButton: true,
                    showConfirmButton: true,
                    cancelButtonText: "Tidak",
                    confirmButtonText: "Ya",
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                }).then((x) => {
                    if (x.isConfirmed) {
                        document.getElementById(`viewCert5${cSects[0].class_Id}`).click();
                    }
                });
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

//Ketika link Register Pada Login diklick
if (sesEmail.length == 0 && loginLogout != null) {
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
}

//Ketika link Register Pada Home diklick
if (sesEmail.length == 0 && home != null) {
    document.getElementById("linkRegister1").addEventListener("click", function () {
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
}

//Ketika button Register Account diklick -> proses mendaftar akun
if (sesEmail.length == 0 && loginLogout != null) {
    document.getElementById("buttonRegisterAccount").addEventListener("click", function () {
        RegisterAccount();
    });
}

// Ketika tombol login diklick -> untuk login
if (sesEmail.length == 0 && (home != null || loginLogout != null)) {
    document.getElementById("buttonLogin").addEventListener("click", function () {
        let data = new Object();
        data.Email = document.getElementById("LogEmail").value;
        data.Password = document.getElementById("LogPass").value;

        $.ajax({
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
            },
            type: "POST",
            url: `https://localhost:44376/api/accounts/login`,
            dataType: "json",
            data: JSON.stringify(data)
        }).done((result) => {
            if (result.status == 200) {

                toastr.success('Login Berhasil');

                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "100",
                    "hideDuration": "500",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                let btnSubmit = document.getElementById("buttonSubmitLogin");
                btnSubmit.click();
            }
            else {
                if (result.message == "data email tidak ditemukan di database") {
                    let emailMsg = document.getElementById("errorMessageLoginEmail");
                    emailMsg.innerHTML = "Email Tidak Ada Di Database!!";
                } else {
                    let emailMsg = document.getElementById("errorMessageLoginEmail");
                    emailMsg.innerHTML = "";
                    let passSmg = document.getElementById("errorMessageLoginPassword");
                    passSmg.innerHTML = "Password Salah!!";
                }
            }
        }).fail((e) => {
            console.log(e);
        });
    });
}

// Untuk Form Validate
(function () {
    "use strict";
    window.addEventListener("load", function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName("needs-validation");
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener("submit", function (event) {
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

//Get Data Account by Email
function GetAccountByEmail(email) {
    let data = new Object();

    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/accounts/${email}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    });
    return data;
}

//Button Send OTP untuk Forgot Password Ketika di klick
if (sesEmail.length == 0 && loginLogout != null) {
    document.getElementById("buttonSendOTP").addEventListener("click", function () {
        let email = document.getElementById("LogEmailFP1").value;
        let data = new Object();
        data.Email = email;
        $.ajax({
            type: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            dataType: "json",
            async: false,
            url: `https://localhost:44376/api/accounts/forgotpassword`,
            data: JSON.stringify(data)
        }).done((result) => {
            if (result.status == 200) {
                Swal.fire({
                    title: "Sukses",
                    text: "Kode OTP Dikirim ke Email Anda!",
                    icon: "success",
                    showConfirmButton: true
                }).then(function () {
                    let button = document.getElementById("buttonSendOTP1");
                    button.click();
                });
            }
            else {
                Swal.fire({
                    title: "Gagal",
                    text: result.message,
                    showConfirmButton: true,
                    icon: "error"
                });
            }
        }).fail((e) => {
            console.log(e);
        });
    });
}

if (sesEmail.length == 0 && loginLogout != null) {
    document.getElementById("buttonCheckOTP").addEventListener("click", function () {
        let email = document.getElementById("LogEmailFP1").value;
        let inputOTP = document.getElementById("LogEmailFP2").value;
        let data = GetAccountByEmail(email);

        if (inputOTP == data.otp) {
            Swal.fire({
                title: "Sukses",
                text: "Kode OTP Sesuai",
                icon: "success",
                showConfirmButton: true
            }).then(function () {
                let button = document.getElementById("buttonCheckOTP1");
                button.click();
            });
        }
        else {
            Swal.fire({
                title: "Gagal",
                text: "Kode OTP Tidak Sesuai",
                icon: "error",
                showConfirmButton: true
            });
        }
    });
}

//Ketika Tombol ChangePassword diklick
if (sesEmail.length == 0 && loginLogout != null) {
    document.getElementById("buttonChangePassword").addEventListener("click", function () {
        let data = new Object();
        data.Email = document.getElementById("LogEmailFP1").value;
        data.Password = document.getElementById("LogNewPass").value;
        data.ConfirmPassword = document.getElementById("LogConfirmPass").value;
        data.OTP = document.getElementById("LogEmailFP2").value;

        $.ajax({
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            dataType: "json",
            type: "POST",
            url: `https://localhost:44376/api/accounts/changepassword`,
            async: false,
            data: JSON.stringify(data)
        }).done((result) => {
            if (result.status == 200) {
                Swal.fire({
                    title: "Sukses",
                    text: "Password Telah Terganti",
                    icon: "success",
                    showConfirmButton: false,
                    timer: 1670
                }).then(function () {
                    location.reload();
                });
            }
            else {
                Swal.fire({
                    title: "Gagal",
                    text: result.message,
                    icon: "error",
                    showConfirmButton: false,
                    timer: 1670
                });
            }
        }).fail((e) => {
            console.log(e);
        });
    });
}