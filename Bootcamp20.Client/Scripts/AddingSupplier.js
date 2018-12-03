//$(document).ready(function () {
//    $.ajax({
//        type: 'get',
//        url: 'http://localhost:4937/api/Suppliers',
//        async: false,
//        dataType: 'json',
//        success: function (data) {
//            var html = '';
//            var i, k;
//            for (i = 0; i < data.length; i++) {
//                k = i + 1;
//                html += '<tr>' +
//                        '<td>' + k + '</td>' +
//                        '<td>' + data[i].Name + '</td>' +
//                        '<td>' + k + '</td>' +
//                        '</tr>';
//            }
//            $('#LoadData').html(html);
//        }
//    });
//});
tampil();
function tampil() {
    $.ajax({
        type: 'get',
        url: 'http://localhost:4937/api/Suppliers/',
        dataType: 'JSON',
        success: function (data) {
            var html = '';
            var i, k;
            for (i = 0; i < data.length; i++) {
                k = i + 1;
                html += '<tr>' +
                        '<td>' + k + '</td>' +
                        '<td>' + data[i].Name + '</td>' +
                        '<td>' + data[i].CreateDate + '</td>' +
                        '<td>' + data[i].IsDelete + '</td>' +
                        '<td><a onclick="return getById(' + data[i].Id + ')">Edit</a> | <a onclick="return deleting(' + data[i].Id + ')">Delete</a></td>' +
                        '</tr>';
            }                            
            $('#LoadData').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });
}

function cari() {
    $.ajax({
        type: 'get',
        url: "http://localhost:4937/api/Suppliers/?jns=" + $('#jns').val() + "&&name=" + $('#cari').val(),
        dataType: 'JSON',
        success: function (data) {
            var html = '';
            var i, k;
            for (i = 0; i < data.length; i++) {
                k = i + 1;
                html += '<tr>' +
                        '<td>' + k + '</td>' +
                        '<td>' + data[i].Name + '</td>' +
                        '<td>' + data[i].CreateDate + '</td>' +
                        '<td>' + data[i].IsDelete + '</td>' +
                        '<td><a onclick="return getById(' + data[i].Id + ')">Edit</a> | <a onclick="return deleting(' + data[i].Id + ')">Delete</a></td>' +
                        '</tr>';
            }
            $('#LoadData').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });
}

function getById(id) {
    $.ajax({
        url: 'http://localhost:4937/api/Suppliers/' + id,
        type: 'get',
        dataType:'json',
        success: function (data) {
            tampil();            
            $('#Name').val(data.Name);
            $('#NameOld').val(data.Name);
            $('#Id').val(data.Id);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });
}

function savetampil() {
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Edit() {
    var supplier = new Object();
    supplier.id = $('#Id').val();
    supplier.name = $('#Name').val();
    if (supplier.name == "") {
        swal("Invalid", "Harap Mengisi Form", "warning");
        return false;
    }
    else if (supplier.name == $('#NameOld').val()) {
        swal("Invalid", "Harap Data Tidak Boleh Sama", "warning");
        return false;
    }
    else{
        $.ajax({
            url: 'http://localhost:4937/api/Suppliers/' + supplier.id,
            type: 'PUT',
            data: supplier,
            dataType:'json',
            success: function (data) {
                tampil();
                $('#myModal').modal('hide');
                $('#Name').val('');
                $('#Id').val('');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Terjadi Kesalahan, coba lagi!');
            }
        });
    }
}

function deleting(id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel plx!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
            function (isConfirm) {
                if (isConfirm) {
                    $.ajax({
                        url: 'http://localhost:4937/api/Suppliers/' + id,
                        type: 'delete',
                        success: function (data) {
                            tampil();
                            swal("Deleted!", "Your imaginary file has been deleted.", "success");
                            setTimeout(function () {
                                location.reload();
                            }, 1200);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert('Terjadi Kesalahan, coba lagi!');
                        }
                    });
                } else {
                    swal("Cancelled", "Your imaginary file is safe :)", "error");
                }
            });
}

$('#Save').click(function () {
    var supplier = new Object();
    supplier.name = $('#Name').val();
    if (supplier.name == "") {
        swal("Invalid", "Harap Mengisi Form", "warning");
        return false;
    }
    else{
        $.ajax({
            url: 'http://localhost:4937/api/Suppliers',
            type: 'POST',
            dataType: 'json',
            data: supplier,
            success: function (data) {
                tampil();
                $('#myModal').modal('hide');
            }
        });
    }
});

function carisupplier() {
    var supplier = new Object();
    supplier.name = $('#cari').val();
    $.ajax({
        type: 'get',
        url: 'http://localhost:4937/api/Suppliers',
        dataType: 'JSON',
        success: function (data) {
            var html = '';
            var i, k;
            for (i = 0; i < data.length; i++) {
                k = i + 1;
                html += '<tr>' +
                        '<td>' + k + '</td>' +
                        '<td>' + data[i].Name + '</td>' +
                        '<td>' + data[i].IsDelete + '</td>' +
                        '<td><a onclick="return getById(' + data[i].Id + ')">Edit</a> | <a onclick="return deleting(' + data[i].Id + ')">Delete</a></td>' +
                        '</tr>';
            }
            $('#LoadData').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });
}