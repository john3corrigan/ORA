function DropDown(location, url) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application.json; charset=UTF-8",
        dataType: "json",
        success: function (data) {
            var List = $(location);
            for (var i = 0; i < data.length; i++) {
                List.append('<option value="' + data[i] + '">' + data[i].Title + '</option>');
            }
            $(location).append(List);
        },
        failure: function (responce) {
            alert(resopnce.d);
        }
    });
}
function saveassignment() {
    $.ajax({
        type: "POST",
        url: "/Assignment/CreateAssignment",
        data: ,
        success: function (result) {
            if (result) {
                window.location("")
            } else {
                window.location("/Shared/Error")
            }
        },
        failure: function (responce) {
            alert(resopnce.d);
        }
    });
}
