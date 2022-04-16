//Get Master User by Email
function GetMasterUserByEmail(email) {
    let data = new Object();
    data.Email = email;
    $.ajax({
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        url: `https://localhost:44376/api/users/masterbyemail`,
        async: false,
        data: JSON.stringify(data)
    }).done((result) => {
        data = result.data;
    }).fail((e) => {
        console.log(e);
    })
    return data;
}

//Get data dari tabel User by email
function GetUserbyEmail(email) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/users/${email}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    });
    return data;
}

//Get Education by Id
function GetEducationByid(id) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/educations/${id}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    });
    return data;
}

// Tampilkan Semua Universitas ke Form
function TampilkanUniv() {
    $.ajax({
        type: "GET",
        async: false,
        url: `https://localhost:44376/api/universities`
    }).done((result) => {
        let pilihanUniv = ``;
        $.each(result.data, function (index, data) {
            pilihanUniv += `<option value = "${data.id}"> ${data.name}</option >`;
        });
        $("#InputUn").html(pilihanUniv);
    }).fail((e) => {
        console.log(e);
    });
}

//Tampilkan Semua Province
function TampilkanProvince() {
    $.ajax({
        type: "GET",
        async: false,
        url: `https://localhost:44376/api/provinces`
    }).done((result) => {
        let pilihanProvince = ``;
        $.each(result.data, function (index, data) {
            pilihanProvince += `<option value = "${data.id}"> ${data.name}</option >`;
        });
        $("#InputProvince").html(pilihanProvince);
    }).fail((e) => {
        console.log(e)
    });
}

//Tampilkan List City Semua
function TampilkanCity() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44376/api/cities",
        async: false,
        data: {}
    }).done((result) => {
        let pilihanCity = ``;
        if (result.status == 200) {
            $.each(result.data, function (index, data) {
                pilihanCity += `<option value="${data.id}">${data.name}</option>`;
            });
            $("#InputCity").html(pilihanCity);
        }
        else {
            pilihanCity += `<option value="-">Data Tidak Ada</option>`;
            $("#InputCity").html(pilihanCity);
        }
    }).fail((e) => {
        console.log(e)
    });
}

//Tampilkan City by Province_Id
function TampilkanCityByProvinceId(provinceId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/cities/byprovince/${provinceId}`,
        async: false
    }).done((result) => {
        if (result.status == 200) {
            $.each(result.data, function (index, data) {
                let pilihanCity = ``;
                $.each(result.data, function (index, data) {
                    pilihanCity += `<option value = "${data.id}"> ${data.name}</option >`;
                });
                $("#InputCity").html(pilihanCity);
            });
        }
        else {
            pilihanCity = `<option value="-" disable>Data Tidak Ada</option >`;
            $("#InputCity").html(pilihanCity);
        }
    }).fail((e) => {
        console.log(e);
    })
}

//Get City By Id
function GetCityByid(cityId) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/cities/${cityId}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result
    }).fail((e) => {
        coonsole.log(e);
    });
    return data;
}

//Tampilkan Semua District
function TampilkanDistrict() {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/districts`,
        async: false
    }).done((result) => {
        let pilihanDistrict = ``;
        $.each(result.data, function (index, data) {
            pilihanDistrict += `<option value="${data.id}">${data.name}</option>`;
        });
        $("#InputDistrict").html(pilihanDistrict);
    }).fail((e) => {
        console.log(e);
    });
}

//Tampilkan District berdasarkan inputan City_Id
function TampilkanDistrictByCityId(cityId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/districts/bycity/${cityId}`,
        async: false
    }).done((result) => {
        if (result.status == 200) {
            let pilihanDistrict = ``;
            $.each(result.data, function (index, data) {
                pilihanDistrict += `<option value = "${data.id}"> ${data.name}</option >`;
            });
            $("#InputDistrict").html(pilihanDistrict);
        }
        else {
            pilihanDistrict = `<option value="-" disable>Data Tidak Ada</option >`;
            $("#InputDistrict").html(pilihanDistrict);
        }
    }).fail((e) => {
        console.log(e)
    });
}

//Get District By Id
function GetDistrictById(districtId) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/districts/${districtId}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    });
    return data;
}

//Tampilkan Address By Id
function GetAddressById(addressId) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/addresses/${addressId}`,
        async: false,
        data: {}
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    })
    return data;
}

//Tampilkan Semua Subdistrict
function TampilkanSubDistrict() {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/subdistricts`,
        async: false
    }).done((result) => {
        let pilihanSD = ``;
        if (result.status == 200) {
            $.each(result.data, function (index, data) {
                pilihanSD += `<option value="${data.id}">${data.name}</option>`
            });
            $("#InputSubDistrict").html(pilihanSD);
        }
        else {
            pilihanSD = `<option value="-" disable>Data Tidak Ada</option>`;
            $("#InputSubDistrict").html(pilihanSD);
        }
    }).fail((e) => {
        console.log(e);
    });
}

//Tampilkan SubDistrict Berdasarkan inputan district_Id
function TampilkanSubDistrictByDistrictId(districtId) {
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/subdistricts/bydistrict/${districtId}`,
        async: false
    }).done((result) => {
        if (result.status == 200) {
            let pilihanSD = ``;
            $.each(result.data, function (index, data) {
                pilihanSD += `<option value="${data.id}">${data.name}</option>`;
            });
            $("#InputSubDistrict").html(pilihanSD);
        }
        else {
            pilihanSD = `<option value="-">Data Tidak Ada</option>`;
            $("#InputSubDistrict").html(pilihanSD);
        }
    }).fail((e) => {
        console.log(e);
    })
}

//Get SubDistrictbyId
function GetSubDistricyById(id) {
    let data = new Object();
    $.ajax({
        type: "GET",
        url: `https://localhost:44376/api/subdistricts/${id}`,
        async: false
    }).done((result) => {
        data = result;
    }).fail((e) => {
        console.log(e);
    });
    return data;
}



//Update data User ke Database
function UpdateMasterUser() {
    console.log("kepanggil");
    let dataUser = GetMasterUserByEmail(sesEmail);
    let data = new Object();
    data.Email = dataUser.email;
    data.FirstName = $("#InputFN").val(); // -> ambil dari value form
    data.LastName = $("#InputLN").val(); // -> ambil dari value form
    data.Gender = $("#InputGd").val();
    data.Phone = $("#InputPh").val();
    data.BirthDate = $("#InputBd").val();
    data.Street = $("#InputStreet").val(); // -> belum ada
    data.Subdistrict_Id = $("#InputSubDistrict").val(); // -> belum ada
    data.Major = $("#InputMajor").val();
    data.University_Id = $("#InputUn").val();

    //Validasi Form Terlebih Dahulu
    $("#formUpdateAccount").validate({
        errorPlacement: function (error, element) { },
    });

    console.log($("#formUpdateAccount").valid());

    if ($("#formUpdateAccount").valid()) {
        Swal.fire({
            title: 'Update Data?',
            text: "Anda Akan Mengupdate Data!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Update'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    type: "PUT",
                    url: `https://localhost:44376/api/users/updatemaster`,
                    dataType: "json",
                    data: JSON.stringify(data)
                }).done((result) => {
                    console.log(result);
                }).fail((e) => {
                    console.log(e);
                });
                Swal.fire({
                    title: 'Sukses Update!',
                    text: 'Your file has been Update.',
                    icon: 'success',
                    showConfirmButton: false,
                    timer: 1560
                }).then(function () {
                    location.reload();
                });
            }
        });
    }
}

$(document).ready(function () {
    //Dijalankan hanya jika link pada browser diakses
    if (window.location.href.indexOf("account") > 1) {

        //Ketika button Register Account diklick -> proses mendaftar akun
        document.getElementById("buttonUpdateAcount").addEventListener("click", function () {
            UpdateMasterUser();
        });

        TampilkanUniv();
        TampilkanProvince();
        TampilkanSubDistrict();
        TampilkanDistrict();
        TampilkanCity();

        let data = GetMasterUserByEmail(sesEmail);
        let dataUser = GetUserbyEmail(sesEmail);

        document.getElementById("InputFN").value = data.firstName;
        document.getElementById("InputLN").value = data.lastName;
        $("#InputGd").val(dataUser.gender).change(); // -> jenis kelamin
        document.getElementById("InputPh").value = data.phone;
        $("#InputUn").val(GetEducationByid(dataUser.education_Id).university_Id).change(); // -> universitas
        document.getElementById("InputMajor").value = data.major; // -> major
        document.getElementById("InputBd").value = dataUser.birthDate.toString().substring(0, 10); // -> Birth Date

        document.getElementById("InputProvince").addEventListener("change", function () {
            var pilihanProvince = this.options[this.selectedIndex].value;
            TampilkanCityByProvinceId(pilihanProvince);
        });

        document.getElementById("InputCity").addEventListener("change", function () {
            var pilihanCity = this.options[this.selectedIndex].value;
            TampilkanDistrictByCityId(pilihanCity);
        });

        document.getElementById("InputDistrict").addEventListener("change", function () {
            var pilihanDistrict = this.options[this.selectedIndex].value;
            TampilkanSubDistrictByDistrictId(pilihanDistrict);
        });

        document.getElementById("InputStreet").value = GetAddressById(dataUser.address_Id).street; // -> street
        $("#InputSubDistrict").val(GetAddressById(dataUser.address_Id).subdistrict_Id).change(); // -> sub district
        $("#InputDistrict").val(GetSubDistricyById(GetAddressById(dataUser.address_Id).subdistrict_Id).district_Id).change(); // -> district
        $("#InputCity").val(GetDistrictById(GetSubDistricyById(GetAddressById(dataUser.address_Id).subdistrict_Id).district_Id).city_Id).change(); // -> city
        $("#InputProvince").val(GetCityByid(GetDistrictById(GetSubDistricyById(GetAddressById(dataUser.address_Id).subdistrict_Id).district_Id).city_Id).province_Id).change(); // -> province
    }
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