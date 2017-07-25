function DropDown(location, url) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application.json; charset=UTF-8",
        dataType: "json",
        success: function (data) {
            var List = $(location);
            List.append('<option selected="selected" value="0"> Please Select</option> ');
            for (var i = 0; i < data.length; i++) {
                List.append('<option selected="selected" value="' + data[i] + '">');
            }
            $(location).append(List);
        },
        failure: function (responce) {
            alert(resopnce.d);
        }
    });
}