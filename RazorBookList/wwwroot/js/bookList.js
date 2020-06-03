var dataTable

$(document).ready(function () {
    loadDataTable();
})

// # is to retrive data from html use #
//$ - creates DOM ele on fly on provided string of html.

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({ //.DataTable populate dT on DT_load
        "ajax": { //ajax call to api
            "url": "/api/book",
            "type": "GET", // as we are first gettiing DT values
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" }, //name of property and size for column
            { "data": "author", "width": "30%" },
            { "data": "isbn", "width": "30%" }, // first char will be in lower case
            {
                //this is for button
                "data": "id", // as we are passing id
                "render": function (data) {  // we want to render to button
                    return `<div class="text-center">
                                <a href="/bookList/Edit?id=${data}" class='btn btn-success' text-white style= 'cursor:pointer; width:100px'>
                                Edit
                                </a>
                                &nbps;
                                 <a class='btn btn-success' text-white style= 'cursor:pointer; width:100px'>
                                Delete
                                </a>
                            </div>`
                }, "width" : "30%"
                   
            }
        ],
        "langauage": {
            "emptyTable": "no data found"
        },
        "width": "100%"

    })   
}