var producttd;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    producttd = $("#mytable").DataTable({
        "ajax": {
            "url": "/Admin/Product/GetData",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "id" }, 
            { "data": "name" },
            { "data": "description" },  // Corrected 'discription' to 'description'  < a href="/Admin/Product/Edit/' + data + '" > Edit</a >

            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",  // Add an action column
                "render": function (data, type, row) {
                    return `
                        <a href="/Admin/Product/Edit/${data}" class="btn btn-success">Edit</a>
                        <a onClick=DeleteItem("/Admin/Product/Delete/${data}") class="btn btn-danger">Delete</a>
                    `;
                }

            }
        ]
    });
}



function DeleteItem(url) {

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        producttd.ajax.reload();
                        toaster.success(data.message);
                    } else {
                        toaster.error(data.message);

                    }
                }

            });
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });

}
