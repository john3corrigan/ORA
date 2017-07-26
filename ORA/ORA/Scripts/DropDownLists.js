function DropDown(location, url) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application.json; charset=UTF-8",
        dataType: "json",
        success: function (data) {
            var List = "";
            List.append("<select>");
            List.append('<option selected="selected" value="0"> Please Select</option> ');
            for (var i = 0; i < row.d.length; i++) {
                List.append('<option selected="selected" value="' + row.d[i] + '">' + row.d[i] + '</option>');
            }
            List.append("</select>");
            $(location).append(List);
        },
        failure: function (responce) {
            alert(resopnce.d);
        }
    });
}