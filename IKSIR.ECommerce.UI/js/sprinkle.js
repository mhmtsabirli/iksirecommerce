$(document).ready(function () {
    if ($('#tabvanilla > ul').tabs != undefined) {
        $('#tabvanilla > ul').tabs({ fx: { height: 'toggle', opacity: 'toggle'} });
        $('#featuredvid > ul').tabs();
    }
});
