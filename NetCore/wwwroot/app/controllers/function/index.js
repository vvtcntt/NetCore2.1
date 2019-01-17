var functionController = function () {
	this.initialize = function () {
		loadData();
		registerEvents(); 
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
            resetFormMaintainance();
            initTreeDropDownCategory();

            $("#idm").show();
			$('#modal-add-edit').modal('show');
		});

        $('body').on('click', '#btnCreateM', function (e) {
            resetFormMaintainance();
            e.preventDefault();
            $("#idm").show();
			var that = $('#hidIdM').val();
			initTreeDropDownCategory();
			$('#modal-add-edit').modal('show');
		});
		$('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            $("#idm").hide();
			var that = $('#hidIdM').val();
			$.ajax({
				type: "GET",
				url: "/Admin/function/GetById",
				data: { id: that },
				dataType: "json",
				beforeSend: function () {
					netcore.startLoading();
				},
				success: function (response) {
					var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtId').val(data.Id);
					$('#txtNameM').val(data.Name);
					initTreeDropDownCategory(data.ParentId);
                    $('#txtUrl').val(data.URL);
                    $('#txtiConCss').val(data.IconCss);
                    $('#txtOrderM').val(data.SortOrder);
					$('#ckStatusM').prop('checked', data.Status == 1);
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
					url: "/Admin/function/Delete",
					data: { id: that },
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
            var id = $('#txtId').val();
            var name = $('#txtNameM').val();
            var url = $('#txtUrl').val();
			var parentId = $('#ddlCategoryIdM').combotree('getValue');
            var iconCss = $('#txtiConCss').val();
            var sortOrd = $('#txtOrderM').val();

            var status = $('#chkStatusM').prop('checked') == true ? 1 : 0;
			$.ajax({
				type: "POST",
				url: "/Admin/function/SaveEntity",
				data: {
					Id: id,
                    Name: name,		
                    URL: url,
					ParentId: parentId,
                    IconCss: iconCss,
					Status: status,
                    SortOrder: sortOrd			

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
		$('#txtId').val('');
		$('#txtNameM').val('');
		initTreeDropDownCategory('');
        $('#txtIconM').val('');
        $('#txtiConCss').val('');
        $('#txtOrderM').val('');
		$('#ckStatusM').prop('checked', true);
	}

	function initTreeDropDownCategory(selectedId) {
		$.ajax({
			url: "/Admin/Function/GetAllFunc",
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
			url: '/Admin/function/GetAllFunc',
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
				//var $tree = $('#treefunction');

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
								url: '/Admin/function/UpdateParentId',
								type: 'post',
								dataType: 'json',
								data: {
									sourceId: source.id,
									targetId: targetNode.id,
									items: children
								},
								success: function (res) {
                                    loadData();
                                    netcore.notify('Upload succesful!', 'success');
								}
							});
						}
						else if (point === 'top' || point === 'bottom') {
							$.ajax({
								url: '/admin/function/ReOrder',
								type: 'post',
								dataType: 'json',
								data: {
									sourceId: source.id,
									targetId: targetNode.id
								},
                                success: function () {
                                    netcore.notify('Upload succesful!', 'success');

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