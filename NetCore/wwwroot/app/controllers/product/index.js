var productController = function () {
    this.initialize = function () {
        loadData(); registerEvents();
    }
    function registerEvents() {
        $('#ddlShowPage').on('change', function () {
            netcore.config.pageSize = $(this).val();
            netcore.config.pageIndex = 1;
            loadData(true);
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $("#ddlCategory").val(),
                keyword: $('#txtKeyword').val(),
                page: netcore.config.pageIndex,
                pageSize: netcore.config.pageSize
            },
            url: '/admin/product/getAllpaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
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