var productController = function () {
    var quantityManagenment = new QuantityManagement();
    var imageManagement = new ImageManagement();
    var wholePriceManagement = new WholePriceManagement();
    this.initialize = function () {
        $('input[name="my-checkbox"]').on('switchChange.bootstrapSwitch', function (event, state) {
            event.preventDefault();         
        });
        loadCategories();
        loadData();
        registerEvents();
        registerControls();       
        quantityManagenment.initialize();
        imageManagement.initialize();
        wholePriceManagement.initialize();
        initTreeDropDownCategory();
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
        $('input[name="my-checkbox"]').on('switchChange.bootstrapSwitch', function (event, state) {
            event.preventDefault();
          });         
        $('#ddlCategoryIdM').combotree({
            select: function (event, ui) {
                console.log("test thử thôi nhé");
            } 
        });
        $("#ddlCategoryIdM").combobox({
            change: function () {
                alert($(this).val());
            }
        });

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
            initTreeDropDownCategory($("#ddlCategory").val());

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
            //resetFormMaintainance();
            e.preventDefault();
            var that = $(this).data('id');
            loadDetails(that);
         
        });

        $('body').on('click', '.btnDelele', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            netcore.confirm('Are you sure to delete?', function () {
                deletes(that);
            });
        });

        $('#btnSave').on('click', function (e) {
            e.preventDefault();
            saveProduct();
        });
        $('#btnInport').on('click', function () {
            initTreeDropDownCategory();
            $('#modal-import-excel').modal('show');
        });
        $('#btnImportExcel').on('click', function () {
            var fileUpload = $("#fileInputExcel").get(0);
            var files = fileUpload.files;

            // Create FormData object  
            var fileData = new FormData();
            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {
                fileData.append("files", files[i]);
            }
            // Adding one more key to FormData object  
            fileData.append('categoryId', $('#ddlCategoryIdImportExcel').combotree('getValue'));
            $.ajax({
                url: '/Admin/Product/ImportExcel',
                type: 'POST',
                data: fileData,
                processData: false,  // tell jQuery not to process the data
                contentType: false,  // tell jQuery not to set contentType
                success: function (data) {
                    $('#modal-import-excel').modal('hide');
                    loadData();

                }
            });
            return false;
        });
        $('#btnExport').on('click', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Product/ExportExcel",
                beforeSend: function () {
                    netcore.startLoading();
                },
                success: function (response) {
                    window.location.href = response;
                    netcore.stopLoading();
                },
                error: function () {
                    netcore.notify('Has an error in progress', 'error');
                    netcore.stopLoading();
                }
            });
        });

        $('body').on('change', '.btnEditPrice', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidId').val(that);
            var price = $(this).val();
            $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                data: { id: that, price: price, priceSale: null, sortOrd: null, status: null, productSale: null,homeFlag:null },
                dataType: "json",
                success: function (data) {
                    $(this).val(netcore.formatNumber(price, 0));
                    netcore.notify('Update Price success', 'success');
                }
            });
            return false;
        });
        $('body').on('change', '.btnEditPriceSale', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidId').val(that);
            var priceSale = $(this).val();
            $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                data: { id: that, price: null, priceSale: priceSale, sortOrd: null, active: null, productSale: null, homeFlag: null },
                dataType: "json",
                success: function (data) {
                     netcore.notify('Update Price Sale success', 'success');
                }
            });
            return false;
        });
        $('body').on('change', '.btnEditSortOrd', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidId').val(that);
            var sortOrd = $(this).val();
            $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                data: { id: that, price: null, priceSale: null, sortOrd: sortOrd, active: null, productSale: null, homeFlag: null },
                dataType: "json",
                success: function (data) {
                     netcore.notify('Update SordOrd success', 'success');
                }
            });
            return false;
        });
        $('body').on('click', '.btnActive', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var that1 = $(this).attr("title");
            if (that1 == 1) {
                $(this).html("");
                $(this).append(netcore.updateStatus(that1));
                $(this).attr('title', '0');
            }
            else {
                $(this).html("");
                $(this).append(netcore.updateStatus(that1));
                $(this).attr('title', '1');
            }
            $('#hidId').val(that);
             $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                 data: { id: that, price: null, priceSale: null, sortOrd: null, active: that, productSale: null, homeFlag: null },
                dataType: "json",
                success: function (data) {
                    netcore.notify('Update Active success', 'success');
                }
            });
            return false;
        });
        $('body').on('click', '.btnProductSale', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var that1 = $(this).attr("title");
            if (that1 == 'true') {
                $(this).html("");
                $(this).append(netcore.UpdateValueBool(that1));
                $(this).attr('title', 'false');
            }
            else {
                $(this).html("");
                $(this).append(netcore.UpdateValueBool(that1));
                $(this).attr('title', 'true');
            }
            $('#hidId').val(that);
            $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                data: { id: that, price: null, priceSale: null, sortOrd: null, active: null, productSale: true, homeFlag: null },
                dataType: "json",
                success: function (data) {
                    netcore.notify('Update ProductSale success', 'success');
                }
            });
            return false;
        });
        $('body').on('click', '.btnHomeFlag', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var that1 = $(this).attr("title");
            if (that1 == 'true') {
                $(this).html("");
                $(this).append(netcore.UpdateValueBool(that1));
                $(this).attr('title', 'false');
            }
            else {
                $(this).html("");
                $(this).append(netcore.UpdateValueBool(that1));
                $(this).attr('title', 'true');
            }
            $('#hidId').val(that);
            $.ajax({
                url: '/Admin/Product/updateFast',
                type: 'POST',
                data: { id: that, price: null, priceSale: null, sortOrd: null, active: null, productSale: null, homeFlag: true },
                dataType: "json",
                success: function (data) {
                    netcore.notify('Update Home Flag success', 'success');
                }
            });
            return false;
        });
    }
   
    function saveProduct() {      
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
        var keywordMeta = $('#txtSeoKeywordM').val();
        var desctiptionMeta = $('#txtSeoDescriptionM').val();
        var titleMeta = $('#txtSeoTitleM').val();
        var tag = $('#txtTagM').val();
        var size = $('#txtSizeM').val();
        var sale = $('#txtSaleM').val();
        var age = $('#txtAgeM').val();
        var warranty = $('#txtWanM').val();
        var notePrice = $('#txtNotePM').val();
        var price = $('#txtPriceM').val();
        var priceSale = $('#txtPriceSaleM').val();
        var homeFlag = $('#chkHomeFlag').prop('checked');
        var check = $('#chkStatusM').bootstrapSwitch('state');
        var status = $('#chkStatusM').prop('checked')== true ? 1 : 0;
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
                SortOrder: ord,
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
                SeoTitle: titleMeta,
                SeoKeyWords: keywordMeta,
                SeoDescription: desctiptionMeta
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
                loadCategories(categoryId);
                  loadData(true);
            },
            error: function () {
                netcore.notify('Has an error in update progress', 'error');
                netcore.stopLoading();
            }
        });

        return false;
    }
    function deletes(id) {
        $.ajax({
            type: "POST",
            url: "/Admin/product/Delete",
            data: { id: id },
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
    }
    function loadDetails(id) {
        $.ajax({
            type: "GET",
            url: "/Admin/Product/GetById",
            data: { id: id },
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
                $('#txtImageM').val(data.ImageDetail);
                $('#txtInfoM').val(data.Info);
                CKEDITOR.instances.txtContM.setData(data.Content);
                $('#txtMetakeywordM').val(data.SeoKeyword);
                $('#txtSeoDescriptionM').val(data.SeoDescription);
                $('#txtSeoPageTitleM').val(data.SeoTitle);
                $("#txtTagM").tagsinput(data.Tag);

                $('#txtSizeM').val(data.Size);
                $('#txtSaleM').val(data.Sale);
                $('#txtAgeM').val(data.Age);
                $('#txtWanM').val(data.Warranty);
                $('#txtNotePM').val(data.NotePrice); 
                $('#txtOrderM').val(data.SortOrder);
                $('#txtPriceM').val(data.Price);
                $('#txtPriceSaleM').val(data.PriceSale);
                $('#chkHomeFlag').bootstrapSwitch('state', data.HomeFlag);
                $('#chkStatusM').bootstrapSwitch('state', netcore.getTrueFalse(data.Status));
                $('#chkNewM').bootstrapSwitch('state', data.New);
                $('#chkSale').bootstrapSwitch('state', data.ProductSale);
                $('#txtSeoTitleM').val(data.SeoTitle);
                $('#txtSeoDescriptionM').val(data.SeoDescription);
                $('#txtSeoKeywordM').val(data.SeoKeyWords);
                $('#modal-add-edit').modal('show');

                netcore.stopLoading();
            },
            error: function (status) {
                netcore.notify('Có lỗi xảy ra', 'error');
                netcore.stopLoading();
            }
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
        $('#txtSeoKeywordM').val('');
        $('#txtSeoDescriptionM').val('');
        $('#txtSeoTitleM').val('');
        $('#txtSeoAliasM').val('');
        $("#txtTagM").tagsinput('thiệp vũ');


        $('#txtSizeM').val('');
        $('#txtSaleM').val('');
        $('#txtAgeM').val('');
        $('#txtWanM').val('');
        $('#txtNotePM').val('');
        $('#txtPriceM').val('');
        $('#txtPriceSaleM').val('');
        $('#chkStatusM').bootstrapSwitch('state', true);
        $('#chkHomeFlag').bootstrapSwitch('state', false);
        $('#chkNewM').bootstrapSwitch('state', false);
        $('#chkSale').bootstrapSwitch('state', false);
 
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
                $('#ddlCategoryIdImportExcel').combotree({
                    data: arr
                });
                
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                    $('#ddlCategoryIdImportExcel').combotree('setValue', selectedId);
                }
            }
        });
    }
    function loadCategories(id) {
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
                    if (item.Id == id) {
                        render += "<option value='" + item.Id + "' selected> " + item.Name + "</option>";
                    }
                    else {

                    } render += "<option value='" + item.Id + "'> " + item.Name + "</option>";
                    
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
                categoryId: ddlCategory,
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
                        PriceSale: netcore.formatNumber(item.PriceSale, 0),
                        SortOrder: item.SortOrder,
                        Actives: item.Active,
                        Active: netcore.getStatus(item.Active, item.Id),
                        ProductSales: item.ProductSale,
                        ProductSale: netcore.getValueBool(item.ProductSale, item.Id),
                        HomeFlags: item.HomeFlag,
                        HomeFlag: netcore.getValueBool(item.HomeFlag, item.Id)

                    });
                   
                });
               
                $('#lblTotalRecords').text(response.RowCount);
                if (render != '') {
                    $('#tbl-content').html(render);
                    $('input[name="my-checkbox"]').bootstrapSwitch();
                     
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