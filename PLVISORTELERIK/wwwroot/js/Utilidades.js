
function validar(e) {
    e.blur();;
}
window.addEventListener('dragover', function (e) {
    e.dataTransfer.effectAllowed = "none";
    e.stopPropagation();
    e.preventDefault();

}, false);

window.addEventListener('drop', function (e) {
    e.dataTransfer.effectAllowed = "none";
    e.stopPropagation();
    e.preventDefault();
}, false);
$(document).on("dragover", "#inputShared", function (e) {
    var timeout = window.dropZoneTimeout;
    if (!timeout) {
        $('.container-inputShared').addClass('image-dropping');
    } else {
        clearTimeout(timeout);
    }
    window.dropZoneTimeout = setTimeout(function () {
        window.dropZoneTimeout = null;
        $('.container-inputShared').removeClass('image-dropping');
    }, 100);
});

function confirmar(title, text, icon, theme) {
    var fg = "";
    var bg = "";
    if (theme == true) {
        fg = "#f1f3f7";
        bg = "#333";
    }
    else {

        fg = "#333";
        bg = "#f1f3f7";

    }
    return new Promise(resolve => {
        Swal.fire({
            title,
            text,
            icon,
            color: fg,
            background: bg,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then((result) => {

            resolve(result.isConfirmed);

        })
    });
}
function alerta(title, text, icon, theme) {
    var fg = "";
    var bg = "";
    if (theme == true) {
        fg = "#f1f3f7";
        bg = "#333";
    }
    else {

        fg = "#333";
        bg = "#f1f3f7";
    }
    Swal.fire({
        title,
        text,
        icon,
        color: fg,
        background: bg
    })
}
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})
function StorageEvent(dotnetHelper) {
    window.addEventListener('storage', function (event) {
        if (event.storageArea === localStorage) {
            // It's local storage
            dotnetHelper.invokeMethodAsync("VerificarLogueo");
        }
    }, false);
}
function timerInactivo(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onmousedown = resetTimer;
    document.onmouseenter = resetTimer;
    document.onkeypress = resetTimer;
    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 1800000); //30 MIN
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}
function spinnerJS(id) {
    $("#" + id).css("z-index", "7");
}

function spinnerJSEnd(id) {
    $("#" + id).css("z-index", "1060");
}
function AlertsToastr(Tipo, Mensaje, titulo) {

    toastr[Tipo](Mensaje, titulo);
};

async function downloadFileFromStream2(fileName, contentStreamReference) {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    triggerFileDownload(fileName, url);
    URL.revokeObjectURL(url);
}

function triggerFileDownload(fileName, url) {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}
var movimientoInicial;
var movimientoFinal;
function ReadyDataTable(table, responsive, paging, searching, ordering, info, columnDefs,roworder) {

    $(document).ready(function () {
  

        var table2 = $(table).DataTable({
            responsive: responsive,
            paging: paging,
            "info": info,
            ordering: ordering,
            searching: searching,
            autoWidth: false,
            columnDefs: columnDefs,
            rowReorder: false,
            order: [[3, 'desc']],
        });
        table2.draw();

        //table2.on('row-reorder', function (e, diff, edit) {
        //    var result = 'Reorder started on row: ' + edit.triggerRow.data()[1] + '<br>';

        //    for (var i = 0, ien = diff.length; i < ien; i++) {
        //        var rowData = table2.row(diff[i].node).data();

        //        result += rowData[1] + ' updated to be in position ' +
        //            diff[i].newData + ' (was ' + diff[i].oldData + ')<br>';
             
               
        //    }
        //    movimientoInicial = {
        //        id: edit.triggerRow.data()[0],
        //        dimension: edit.triggerRow.data()[3]
        //    };
        //    console.log(movimientoInicial);
         
        //    $('#result').html('Event result:<br>' + result);
        //});
   
    });
}

function cambiarIcono(elementoId, clase) {
    event.dataTransfer.effectAllowed = "copyMove";

}
function UpdateDataTables(table, param) {
    $(document).ready(function () {
        var datas = JSON.parse(JSON.stringify(param));

        console.log(datas);
        var myTable = $(table).DataTable();
    });
}
function RemoveDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy(); 
    });
}




