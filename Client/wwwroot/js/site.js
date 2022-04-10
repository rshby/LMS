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
    let classesContent = "";

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
                                            <h5 class="mb-3 font-weight-bold"><a href="../class/details/${idx+1}">${val.class_Name}</a></h5>
                                            <span>${val.category_Name}&nbsp</span> <span>&nbsp⁎${val.level_Name}⁎&nbsp</span> <span>&nbsp★${val.class_Rating}</span>
                                            <p>${bPrice}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       </div>`

        if ((idx + 1) % 2 == 0) {
            classesContent += `</div>`
        }
    })
    $('#classes').html(classesContent);
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
function FillClassDetView() {
    let cDet = GetClassById(classId);
    let classDetCont = `<div class="container mt-5 mb-5">
                        <div class="row">
                            <div class="col-sm-4">
                                <img src="${cDet.class_UrlPic}" alt="" style="width: 250px; height: 250px;" />
                            </div>
                            <div class="col-sm-8 align-self-center">
                                <h5 class="mb-3 font-weight-bold">${cDet.class_Name}</h5>
                                <p>${cDet.class_Desc}</p>
                                <p><span>${cDet.category_Name}</span> <span>${cDet.level_Name}</span> <span>${cDet.class_Rating}</span></p>
                                <button id="enroll" type="button" class="btn btn-primary">Take Class</button>
                                <button id="feedback" type="button" class="btn btn-info" data-toggle="modal" data-target="#formFb">Give Feedback</button>
                                <button id="viewCert" type="button" class="btn btn-success">View Certificate</button>
                            </div>
                        </div>
                   </div>`;
    $('#classDetail').html(classDetCont);
}

FillClassDetView();