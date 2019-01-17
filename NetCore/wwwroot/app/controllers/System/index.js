var configController = function () {
    this.initialize = function () {

        loadDetails('config');
        registerEvents();
        var urlImage = '';
    }
    function loadDetails(id) {
        $.ajax({
            type: "GET",
            url: "/Admin/config/GetById",
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                netcore.startLoading();
            },
            success: function (response) {
                var data = response;
                $('#txtName').val(data.Name);
                $('#txtAddress').val(data.Address);
                $('#txtPhone').val(data.Mobile);
                $('#txtHotline').val(data.Hotline);
                $('#txtFax').val(data.Fax);
                $('#txtEmail').val(data.Email);
                $('#txtSlogan').val(data.Slogan);
                $('#txtLogo').val(data.ImageLogo);
                $('#txtFavicon').val(data.Favicon);
                $('#txtUserMail').val(data.UserMail);
                $('#txtPassMail').val(data.PassMail);
                $('#txtEmailReceive').val(data.EmailReceive);
                $('#txtFavicon').val(data.ImageFavicon);
                $('#txtAnalytics').val(data.Analytics);
                $('#txtWebMasterTool').val(data.WebMasterTool);
                $('#txtCodeChat').val(data.CodeChat);
                $('#txtGeoMeta').val(data.GeoMeta);
                $('#txtAppFacebook').val(data.AppFacebook);
                $('#txtFanpageFacebook').val(data.FanpageFacebook);
                $('#txtFanpageGoogle').val(data.FanpageGoogle);
                $('#txtFanpageYoutube').val(data.FanpageYoutube);
                $('#txtColor').val(data.Color);
                $('#txtHost').val(data.Host);
                $('#txtPort').val(data.Port);
                $('#txtTimeOut').val(data.TimeOut);
                $('#chkCoppy').bootstrapSwitch('state', data.Coppy);
                $('#chkStatus').bootstrapSwitch('state', netcore.getTrueFalse(data.Status));
                $('#txtTitle').val(data.TitleMeta);
                $('#txtDescription').val(data.DescriptionMeta);
                $('#txtKeyword').val(data.KeywordMeta);
                netcore.stopLoading();
            },
            error: function (status) {
                netcore.notify('Có lỗi xảy ra', 'error');
                netcore.stopLoading();
            }
        });
    }
    function registerEvents() {
        $('input[name="my-checkbox"]').on('switchChange.bootstrapSwitch', function (event, state) {
            event.preventDefault();
        });
        $('.btnSubmit').on('click', function (e) {
            Save();
        });

        $('#btnSelectLogo').on('click', function () {
            $('#fileLogo').click();
        });
        $('#btnSelectFavicon').on('click', function () {
            $('#fileFavicon').click();
        });
        $("#fileLogo").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
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
                    $('#txtLogo').val(path);
                    netcore.notify('Upload image succesful!', 'success');

                },
                error: function () {
                    netcore.notify('There was error uploading files!', 'error');
                }
            });
        });
        $("#fileFavicon").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
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
                    $('#txtFavicon').val(path);
                    netcore.notify('Upload image succesful!', 'success');

                },
                error: function () {
                    netcore.notify('There was error uploading files!', 'error');
                }
            });
        });

    }
    
    function Save() {

        var id = "config";
        var name = $('#txtName').val();
        var address = $('#txtAddress').val();
        var mobile = $('#txtPhone').val();
        var hotline = $('#txtHotline').val();
        var email = $('#txtEmail').val();
        var slogan = $('#txtSlogan').val();
        var imageLogo = $('#txtLogo').val();
        var favicon = $('#txtFavicon').val();
        var userEmail = $('#txtUserMail').val();
        var passEmail = $('#txtPassMail').val();
        var emailReceive = $('#txtEmailReceive').val();
        var analytics = $('#txtAnalytics').val();
        var webMasterTool = $('#txtWebMasterTool').val();
        var codeChat = $('#txtCodeChat').val();
        var geoMeta = $('#txtGeoMeta').val();
        var fax = $('#txtFax').val();
        var color = $('#txtColor').val();
        var host = $('#txtHost').val();
        var port = $('#txtPort').val();
        var timeOut = $('#txtTimeOut').val();
        var titleMeta = $('#txtTitle').val();
        var descriptionMeta = $('#txtDescription').val();
        var keywordMeta = $('#txtKeyword').val();
        var appFacebook = $('#txtAppFacebook').val();
        var fanpageFacebook = $('#txtFanpageFacebook').val();
        var fanpageGoogle = $('#txtFanpageGoogle').val();
        var fanpageYoutube = $('#txtFanpageYoutube').val();
        var status = $('#chkStatus').bootstrapSwitch('state');
        var coppy = $('#chkCoppy').bootstrapSwitch('state');
        //if (favicon != null) {
        //    favicon = UploadImage("#fileFavicon", "#txtFavicon");

        //}
        $.ajax({
            type: "POST",
            url: "/Admin/Config/SaveEntity",
            data: {
                Id: id,
                 Name: name,
                Address: address,
                Mobile: mobile,
                Hotline: hotline,
                Fax:fax,
                Email: email,
                Slogan: slogan,
                ImageLogo: imageLogo,
                ImageFavicon: favicon,
                UserMail: userEmail,
                PassMail: passEmail,
                EmailReceive: emailReceive,
                Analytics: analytics,
                WebMasterTool: webMasterTool,
                CodeChat: codeChat,
                GeoMeta: geoMeta,
                Color: color,
                Host: host,
                POrt: port,
                TimeOut: timeOut,             
                TitleMeta: titleMeta,
                KeywordMeta: keywordMeta,
                DescriptionMeta: descriptionMeta,
                AppFacebook: appFacebook,
                FanpageFacebook: fanpageFacebook,
                FanpageGoogle: fanpageGoogle,
                FanpageYoutube: fanpageYoutube,
                Status: status,
                Coppy: coppy
            },
            dataType: "json",
            beforeSend: function () {
                netcore.startLoading();
            },
            success: function (response) {
                netcore.notify('Update success', 'success');
                netcore.stopLoading();
               
            },
            error: function () {
                netcore.notify('Has an error in update progress', 'error');
                netcore.stopLoading();
            }
        });

        return false;
    }
}