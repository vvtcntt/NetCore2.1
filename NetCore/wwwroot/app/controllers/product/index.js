var productController = function () {
    this.initialize = function () {
        loadCategories(); loadData(); registerEvents(); registerControls();
    }
    function registerControls() {
        CKEDITOR.replace('txtContM', {});

        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };

    }
    function registerEvents() {
        $('#ddlShowPage').on('change', function () {
            netcore.config.pageSize = $(this).val();
            netcore.config.pageIndex = 1;
            loadData(true);
        });
        $('#btnSearch').on('click', function () {
            loadData(true);
        })
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                 loadData(true);
            }
        });
        $('#btnCreate').off('click').on('click', function () {
            resetFormMaintainance();
          initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });
        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });

        $("#fileInputImage").on('change', function () {
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
                    $('#txtImageM').val(path);
                    netcore.notify('Upload image succesful!', 'success');

                },
                error: function () {
                    netcore.notify('There was error uploading files!', 'error');
                }
            });
        });
        $('body').on('click', '.btnEdit', function (e) {
            resetFormMaintainance();
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Product/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    netcore.startLoading();
                },
                success: function (response) {
                    var data = response;
                    initTreeDropDownCategory(data.CategoryId);
                    //sdsdsd
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    $('#txtCodeM').val(data.Code);
                    $('#txtDescM').val(data.Description);
                    $('#txtOrderM').val(data.sortOrder);
                    $('#txtImageM').val(data.imageDetail);
                    $('#txtInfoM').val(data.Info);
                    CKEDITOR.instances.txtContM.setData(data.Content);
                    $('#txtMetakeywordM').val(data.SeoKeyword);
                    $('#txtMetaDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoTitle);
                    $('#txtTagM').val(data.Tag);
                    $('#txtSizeM').val(data.Size);
                    $('#txtSaleM').val(data.Sale);
                    $('#txtAgeM').val(data.Age);
                    $('#txtWanM').val(data.Warranty);
                    $('#txtNotePM').val(data.NotePrice);
                    $('#txtPriceM').val(data.Price);
                    $('#txtPriceSaleM').val(data.PriceSale);
                    $('#chkHomeFlag').prop('checked', data.HomeFlag);
                    $('#ckStatusM').prop('checked', data.Status);
                    $('#chkNewM').prop('checked', data.New);
                    $('#chkSale').prop('checked', data.ProductSale);
                    $('#modal-add-edit').modal('show');
                    netcore.stopLoading();
                },
                error: function (status) {
                    netcore.notify('Có lỗi xảy ra', 'error');
                    netcore.stopLoading();
                }
            });
        });

        $('body').on('click', '.btnDelele', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            netcore.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        netcore.startLoading();
                    },
                    success: function (response) {
                        netcore.notify('Deleted success', 'success');
                        netcore.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        netcore.notify('Has an error in deleting progress', 'error');
                        netcore.stopLoading();
                    }
                });
            });
        });

        $('#btnSave').on('click', function (e) {
            
                e.preventDefault();

                var categoryId = $('#ddlCategoryIdM').combotree('getValue');

                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var info = $('#txtInfoM').val();
            var content = CKEDITOR.instances.txtContM.getData();
                var code = $('#txtCodeM').val();
                var description = $('#txtDescM').val();
                var ord = $('#txtOrderM').val();
                var imageDetail = $('#txtImageM').val();
                var info = $('#txtInfoM').val();
                var keywordMeta = $('#txtMetakeywordM').val();
                var desctiptionMeta = $('#txtMetaDescriptionM').val();
                var titleMeta = $('#txtSeoPageTitleM').val();
                var tag = $('#txtTagM').val();
                var size = $('#txtSizeM').val();
                var sale = $('#txtSaleM').val();
                var age = $('#txtAgeM').val();
                var warranty = $('#txtWanM').val();
                var notePrice = $('#txtNotePM').val();
                var price = $('#txtPriceM').val();
                var priceSale = $('#txtPriceSaleM').val();
                var homeFlag = $('#chkHomeFlag').prop('checked');
                var status = $('#chkStatusM').prop('checked') == true ? 1 : 0;
                var productNew = $('#chkNewM').prop('checked');
                var productSale = $('#chkSale').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/product/SaveEntity",
                    data: {
                        Id: id,
                        CategoryId: categoryId,
                        Name: name,
                        Code: code,
                        Description: description,
                        Content: content,
                        Ord: ord,
                        HomeFlag: homeFlag,
                        ImageDetail: imageDetail,
                        ImageThumbs: 'chưa có',
                        Info: info,
                        Tag: tag,
                        Size: size,
                        sale: sale,
                        Age: age,
                        Warranty: warranty,
                        NotePrice: notePrice,
                        Price: price,
                        PriceSale: priceSale,
                        HomeFlag: homeFlag,
                        Status: status,
                        New: productNew,
                        ProductSale: productSale,
                        TitleMeta: titleMeta,
                        KeywordMeta: keywordMeta,
                        DescriptionMeta: desctiptionMeta
                    },
                    dataType: "json",
                    beforeSend: function () {
                        netcore.startLoading();
                    },
                    success: function (response) {
                        netcore.notify('Update success', 'success');
                        $('#modal-add-edit').modal('hide');

                        resetFormMaintainance();

                        netcore.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        netcore.notify('Has an error in update progress', 'error');
                        netcore.stopLoading();
                    }
                });
          
            return false;
        });
    }
    function resetFormMaintainance() {
        initTreeDropDownCategory('');
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
         $('#txtCodeM').val('');
        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        CKEDITOR.instances.txtContM.setData('');

        $('#txtImageM').val('');
        $('#txtInfoM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');
        $('#txtTagM').val('');
        $('#txtSizeM').val('');
        $('#txtSaleM').val('');
        $('#txtAgeM').val('');
        $('#txtWanM').val('');
        $('#txtNotePM').val('');
        $('#txtPriceM').val('');
        $('#txtPriceSaleM').val('');
        $('#chkHomeFlag').prop('checked', true);
        $('#chkStatusM').prop('checked', true);
        $('#chkNewM').prop('checked', true);
        $('#chkSale').prop('checked', true);
    }
    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var data = [];

                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.Ord
                    });
                });

                var arr = netcore.unflattern(data);
              
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }
    function loadCategories() {
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $("#ddlCategory").val(),
                keyword: $('#txtKeyword').val(),
                page: netcore.config.pageIndex,
                pageSize: netcore.config.pageSize
            },
            url: '/admin/product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                var render = "<option value='' >--Chọn danh mục--</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.id + "'> " + item.Name + "</option>";
                });
                $('#ddlCategory').html(render);
            },
            error: function (status) {
                console.log(status);
                netcore.notify('Cannot loading data', 'error');
            }
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        var ddlCategory = $("#ddlCategory").val();
        $.ajax({
            type: 'GET',
            data: {
                categoryId: null,
                keyword: $('#txtKeyword').val(),
                page: netcore.config.pageIndex,
                pageSize: netcore.config.pageSize
            },
            url: '/admin/product/getAllpaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        ImageThumbs: item.ImageThumbs == null ? '<img src="/admin-site/images/user.png" width=25' : '<img src="' + item.ImageThumbs + '" width=25>',
                        CategoryName: item.ProductCategory.Name,
                        Price: netcore.formatNumber(item.Price, 0),
                        DateCreated: netcore.dateTimeFormatJson(item.DateCreated),
                        Status: netcore.getStatus(item.Status)
                    });
                   
                });
               
                $('#lblTotalRecords').text(response.RowCount);
                if (render != '') {
                    $('#tbl-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                netcore.notify('Cannot loading data', 'error');
            }
        });
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / netcore.config.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                netcore.config.pageIndex = p;
                setTimeout(callBack(), 100);
            }
        });
    }

}