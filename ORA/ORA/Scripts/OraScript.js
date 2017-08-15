jQuery(document).ready(function ($) {
    var path = window.location.pathname.split("/")[1];
    var target = $('nav div div button[id = "' + path + '"]');
    target.addClass(' active');
 });