$(document).ready(function () {
    $("#popup").dialog({
        autoOpen: false,
        title: 'Title',
        width: 500,
        height: 'auto',
        modal: true
    });
});
function openPopup() {
    $("#popup").dialog("open");
}