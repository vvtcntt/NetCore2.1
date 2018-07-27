var productController = function () {
    this.initialize = function () {
        loadData();
    }
    function registerEvents() {

    }
    function loadData() {
        var template= $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            url: '/admin/product/getAll',
            dataType: 'json',
            success: function (response) {
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.Name,
                        ImageThumbs: item.ImageThumbs == null ? '<img src="/admin-site/images/user.png" width=25' : '<img src="' + item.ImageThumbs + '" width=25>',
                        CategoryName: item.ProductCategory.Name,
                        Price: netcore.formatNumber(item.Price,0),
                        DateCreated: netcore.dateTimeFormatJson(item.DateCreated),
                        Status: netcore.getStatus(item.Status)

                    });
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                });
            },
            error: function (status) {
                console.log(status);
                netcore.notify('Cannot loading data', 'error');
            }    
        })
    }
}