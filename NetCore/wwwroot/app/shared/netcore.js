var netcore = {
    config: {
        pageSize: 10,
        pageIndex: 1
    },
    notify: function (message, type) {
        $.notify(message, {
            clickToHide: true,
            // whether to auto-hide the notification
            autoHide: true,
            // if autoHide, hide after milliseconds
            autoHideDelay: 5000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: '...',
            // default positions
            elementPosition: 'top right',
            globalPosition: 'top right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: type,
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 2
        });
    },
    confirm: function (message, okCallback) {
        bootbox.confirm({
            message: message,
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    okCallback();
                }
            }
        });
    }, dateFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },
    dateTimeFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },
    startLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading').removeClass('hide');
    },
    stopLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading')
                .addClass('hide');
    },
    getStatus: function (status, id) {
        if (status == 1) {
            return '<i class="fa fa-check-circle-o" aria-hidden="true" data-id="' + id + '" style="color:#04881a; font-size:16px"></i>';

        }
        else
            return '<i class="fa fa-lock" aria-hidden="true" data-id="' + id +'" style="color:#e70e0e; font-size:16px; text-align:center"></i>';

    },
    updateStatus: function (status, id) {
        if (status == 1) {
            return '<i class="fa fa-lock" aria-hidden="true" data-id="' + id + '" style="color:#e70e0e; font-size:16px; text-align:center"></i>';
          

        }
        else
            return '<i class="fa fa-check-circle-o" aria-hidden="true" data-id="' + id + '" style="color:#04881a; font-size:16px"></i>';

    },
    getValueBool: function (status, id) {
        if (status == true) {
            return '<i class="fa fa-check-circle-o" aria-hidden="true" data-id="' + id + '" style="color:#04881a; font-size:16px"></i>';

        }
        else
            return '<i class="fa fa-lock" aria-hidden="true" data-id="' + id + '" style="color:#e70e0e; font-size:16px; text-align:center"></i>';

    },
    UpdateValueBool: function (status, id) {
        if (status == 'true') {
            return '<i class="fa fa-lock" aria-hidden="true" data-id="' + id + '" style="color:#e70e0e; font-size:16px; text-align:center"></i>';


        }
        else
            return '<i class="fa fa-check-circle-o" aria-hidden="true" data-id="' + id + '" style="color:#04881a; font-size:16px"></i>';

    },
    getTrueFalse: function (status) {
        if (status == 1) {
            return true;

        }
        else

            return false;

    },
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
        return a.join('.');
    },
    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    },
    UploadImage: function (Link,output) {
        var fileUpload = $(Link).get(0);
        var files = fileUpload.files;
        var data = new FormData();
        var Root = "";
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            url: "/Admin/Upload/UploadImage",
            contentType: false,
            processData: false,
            data: data,
            success: function (path) {
                $(output).val(path);
                Root = path;
                return path;

            },
            error: function () {
                netcore.notify('There was error uploading files!', 'error');
            }
        });
        return Root;
    }
    
}
$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() == "POST" || options.type.toUpperCase() == "PUT") {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});