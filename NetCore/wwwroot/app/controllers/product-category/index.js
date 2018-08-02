﻿var productCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvents(); registerControls();
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
        $('#btnCreate').off('click').on('click', function () {
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        $('body').on('click', '#btnCreateM', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });
        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            $.ajax({
                type: "GET",
                url: "/Admin/ProductCategory/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    netcore.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    initTreeDropDownCategory(data.ParentId);
                    $('#txtDescM').val(data.Description);
                    $('#txtContM').val(data.Content);
                    $('#txtIconM').val(data.Icon);
                    $('#txtImageM').val(data.Image);
                    $('#txtSeoKeywordM').val(data.SeoKeyWords);
                    $('#txtSeoDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);
                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#chkHomeflag').prop('checked', data.HomeFlag);
                    $('#txtOrderM').val(data.SortOrder);
                    $('#modal-add-edit').modal('show');
                    netcore.stopLoading();
                },
                error: function (status) {
                    netcore.notify('Có lỗi xảy ra', 'error');
                    netcore.stopLoading();
                }
            });
        });

        $('body').on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            netcore.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/Delete",
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
            //if ($('#frmMaintainance').valid()) {
            e.preventDefault();
            var id = parseInt($('#hidIdM').val());
            var name = $('#txtNameM').val();
            var parentId = $('#ddlCategoryIdM').combotree('getValue');
            var description = $('#txtDescM').val();
            var content = $('#txtContM').val();
            var icon = $('#txtIconM').val();
            var image = $('#txtImageM').val();
            var order = parseInt($('#txtOrderM').val());

            var seoKeyword = $('#txtSeoKeywordM').val();
            var seoMetaDescription = $('#txtSeoDescriptionM').val();
            var seoPageTitle = $('#txtSeoPageTitleM').val();
            var seoAlias = $('#txtSeoAliasM').val();
            var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
            var homeflag = $('#chkHomeglag').prop('checked');

            $.ajax({
                type: "POST",
                url: "/Admin/ProductCategory/SaveEntity",
                data: {
                    Id: id,
                    Name: name,
                    Description: description,
                    Content: content,
                    ParentId: parentId,
                    Ord: order,
                    HomeFlag: homeflag,
                    Image: image,
                    Icon: icon,
                    Status: status,
                    SeoMeta: seoPageTitle,
                    Alias: seoAlias,
                    KeywordMeta: seoKeyword,
                    DescriptionMeta: seoMetaDescription
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
            //}
            return false;
        });
    }
    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');
        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        $('#txtImageM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');
        $('#chkHomeflag').prop('checked', true);
        $('#txtContM').val('');
        $('#txtIconM').val('');
        $('#ckStatusM').prop('checked', true);
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
                arr.unshift({
                    id: '',
                    text: 'Menu Parent',
                    parentId: '',
                    SortOrder: '0'
                });
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }
    function loadData() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            dataType: 'json',
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var treeArr = netcore.unflattern(data);
                treeArr.sort(function (a, b) {
                    return a.sortOrder - b.sortOrder;
                });
                //var $tree = $('#treeProductCategory');

                $('#treeProductCategory').tree({
                    data: treeArr,
                    dnd: true,
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        // select the node
                        //$('#tt').tree('select', node.target);
                        $('#hidIdM').val(node.id);
                        // display context menu
                        $('#contextMenu').menu('show', {
                            left: e.pageX,
                            top: e.pageY
                        });
                    },
                    onDrop: function (target, source, point) {
                        console.log(target);
                        console.log(source);
                        console.log(point);
                        var targetNode = $(this).tree('getNode', target);
                        if (point === 'append') {
                            var children = [];
                            $.each(targetNode.children, function (i, item) {
                                children.push({
                                    key: item.id,
                                    value: i
                                });
                            });
                            //Update to database
                            $.ajax({
                                url: '/Admin/ProductCategory/UpdateParentId',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id,
                                    items: children
                                },
                                success: function (res) {
                                    netcore.notify('Deleted success', 'success');
                                    loadData();
                                }
                            });
                        }
                        else if (point === 'top' || point === 'bottom') {
                            $.ajax({
                                url: '/admin/ProductCategory/ReOrder',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id
                                },
                                success: function (res) {
                                    netcore.notify('Deleted success', 'success');
                                    loadData();
                                }
                            });
                        }
                    }
                });
            }
        });
    }
}