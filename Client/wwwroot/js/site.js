// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetAllClasses() {
    let data = {};
    $.ajax({
        url: "https://localhost:44376/api/classes/",
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

}
let classes = GetAllClasses();
let classesContent = "";
/*
   <div class="row mb-3">
        <div class="col-sm">
            <div class="card">
                <div class="card-body text-left">
                    <div class="row">
                        <div class="col-sm-3">
                            <img src="https://www.fpaceforum.com/media/100x100.4555/full" alt="" />
                        </div>
                        <div class="col-sm-9 align-self-center">
                            <h5 class="mb-4 font-weight-bold"><a href="class/details">(Nama Kelas A)</a></h5>
                            <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm">
            <div class="card">
                <div class="card-body text-left">
                    <div class="row">
                        <div class="col-sm-3">
                            <img src="https://www.fpaceforum.com/media/100x100.4555/full" alt="" />
                        </div>
                        <div class="col-sm-9 align-self-center">
                            <h5 class="mb-4 font-weight-bold"><a href="class/details">(Nama Kelas B)</a></h5>
                            <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 */

$.each(classes, function (idx, val) {

    bPrice = BetterPriceView(val.price)

    if ((idx + 1) % 2 != 0) {
        classesContent += `<div class="row mb-3">`
    }

    classesContent += `<div class="col-sm">
                            <div class="card">
                                <div class="card-body text-left">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <img src="${val.urlPic}" alt="" style="width: 100px; height:100px"/>
                                        </div>
                                        <div class="col-sm-9 align-self-center">
                                            <h5 class="mb-4 font-weight-bold"><a href="class/details">${val.name}</a></h5>
                                            <span>(Nama Kategori)</span> <span>(Level)</span> <span>☆${val.rating}</span>
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