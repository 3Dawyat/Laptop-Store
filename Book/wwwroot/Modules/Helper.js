
var Helper = {
    AjaxCall: function (url, paramters, callingType, returnFormat, success, falier) {
        $.ajax({
            url: url,
            data: paramters,
            dataType: returnFormat,
            success: function (data) {
                success(data);
                return data;
            },
            error: function () {
                falier();
                $('#info').html('<p>An error has occurred</p>');
                return 0;
            },
            type: callingType
        });
    },
    AjaxCallPost: function (url, paramters, success, falier) {
        $.ajax({
            url: url,
            data: paramters,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                success(data);
                return data;
            },
            error: function (xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
                falier();
                $('#info').html('<p>An error has occurred</p>');
                return 0;
            },
            type: 'POST'
        });
    },
    AjaxCallGet: function (url, paramters, returnFormat, success, falier) {
        $.ajax({
            url: url,
            data: paramters,
            contentType: "application/json; charset=utf-8",
            dataType: returnFormat,
            success: function (data) {
                success(data);
                return data;
            },
            //error: function () {
            //    falier();
            //    $('#info').html('<p>An error has occurred</p>');
            //    return 0;
            //},
            error: function (xhr, status, error) {
                var errorMessage = xhr.status + ': ' + xhr.statusText + ': ' + xhr.responseText + ': ';
                console.log('Error - ' + errorMessage);
            },
            type: 'GET',

        });
    },
    AjaxCallGetSync: function (url, paramters, returnFormat, success, falier) {
        $.ajax({
            url: url,
            data: paramters,
            contentType: "application/json; charset=utf-8",
            dataType: returnFormat,
            success: function (data) {
                success(data);
                return data;
            },
            error: function () {
                falier();
                $('#info').html('<p>An error has occurred</p>');
                return 0;
            },
            type: 'GET',
            async: false
        });
    },
    ClosePopUp: function () {
        parent.jQuery.colorbox.close();
    },
    CallingServer: function (expretion, data) {
        __doPostBack('__Page', expretion + "_" + data);
    },
    //ClosePopUp: function () {
    //    parent.jQuery.colorbox.close();
    //},
    BootStrapModal(modalId) {
        $("#" + modalId + "").modal({
            show: true,
            backdrop: 'static',
            keyboard: true
        });
    },
    GetQueryString: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    },
    GetFormattedDate: function (date) {
        var msec = Date.parse(date);
        var d = new Date(msec);
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var newDate = curr_date + "/" + curr_month + "/" + curr_year;
        return newDate;
    },
    GetDaysMonthDate: function (date) {
        var msec = Date.parse(date);
        var d = new Date(msec);
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var newDate = {};
        newDate.days = curr_date;
        newDate.month = curr_month;
        newDate.year = curr_year;
        return newDate;
    },
    GetmonthDate: function (date) {
        var mydate = this.GetDaysMonthDate(date);
        switch (mydate.month) {
            case 1:
                mydate.month = "Jan"; break;
            case 2:
                mydate.month = "Feb"; break;
            case 3:
                mydate.month = "Mar"; break;
            case 4:
                mydate.month = "Apr"; break;
            case 5:
                mydate.month = "May"; break;
            case 6:
                mydate.month = "Jun"; break;
            case 7:
                mydate.month = "Jul"; break;
            case 8:
                mydate.month = "Aug"; break;
            case 9:
                mydate.month = "Sep"; break;
            case 10:
                mydate.month = "Oct"; break;
            case 11:
                mydate.month = "Nov"; break;
            case 12:
                mydate.month = "Dec"; break;
        }

        return mydate;
    },
    Getvideourl: function (videoUrl) {
        var videoId = videoUrl.substring(videoUrl.lastIndexOf('/') + 1);
        return "https://www.youtube.com/watch?v=" + videoId;
    },
    getUrlParameter :function (sParam) {
        var sPageURL = window.location.search.substring(1),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
            }
        }
    },
    getUrlParameterBystring: function (sParam) {
        var sPageURL = window.location.href,
            sURLVariables = sPageURL.split(sParam);
        if (sURLVariables.length != 0) {
                return decodeURIComponent(sURLVariables[1]);
            }
    },
    ClientValidation: function (selector) {
        var CanSave = true;
        $(selector).each(function (e) {
            ControlData = {};
            if ($(this).data("required") == "True" && ($(this).val() == "" || $(this).val() == null)) {
                $(this).closest("div").addClass("has-error has-feedback");
                CanSave = false;
                //  alert("error");
            }
            else if ($(this).data("required") == "True" && ($(this).val() != "" || $(this).val() != null)) {
                $(this).closest("div").removeClass("has-error has-feedback");
            }
        });
        if (!CanSave)
            Message.ShowNotification("هناك حقول مطلوبة", "error");
        return CanSave;
    },
    
};
var Message = {

    ShowDescription: function (description, title) {
        $("#lbDescription").empty();
        $("#exampleModalLongTitle").empty();
        $("#lbDescription").append(description);
        $("#exampleModalLongTitle").append(title);
        Helper.BootStrapModal("DescriptionPopup");
    },
    ShowPopup: function (title, data) {
        $.confirm({
            title: title,
            content: '',
            onContentReady: function () {
                var self = this;
                this.setContentPrepend(data);
            },
            columnClass: 'medium',
            buttons: {
                cancelAction: {
                    btnClass: 'btn-dark',
                    text: 'اغلاق',
                    function() {
                    }
                }
            }
        });
    },
    ShowNotification: function (message, errorType) {
        Lobibox.notify(errorType, {
            size: 'normal',
            closeButton: false,                  // Show close button or not
            rounded: false,
            delayIndicator: true,
            position: 'top right',
            msg: message

        });
    },
    ShowConfirm: function (title,message, errorType) {
        Lobibox.alert(errorType,
            {
                msg: message,
                title: title
            });
    }
,
    TakeConfirmation: function (text, txtCancel, messageHeader, messageBody, url) {
        $.confirm({
            icon: 'fa fa-warning',
            animation: 'Rotate',
            closeAnimation: 'Rotate',
            animationBounce: 1.5,
            title: messageHeader,
            content: messageBody,
            autoClose: 'cancelAction|8000',
            buttons: {
                deleteUser: {
                    text: text,
                    btnClass: 'btn-danger',
                    action: function () {
                        window.location = url;
                    }
                },
                cancelAction: {
                    btnClass: 'btn-dark',
                    text: txtCancel,
                    function() {
                    }
                }
            }
        });
    },
    fullScreenConfirm: function (txtConfirm, txtCancel, messageHeader, messageBody, url) {
        $.confirm({
            icon: 'fa fa-warning',
            theme: 'supervan',
            title: messageHeader,
            content: messageBody,
            buttons: {
                confirm: {
                    btnClass: ' btn-purple',
                    text: txtConfirm,
                    action: function () {
                        window.location = url;
                    }
                },
                cancelAction: {
                    text: txtCancel,
                    function() {
                    }
                }
            }
        });
    },
    //ShowPopup: function (title, data) {
    //    $.confirm({
    //        title: title,
    //        content: '',
    //        onContentReady: function () {
    //            var self = this;
    //            this.setContentPrepend(data);
    //        },
    //        columnClass: 'medium',
    //        buttons: {
    //            cancelAction: {
    //                btnClass: 'btn-dark',
    //                text: 'اغلاق',
    //                function() {
    //                }
    //            }
    //        }
    //    });
    //}
}

 